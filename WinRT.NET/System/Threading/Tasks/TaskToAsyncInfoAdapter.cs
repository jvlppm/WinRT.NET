//
// TaskToAsyncInfoAdapter.cs
//
// Author:
//   Joao Vitor P. Moraes <jvlppm@gmail.com>
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
using System.Threading.Tasks;

namespace System.Threading.Tasks
{
	class TaskToAsyncInfoAdapter<TCompletedHandler> : IAsyncInfo
	{
		protected Task Task { get; set; }

		protected virtual void Complete()
		{
		}

		public TaskToAsyncInfoAdapter(Task task)
		{
			if (task.Status == TaskStatus.Created)
				throw new InvalidOperationException("The specified underlying Task is not started. Task instances must be run immediately upon creation.");

			Task = task;
			Status = Task.Status.ToAsyncStatus();
		}

		protected void CheckCompletion()
		{
			if (Status == AsyncStatus.Started)
			{
				var updateStatus = Task.ContinueWith(t =>
				{
					lock (this)
					{
						if (Status == AsyncStatus.Started)
							Status = t.Status.ToAsyncStatus();
					}

					Complete();
				});
			}
			else
				Complete();
		}

		#region IAsyncOperation implementation

		public void GetResults()
		{
			if (Status == AsyncStatus.Error)
				throw ErrorCode;

			if (Status != AsyncStatus.Completed)
				throw new InvalidOperationException("Cannot call GetResults on this asynchronous info because the underlying operation has not completed.");
		}

		public TCompletedHandler Completed { get; set; }

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

