//
// IAsyncInfo.cs
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
using Windows.Foundation.Metadata;

namespace Windows.Foundation
{
	[global::System.Runtime.InteropServices.Guid("00000036-0000-0000-c000-000000000046")]
	[Version(WindowsVersion.NTDDI_WIN8)]
	public interface IAsyncInfo
	{
		#region Properties

		/// <summary>
		/// Gets a string that describes an error condition of the asynchronous operation.
		/// </summary>
		Exception ErrorCode { get; }

		/// <summary>
		/// Gets the handle of the asynchronous operation.
		/// </summary>
		uint Id { get; }

		/// <summary>
		/// Gets a value that indicates the status of the asynchronous operation.
		/// </summary>
		AsyncStatus Status { get; }

		#endregion

		#region Methods

		/// <summary>
		/// Cancels the asynchronous operation.
		/// </summary>
		void Cancel();

		/// <summary>
		/// Closes the asynchronous operation.
		/// </summary>
		void Close();

		#endregion
	}

	internal static class AsyncInfo
	{
		public static uint GetNextInfoId()
		{
			long id = Interlocked.Increment (ref infoId);
			if (id == UInt32.MaxValue)
				Interlocked.CompareExchange (ref infoId, 0, id);

			return (uint)id;
		}

		private static long infoId;
	}
}
