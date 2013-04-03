using System;
using Windows.Foundation;
using System.Threading.Tasks;

namespace System.Threading.Tasks
{
	class TaskToAsyncOperationAdapter<T> : IAsyncOperation<T>
	{
		//TODO: TaskToAsyncInfoAdapter?

		Task<T> Task { get; set; }

		public TaskToAsyncOperationAdapter(Task<T> task)
		{
			if (task.Status == TaskStatus.Created)
				throw new InvalidOperationException("The specified underlying Task is not started. Task instances must be run immediately upon creation.");

			Task = task;
			Status = Task.Status.ToAsyncStatus();

			if (Status == AsyncStatus.Started)
			{
				var updateStatus = Task.ContinueWith(t =>
				{
					lock (this)
					{
						if (Status == AsyncStatus.Started)
							Status = t.Status.ToAsyncStatus();
					}
				});
			}
		}

		#region IAsyncOperation implementation

		public T GetResults()
		{
			if (Status != AsyncStatus.Completed)
				throw new InvalidOperationException("Cannot call GetResults on this asynchronous info because the underlying operation has not completed.");

			return Task.Result;
		}

		public AsyncOperationCompletedHandler<T> Completed { get; set; }

		#endregion

		#region IAsyncInfo implementation

		public void Start()
		{
			Task.Start();
		}

		public void Close()
		{
			Task.Dispose();
		}

		public void Cancel()
		{
			lock (this)
			{
				if (Status == AsyncStatus.Started)
					Status = AsyncStatus.Canceled;
			}
		}

		public uint Id { get { return (uint)Task.Id; } }

		public Exception ErrorCode { get { return Task.Exception; } }

		public AsyncStatus Status { get; private set; }

		#endregion
	}
}

