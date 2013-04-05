using System;
using Windows.Foundation;
using System.Threading.Tasks;

namespace System.Threading.Tasks
{
	class TaskToAsyncActionAdapter : IAsyncAction
	{
		//TODO: TaskToAsyncInfoAdapter?

		Task Task { get; set; }

		public TaskToAsyncActionAdapter(Task task)
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

		public void GetResults()
		{
			if(Status == AsyncStatus.Error)
				throw ErrorCode;

			if (Status != AsyncStatus.Completed)
				throw new InvalidOperationException("Cannot call GetResults on this asynchronous info because the underlying operation has not completed.");
		}

		public AsyncActionCompletedHandler Completed { get; set; }

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

