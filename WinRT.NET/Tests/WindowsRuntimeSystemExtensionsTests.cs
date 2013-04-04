//
// WindowsRuntimeSystemExtensionsTests.cs
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
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Windows.Foundation;

namespace WinRTNET.Tests
{
	[TestFixture]
	public class WindowsRuntimeSystemExtensionsTests
	{
		[Test]
		public void IAsyncAction_AsTask_StartStatus()
		{
			var action = new MockAsyncAction();
			Task t = action.AsTask();

			Assert.AreEqual (TaskStatus.WaitingForActivation, t.Status);
			Assert.AreEqual (AsyncStatus.Started, action.Status);
		}

		[Test]
		public void IAsyncAction_AsTask_Canceled()
		{
			var action = new MockAsyncAction();
			Task t = action.AsTask();

			action.Cancel();

			Assert.Throws<AggregateException>(t.Wait);
			Assert.AreEqual (TaskStatus.Canceled, t.Status);
		}

		[Test]
		public void IAsyncAction_AsTask_Completed()
		{
			var action = new MockAsyncAction();
			Task t = action.AsTask();

			action.Status = AsyncStatus.Completed;
			action.Completed (action);

			Assert.AreEqual (TaskStatus.RanToCompletion, t.Status);
		}

		[Test]
		public void IAsyncAction_AsTask_Error()
		{
			var error = new Exception ("error");
			var action = new MockAsyncAction();
			Task t = action.AsTask();

			action.ErrorCode = error;
			action.Status = AsyncStatus.Error;
			action.Completed (action);

			Assert.IsTrue (t.IsFaulted);
			Assert.AreSame (error, t.Exception.InnerExceptions.First());
			Assert.Throws<AggregateException>(t.Wait);
		}

		[Test]
		public void IAsyncOperation_AsTask_Null()
		{
			Assert.Throws<ArgumentNullException> (() => WindowsRuntimeSystemExtensions.AsTask ((IAsyncOperation<string>)null));
		}

		[Test]
		public void IAsyncOperation_AsTask_StartStatus()
		{
			var operation = new MockAsyncOperation<bool>();
			Task<bool> t = operation.AsTask();

			Assert.AreEqual (TaskStatus.WaitingForActivation, t.Status);
			Assert.AreEqual (AsyncStatus.Started, operation.Status);
		}

		[Test]
		public void IAsyncOperation_AsTask_Canceled()
		{
			var action = new MockAsyncOperation<bool>();
			Task<bool> t = action.AsTask();

			action.Cancel();

			Assert.Throws<AggregateException>(t.Wait);
			Assert.AreEqual (TaskStatus.Canceled, t.Status);
		}

		[Test]
		public void IAsyncOperation_AsTask_Completed()
		{
			var operation = new MockAsyncOperation<bool>();
			Task<bool> t = operation.AsTask();

			operation.Result = true;
			operation.Status = AsyncStatus.Completed;
			operation.Completed (operation);

			Assert.AreEqual (TaskStatus.RanToCompletion, t.Status);
			Assert.AreEqual (true, t.Result);
		}

		[Test]
		public void IAsyncOperation_AsTask_Error()
		{
			var error = new Exception("error");
			var operation = new MockAsyncOperation<bool>();
			Task<bool> t = operation.AsTask();

			operation.ErrorCode = error;
			operation.Status = AsyncStatus.Error;
			operation.Completed (operation);

			Assert.IsTrue (t.IsFaulted);
			Assert.AreSame (error, t.Exception.InnerExceptions.First());
			Assert.Throws<AggregateException>(t.Wait);
		}
	}
}