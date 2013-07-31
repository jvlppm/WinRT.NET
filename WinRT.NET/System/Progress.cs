using System;
using System.Threading;
using System.Threading.Tasks;

namespace System
{
#if !NET_4_5
	public class Progress<T> : IProgress<T>
	{
		TaskScheduler scheduler;

		/// <summary>
		/// Initializes the Progress<T> object.
		/// </summary>
		public Progress()
		{
			scheduler = TaskScheduler.Current;
		}

		/// <summary>
		/// Initializes the Progress<T> object with the specified callback.
		/// </summary>
		/// <param name="handler">
		/// A handler to invoke for each reported progress value. This handler
		/// will be invoked in addition to any delegates registered with the
		/// ProgressChanged event. Depending on the SynchronizationContext
		/// instance captured by the Progress<T> at construction, it is
		/// possible that this handler instance could be invoked concurrently
		/// with itself.
		/// </param>
		public Progress(Action<T> handler) : this()
		{
			ProgressChanged += (s, e) => handler(e);
		}

		/// <summary>
		/// Raised for each reported progress value.
		/// </summary>
		/// <remarks>
		/// Handlers registered with this event will be invoked on the
		/// SynchronizationContext captured when the instance was constructed.
		/// </remarks>
		public event EventHandler<T> ProgressChanged;

		public void Report(T value)
		{
			var handler = ProgressChanged;
			if (handler != null)
				Task.Factory.StartNew(v => handler(this, (T)v), value, CancellationToken.None, TaskCreationOptions.None, this.scheduler);
		}
	}
#endif
}

