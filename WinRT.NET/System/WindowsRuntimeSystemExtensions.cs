//
// WindowsRuntimeSystemExtensions.cs
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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace System
{
	public static class WindowsRuntimeSystemExtensions
	{
		internal static AsyncStatus ToAsyncStatus(this TaskStatus status)
		{
			switch (status)
			{
				case TaskStatus.Canceled:
					return AsyncStatus.Canceled;

				case TaskStatus.Faulted:
					return AsyncStatus.Error;

				case TaskStatus.RanToCompletion:
					return AsyncStatus.Completed;

				case TaskStatus.WaitingToRun:
				case TaskStatus.WaitingForChildrenToComplete:
				case TaskStatus.WaitingForActivation:
				case TaskStatus.Running:
					return AsyncStatus.Started;

				default:
					throw new InvalidOperationException("TaskStatus." + status + " does not have a corresponding AsyncStatus");
			}
		}

		/// <summary>
		/// Returns a task that represents a Windows Runtime asynchronous action.
		/// </summary>
		/// <param name="source">The asynchronous action.</param>
		public static Task AsTask(this IAsyncAction source)
		{
			if (source == null)
				throw new ArgumentNullException("source");

			var tcs = new TaskCompletionSource<bool>();
			source.Completed += (s) => {
				try
				{
					if (s.Status == AsyncStatus.Canceled)
						tcs.SetCanceled();
					else if (s.Status == AsyncStatus.Error)
						tcs.SetException(s.ErrorCode);
					else
					{
						s.GetResults();
						tcs.SetResult(true);
					}
				}
				catch (Exception ex)
				{
					tcs.SetException(ex);
				}
			};

			return tcs.Task;
		}

		/// <summary>
		/// Returns a task that represents a Windows Runtime asynchronous operation returns a result.
		/// </summary>
		/// <param name="source">The asynchronous operation.</param>
		/// <typeparam name="TResult">The type of object that returns the result of the asynchronous operation.</typeparam>
		/// <returns>A task that represents the asynchronous operation.</returns>
		public static Task<TResult> AsTask<TResult>(this IAsyncOperation<TResult> source)
		{
			if (source == null)
				throw new ArgumentNullException("source");

			var tcs = new TaskCompletionSource<TResult>();
			AsyncOperationCompletedHandler<TResult> completed = null;
			completed = s => {
				try
				{
					if (s.Status == AsyncStatus.Canceled)
						tcs.TrySetCanceled();
					else if (s.Status == AsyncStatus.Error)
						tcs.TrySetException(s.ErrorCode);
					else
					{
						var res = s.GetResults();
						tcs.TrySetResult(res);
					}
				}
				catch (Exception ex)
				{
					tcs.TrySetException(ex);
				}
				source.Completed -= completed;
			};

			source.Completed += completed;

			if (source.Status == AsyncStatus.Completed)
				completed(source);

			return tcs.Task;
		}

		/// <summary>
		/// Returns a Windows Runtime asynchronous operation that represents a started task that returns a result.
		/// </summary>
		/// <returns>A Windows.Foundation.IAsyncOperation&lt;TResult&gt; instance that represents the started task.</returns>
		/// <param name="source">The started task.</param>
		/// <typeparam name="TResult">The type that returns the result.</typeparam>
		public static IAsyncOperation<TResult> AsAsyncOperation<TResult>(this Task<TResult> source)
		{
			return new TaskToAsyncOperationAdapter<TResult>(source);
		}

		/// <summary>
		/// Returns a Windows Runtime asynchronous action that represents a started task.
		/// </summary>
		/// <returns>A Windows.Foundation.IAsyncAction instance that represents the started task.</returns>
		/// <param name="source">The started task.</param>
		public static IAsyncAction AsAsyncAction(this Task source)
		{
			return new TaskToAsyncActionAdapter(source);
		}

#if NET_4_5
		/// <summary>
		/// Returns an object that awaits an asynchronous operation that returns a result.
		/// </summary>
		/// <param name="source">The asynchronous operation to await.</param>
		/// <typeparam name="TResult">The type of object that returns the result of the asynchronous operation.</typeparam>
		/// <returns>An object that awaits the specified asynchronous operation.</returns>
		public static TaskAwaiter<TResult> GetAwaiter<TResult>(this IAsyncOperation<TResult> source)
		{
			throw new NotImplementedException();
		}
#endif
	}
}