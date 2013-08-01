//
// ThreadPool.cs
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
using Windows.Foundation;
using Windows.Foundation.Metadata;
using System.Threading.Tasks.Internal;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace Windows.System.Threading
{
	/// <summary>
	/// Represents a method that is called when a work item runs.
	/// </summary>
	[Guid("1d1a8b8b-fa66-414f-9cbd-b65fc99d17fa")]
	[Version(WindowsVersion.NTDDI_WIN8)]
	[WebHostHidden]
	public delegate void WorkItemHandler(IAsyncAction operation);
	/// <summary>
	/// Allows access to the thread pool. See Using the thread pool in Windows
	/// Store apps for detailed guidance on using the thread pool:
	/// </summary>
	//[MarshalingBehavior(Agile)]
	//[Static(Windows.System.Threading.IThreadPoolStatics, WindowsVersion.NTDDI_WIN8)]
	[Threading(ThreadingModel.Both)]
	[Version(WindowsVersion.NTDDI_WIN8)]
	[WebHostHidden]
	public static class ThreadPool
	{
		/// <summary>
		/// Creates a work item.
		/// </summary>
		/// <param name="handler">The method to call when a thread becomes available to run the work item.</param>
		/// <returns>An IAsyncAction interface that provides access to the work item.</returns>
		public static IAsyncAction RunAsync(WorkItemHandler handler)
		{
			if (handler == null)
				throw new ArgumentException("handler");

			var adapter = new TaskToAsyncActionAdapter();

			adapter.Task = Task.Factory.StartNew(a => handler((IAsyncAction)a), adapter,
																CancellationToken.None,
																TaskCreationOptions.None,
																TaskScheduler.Default);

			return adapter;
		}

		/// <summary>
		/// Creates a work item and specifies its priority relative to other work
		/// items in the thread pool.
		/// </summary>
		/// <param name="handler">The method to call when a thread becomes available to run the work item.</param>
		/// <param name="priority">The priority of the work item relative to other work items in the thread pool. The value of this parameter can be Low, Normal, or High.</param>
		/// <returns>An IAsyncAction interface that provides access to the work item.</returns>
		public static IAsyncAction RunAsync(WorkItemHandler handler, WorkItemPriority priority)
		{
			return RunAsync(handler);
		}

		/// <summary>
		/// Creates a work item, specifies its priority relative to other work
		/// items in the thread pool, and specifies how long-running work items
		/// should be run.
		/// </summary>
		/// <param name="handler">The method to call when a thread becomes available to run the work item.</param>
		/// <param name="priority">The priority of the work item relative to other work items in the thread pool.</param>
		/// <param name="options">If this parameter is TimeSliced, the work item runs simultaneously with other time-sliced work items with each work item receiving a share of processor time. If this parameter is None, the work item runs when a worker thread becomes available.</param>
		/// <returns>An IAsyncAction interface that provides access to the work item.</returns>
		public static IAsyncAction RunAsync(WorkItemHandler handler, WorkItemPriority priority, WorkItemOptions options)
		{
			if (options == WorkItemOptions.TimeSliced)
				throw new NotImplementedException();
			return RunAsync(handler, priority);
		}

		internal static IAsyncOperation<bool> RunAsyncOperation(Action action)
		{
			return RunAsyncOperation(() => { action(); return true; });
		}

		internal static IAsyncOperation<T> RunAsyncOperation<T>(Func<T> function)
		{
			if (function == null)
				throw new ArgumentException("function");

			var adapter = new TaskToAsyncOperationAdapter<T>(
				Task.Factory.StartNew(function, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default));

			return adapter;
		}

		internal static IAsyncOperationWithProgress<TResult, TProgress> RunAsyncWithProgress<TResult, TProgress>(Func<IProgress<TProgress>, TResult> function)
		{
			if (function == null)
				throw new ArgumentException("function");

			var progress = new Progress<TProgress>();
			return new TaskToAsyncOperationWithProgressAdapter<TResult, TProgress>(
				Task.Factory.StartNew(p => function((IProgress<TProgress>)p), progress, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default),
				progress);
		}
	}
}
