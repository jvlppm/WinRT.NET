using System;
using System.Threading.Tasks;
using Windows.Foundation;

namespace System.Threading.Tasks.Internal
{
	internal class TaskToAsyncOperationWithProgressAdapter<TResult, TProgress> : TaskToAsyncInfoAdapter<AsyncOperationWithProgressCompletedHandler<TResult, TProgress>>, IAsyncOperationWithProgress<TResult, TProgress>
	{
		/// <summary>
		/// Starts a new async operation with progress report.
		/// </summary>
		/// <returns>The new operation.</returns>
		/// <param name="function">The function to run asynchronously.</param>
		/// <param name="cancellation">Cancellation token.</param>
		/// <param name="taskCreationOptions">Task creation options.</param>
		/// <param name="scheduler">The Scheduler that the function will be executed on.</param>
		public static TaskToAsyncOperationWithProgressAdapter<TResult, TProgress> StartNew(Func<IProgress<TProgress>, TResult> function, CancellationToken cancellation = default(CancellationToken), TaskCreationOptions taskCreationOptions = TaskCreationOptions.None, TaskScheduler scheduler = null)
		{
			if (function == null)
				throw new ArgumentException("function");

			var progress = new Progress<TProgress>();
			var adapter = new TaskToAsyncOperationWithProgressAdapter<TResult, TProgress>();
			adapter.Task = Tasks.Task.Factory.StartNew(p => function((IProgress<TProgress>)p), progress,
																cancellation,
																taskCreationOptions,
																scheduler ?? TaskScheduler.Default);
			progress.ProgressChanged += adapter.ReportProgress;

			if (cancellation != default(CancellationToken))
				cancellation.Register(adapter.Cancel);

			return adapter;
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
