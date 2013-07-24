//
// TaskActionTests.cs
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

using System.Threading;
using NUnit.Framework;
using Windows.Foundation;
using Windows.Foundation.Internal;

namespace WinRTNET.Tests
{
	[TestFixture]
	internal class TaskActionTests
		: IAsyncActionTestsBase<TaskAction>
	{
		protected override TaskAction GetAsync()
		{
			return new TaskAction (() => "do nothing".ToString());
		}

		[Test]
		public void AsyncStatus_Completed_Canceled()
		{
			var action = new TaskAction (() => Thread.Sleep (1000));

			bool completed = false;
			action.Completed = (a, s) =>
			{
				Assert.AreEqual (AsyncStatus.Canceled, s);
				completed = true;
			};

			action.Cancel();

			Assert.IsTrue (SpinWait.SpinUntil(() => completed, 5000));
			Assert.AreEqual (AsyncStatus.Canceled, action.Status);
		}

		[Test]
		public void Completed_Assigned_Twice()
		{
			var action = new TaskAction(() => Thread.Sleep(1000));
			action.Completed = (a, s) => { };
			var ex = Assert.Throws<System.InvalidOperationException>(() =>
			{
				action.Completed = (a, s) => { };
			});

#if NET_4_5
			const int expectedHresult = unchecked((int)0x80000018);
			Assert.AreEqual(ex.HResult, expectedHresult);
#endif
		}
	}
}