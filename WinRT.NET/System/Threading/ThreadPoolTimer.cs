//
// ThreadPoolTimer.cs
//
// Author:
//   Eric Maupin <me@ermau.com>
//
// Copyright (c) 2011 Eric Maupin
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace Windows.System.Threading
{
	public delegate void TimerElapsedHandler(ThreadPoolTimer timer);

	/// <summary>
	/// Represents a method that is called when a timer created with CreateTimer or CreatePeriodicTimer is complete.
	/// </summary>
	/// <param name="timer">The timer to associate with this method.</param>
	[Guid("34ed19fa-8384-4eb9-8209-fb5094eeec35")]
	[Version(WindowsVersion.NTDDI_WIN8)]
	[WebHostHidden]
	public delegate void TimerDestroyedHandler(ThreadPoolTimer timer);

	/// <summary>
	/// Represents a timer created with CreateTimer or CreatePeriodicTimer.
	/// </summary>
	//[Static(typeof(Windows.System.Threading.IThreadPoolTimerStatics), WindowsVersion.NTDDI_WIN8)]
	[WebHostHidden]
	[Threading(ThreadingModel.Both)]
	[MarshalingBehavior(MarshalingType.Agile)]
	[Version(WindowsVersion.NTDDI_WIN8)]
	public sealed class ThreadPoolTimer
	{
		#region Properties
		public TimeSpan Delay { get; private set; }
		public TimeSpan Period { get; private set; }
		#endregion

		#region Methods
		/// <summary>
		/// Cancels a timer.
		/// </summary>
		public void Cancel()
		{
			lock (this)
			{
				this.isCanceled = true;
				this.realTimer.Dispose();

				if (!isRunning && destroyed != null)
				{
					Task.Factory.StartNew(d => ((TimerDestroyedHandler)d)(this), destroyed);
					destroyed = null;
				}
			}
		}

		/// <summary>
		/// Creates a periodic timer.
		/// </summary>
		/// <param name="handler">The method to call when the timer expires.</param>
		/// <param name="period">
		/// The number of milliseconds until the timer expires.
		/// The timer reactivates each time the period elapses, until the timer is canceled.
		/// </param>
		/// <returns>An instance of a periodic timer.</returns>
		public static ThreadPoolTimer CreatePeriodicTimer(TimerElapsedHandler handler, TimeSpan period)
		{
			return CreatePeriodicTimer(handler, period, destroyed: null);
		}

		/// <summary>
		/// Creates a periodic timer and specifies a method to call after the periodic timer is complete.
		/// The periodic timer is complete when the timer has expired without being reactivated, and the final call to handler has finished.
		/// </summary>
		/// <param name="handler">The method to call when the timer expires.</param>
		/// <param name="period">
		/// The number of milliseconds until the timer expires.
		/// The timer reactivates each time the period elapses, until the timer is canceled.
		/// </param>
		/// <param name="destroyed">The method to call after the periodic timer is complete.</param>
		/// <returns>An instance of a periodic timer.</returns>
		public static ThreadPoolTimer CreatePeriodicTimer(TimerElapsedHandler handler, TimeSpan period, TimerDestroyedHandler destroyed)
		{
			if (handler == null)
				throw new ArgumentException("handler");

			return new ThreadPoolTimer(handler, destroyed: destroyed, delay: period, isPeriodic: true);
		}

		/// <summary>
		/// Creates a single-use timer.
		/// </summary>
		/// <param name="handler">The method to call when the timer expires.</param>
		/// <param name="delay">The number of milliseconds until the timer expires.</param>
		/// <returns>An instance of a single-use timer.</returns>
		public static ThreadPoolTimer CreateTimer(TimerElapsedHandler handler, TimeSpan delay)
		{
			return CreateTimer(handler, delay, destroyed: null);
		}

		/// <summary>
		/// Creates a single-use timer and specifies a method to call after the timer is complete.
		/// The timer is complete when the timer has expired and the final call to handler has finished.
		/// </summary>
		/// <param name="handler">The method to call when the timer expires.</param>
		/// <param name="delay">The number of milliseconds until the timer expires.</param>
		/// <param name="destroyed">The method to call after the timer is complete.</param>
		/// <returns>An instance of a single-use timer.</returns>
		public static ThreadPoolTimer CreateTimer(TimerElapsedHandler handler, TimeSpan delay, TimerDestroyedHandler destroyed)
		{
			if (handler == null)
				throw new ArgumentException("handler");

			return new ThreadPoolTimer(handler, destroyed, delay, isPeriodic: false);
		}
		#endregion

		#region Private
		#region Attributes
		private bool isCanceled;
		private volatile bool isPeriodic;
		private bool isRunning;
		private readonly TimerElapsedHandler handler;
		private TimerDestroyedHandler destroyed;
		private readonly Timer realTimer;
		#endregion

		#region Constructors
		private ThreadPoolTimer(TimerElapsedHandler handler, TimerDestroyedHandler destroyed, TimeSpan delay, bool isPeriodic)
		{
			Delay = delay;
			if (isPeriodic)
				Period = delay;
			this.isPeriodic = isPeriodic;

			this.handler = handler;
			this.destroyed = destroyed;

			this.realTimer = new Timer(t =>
			{
				var ltimer = (ThreadPoolTimer)t;

				lock (ltimer)
				{
					if (ltimer.isCanceled)
						return;
					ltimer.isRunning = true;
				}

				Task.Factory.StartNew(o =>
				{
					ThreadPoolTimer taskedTimer = (ThreadPoolTimer)o;
					try
					{
						taskedTimer.handler(taskedTimer);
					}
					finally
					{
						lock (ltimer)
						{
							taskedTimer.isRunning = false;
							if (!taskedTimer.isPeriodic || taskedTimer.isCanceled)
								ltimer.Cancel();
						}
					}
				}, ltimer);
			}, this, (int)delay.TotalMilliseconds, (isPeriodic) ? (int)delay.TotalMilliseconds : Timeout.Infinite);
		}
		#endregion
		#endregion
	}
}