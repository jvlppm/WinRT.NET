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

namespace System.Threading.Tasks.Internal
{
	internal abstract class TaskToAsyncInfoAdapter<TCompletedHandler> : IAsyncInfo
	{
		object locker = new object();
		bool completedInvoked = false;
		TCompletedHandler completed;

		Task task;
		protected Task Task
		{
			get { return task; }
			set
			{
				if (value != null)
				{
					if (value.Status == TaskStatus.Created)
						throw new InvalidOperationException("The specified underlying Task is not started. Task instances must be run immediately upon creation.");

					task = value;
					Status = task.Status.ToAsyncStatus();
					CheckCompletion();
				}
			}
		}
		protected TaskScheduler Scheduler { get; set; }

		protected abstract void Invoke(TCompletedHandler completed);

		protected virtual void Complete()
		{
			bool alreadyInvoked;
			TCompletedHandler handler;
            lock (this.locker)
			{
				handler = completed;
				if (handler == null)
					return;

				completed = default(TCompletedHandler);
				alreadyInvoked = completedInvoked;
				completedInvoked = true;
			}
			if (!alreadyInvoked)
				Task.Factory.StartNew(s => Invoke((TCompletedHandler)s), handler, default(CancellationToken), TaskCreationOptions.None, Scheduler);
		}

		protected TaskToAsyncInfoAdapter()
		{
			Scheduler = TaskScheduler.Current;
		}

		protected TaskToAsyncInfoAdapter(Task source)
			: this()
		{
			if (source == null)
				throw new ArgumentNullException("source");

			Task = source;
		}

		protected void CheckCompletion()
		{
			if (Status == AsyncStatus.Started)
			{
				Task.ContinueWith(t =>
				{
					lock (this.locker)
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

		public TCompletedHandler Completed
		{
			get { return this.completed; }
			set
			{
				if (this.completed != null)
					throw new InvalidOperationException("The 'Completed' handler delegate cannot be set more than once, but this handler has already been set.");

				this.completed = value;
				CheckCompletion();
			}
		}

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
			lock (this.locker)
			{
				if (Status == AsyncStatus.Started)
					Status = AsyncStatus.Canceled;
			}

			CheckCompletion();
		}

		public uint Id { get { return (uint)Task.Id; } }

		public Exception ErrorCode { get { return Task.Exception; } }

		public AsyncStatus Status { get; private set; }

		#endregion
	}
}
