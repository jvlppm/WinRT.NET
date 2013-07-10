//
// TaskAction.cs
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

namespace Windows.Foundation
{
	internal class TaskAction
		: IAsyncAction
	{
		public TaskAction (Action action)
		{
			if (action == null)
				throw new ArgumentNullException ("action");

			this.action = o => action();
			Id = AsyncInfo.GetNextInfoId();
			Start();
		}

		public TaskAction(Action<IAsyncAction> action)
		{
			if (action == null)
				throw new ArgumentNullException("action");

			this.action = action;
			Id = AsyncInfo.GetNextInfoId();
			Start();
		}

		public AsyncActionCompletedHandler Completed
		{
			get { return this.completed; }
			set
			{
				// WinRT throws a NullReferenceException when the Completed handler is set to null.
				// this happens even if the IAsyncAction is still running.
				if (value == null)
					throw new NullReferenceException();

				if (this.completed != null)
					throw new InvalidOperationException("A delegate was assigned when not allowed.");

				completed = value;
			}
		}

		public void GetResults()
		{
		}

		public uint Id
		{
			get;
			private set;
		}

		public Exception ErrorCode
		{
			get { return (this.task != null) ? this.task.Exception : null; }
		}

		public AsyncStatus Status
		{
			get
			{
				if (this.task == null)
					throw new InvalidOperationException("Action was not started");

				if (this.cancelSource.IsCancellationRequested)
					return AsyncStatus.Canceled;

				return this.task.Status.ToAsyncStatus();
			}
		}

		void Start()
		{
			if (Interlocked.CompareExchange(ref this.state, 1, 0) == 1)
				throw new InvalidOperationException("Action already started");

			this.task = Task.Factory.StartNew(s => this.action((IAsyncAction)s), this, this.cancelSource.Token);
			this.task.ContinueWith(t =>
			{
				AsyncActionCompletedHandler c = Completed;
				if (c != null)
					c(this, Status);
			});
		}

		public void Close()
		{
			if (this.state == 0)
				throw new InvalidOperationException("Action has not already run");

			this.cancelSource.Dispose();
		}

		public void Cancel()
		{
			this.cancelSource.Cancel();
		}

		private int state;
		private Task task;
		private CancellationTokenSource cancelSource = new CancellationTokenSource();
		AsyncActionCompletedHandler completed;

		private Action<IAsyncAction> action;
	}
}