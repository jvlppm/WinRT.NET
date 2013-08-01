using System;
using System.Threading.Tasks;
using Windows.Foundation;

namespace System.Threading.Tasks.Internal
{
	internal class TaskToAsyncOperationWithProgressAdapter<TResult, TProgress> : TaskToAsyncInfoAdapter<AsyncOperationWithProgressCompletedHandler<TResult, TProgress>>, IAsyncOperationWithProgress<TResult, TProgress>
	{
		public TaskToAsyncOperationWithProgressAdapter(Task<TResult> task, Progress<TProgress> progress)
			: base(task)
		{
			progress.ProgressChanged += ReportProgress;
		}

		new Task<TResult> Task
		{
			get { return (Task<TResult>)base.Task; }
			set { base.Task = value; }
		}

		#region IAsyncOperationWithProgress implementation

		protected override void Invoke(AsyncOperationWithProgressCompletedHandler<TResult, TProgress> completed)
		{
			completed(this, Status);
		}

		new public TResult GetResults()
		{
			base.GetResults();
			return Task.Result;
		}

		void ReportProgress(object sender, TProgress e)
		{
			var handler = Progress;
			if (handler != null)
				handler(this, e);
		}

		public AsyncOperationProgressHandler<TResult, TProgress> Progress { get; set; }

		#endregion

	}
}
