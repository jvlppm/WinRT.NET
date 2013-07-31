//
// ThreadPoolTests.cs
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
using System.Threading;
using NUnit.Framework;
using Windows.Foundation;
using Windows.System.Threading;
using ThreadPool = Windows.System.Threading.ThreadPool;
using System.Threading.Tasks;

namespace WinRTNET.Tests.Windows.System.Threading
{
	[TestFixture]
	public class ThreadPoolTests
	{
		[Test]
		public void RunAsync_InvalidArgs()
		{
			Assert.Throws<ArgumentException>(() => ThreadPool.RunAsync(null));
		}

		[Test]
		public void RunAsync_Completed()
		{
			bool handlerCompleted = false, actionCompleted = false;

			IAsyncAction action = null;
			action = ThreadPool.RunAsync(a =>
			{
				Assert.AreEqual(AsyncStatus.Started, a.Status);
				handlerCompleted = true;
			});

			action.Completed = (a, s) =>
			{
				Assert.AreEqual(AsyncStatus.Completed, s);
				actionCompleted = true;
			};

			Assert.IsTrue(SpinWait.SpinUntil(() => handlerCompleted && actionCompleted, millisecondsTimeout: 5000));
			Assert.AreEqual(AsyncStatus.Completed, action.Status);
			Assert.IsNull(action.ErrorCode);
		}

		[Test]
		public void RunAsync_Cancel()
		{
			bool canComplete = false;

			IAsyncAction action = null;
			action = ThreadPool.RunAsync(a =>
			{
				while (!canComplete)
					Thread.Sleep(10);
			});

			var tcs = new TaskCompletionSource<AsyncStatus>();
			action.Completed = (a, s) =>
			{
				tcs.SetResult(s);
			};

			action.Cancel();
			Thread.Sleep(100);
			Assert.AreEqual(AsyncStatus.Canceled, action.Status);
			canComplete = true;

			Assert.IsTrue(SpinWait.SpinUntil(() => tcs.Task.IsCompleted, millisecondsTimeout: 400), "Task did not complete under 400ms.");
			Assert.AreEqual(AsyncStatus.Canceled, action.Status, "Task should not change status after cancel");
		}

		[Test]
		public void RunAsync_CancelDuringExecution()
		{
			IAsyncAction action = null;
			action = ThreadPool.RunAsync(a =>
			{
				Thread.Sleep(2000);
			});

			var tcs = new TaskCompletionSource<AsyncStatus>();
			action.Completed = (a, s) =>
			{
				tcs.SetResult(s);
			};

			action.Cancel();
			Thread.Sleep(100);
			Assert.AreEqual(AsyncStatus.Canceled, action.Status);
			Assert.IsNull(action.ErrorCode);
		}

		[Test]
		public void RunAsync_CancelAfterCompletion()
		{
			long completedCount = 0;
			IAsyncAction action = null;
			action = ThreadPool.RunAsync(a =>
			{
				Thread.Sleep(50);
			});

			var tcs = new TaskCompletionSource<AsyncStatus>();
			action.Completed = (a, s) =>
			{
				Interlocked.Increment(ref completedCount);
				tcs.SetResult(s);
			};

			Assert.IsTrue(SpinWait.SpinUntil(() => tcs.Task.IsCompleted, 200));
			action.Cancel();

			Thread.Sleep(100);
			Assert.AreEqual(1, Interlocked.Read(ref completedCount));

			Assert.AreEqual(AsyncStatus.Completed, action.Status);
		}

		[Test]
		public void RunAsync_Error()
		{
			IAsyncAction action = null;
			action = ThreadPool.RunAsync(a =>
			{
				throw new Exception("error");
			});

			var tcs = new TaskCompletionSource<AsyncStatus>();
			action.Completed = (a, s) =>
			{
				tcs.SetResult(s);
			};

			Assert.IsTrue(SpinWait.SpinUntil(() => tcs.Task.IsCompleted, 100));

			// WinRT does not ignores errors in thread pool actions
			Assert.AreEqual(AsyncStatus.Error, action.Status);
			Assert.IsNotNull(action.ErrorCode);
		}

		[Test]
		public void Completed_Assigned_Twice()
		{
			var action = ThreadPool.RunAsync(s => Thread.Sleep(1000));
			action.Completed = (a, s) => { };
			var ex = Assert.Throws<InvalidOperationException>(() =>
			{
				action.Completed = (a, s) => { };
			});

#if NET_4_5
			const int expectedHresult = unchecked((int)0x80000018);
			Assert.AreEqual(expectedHresult, ex.HResult);
#endif
		}

		[Test]
		public void Completed_Assigned_Null()
		{
			var action = ThreadPool.RunAsync(s => Thread.Sleep(1000));

			// WinRT throws a NullReferenceException when the Completed handler is set to null.
			// this happens even if the IAsyncAction is still running.
			var ex = Assert.Throws<NullReferenceException>(() =>
			{
				action.Completed = null;
			});

#if NET_4_5
			const int expectedHresult = unchecked((int)0x80004003);
			Assert.AreEqual(expectedHresult, ex.HResult);
#endif
		}
	}
}