//
// IAsyncActionWithProgress.cs
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

using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

namespace Windows.Foundation
{
	[Guid("9c029f91-cc84-44fd-ac26-0a6c4e555281")]
	[Version(WindowsVersion.NTDDI_WIN8)]
	public delegate void AsyncActionWithProgressCompletedHandler<TProgress>(IAsyncActionWithProgress<TProgress> asyncInfo, AsyncStatus asyncStatus);

	[Guid("6d844858-0cff-4590-ae89-95a5a5c8b4b8")]
	[Version(WindowsVersion.NTDDI_WIN8)]
	public delegate void AsyncActionProgressHandler<TProgress>(IAsyncActionWithProgress<TProgress> asyncInfo, TProgress progressInfo);

	[Guid("1f6db258-e803-48a1-9546-eb7353398884")]
	[Version(WindowsVersion.NTDDI_WIN8)]
	public interface IAsyncActionWithProgress<TProgress> : IAsyncInfo
	{
		#region Properties

		/// <summary>
		/// Gets or sets the method that handles the action completed event.
		/// </summary>
		AsyncActionWithProgressCompletedHandler<TProgress> Completed { get; set; }

		/// <summary>
		/// Gets or sets the method that receives progress events.
		/// </summary>
		AsyncActionProgressHandler<TProgress> Progress { get; set; }

		#endregion

		#region Methods

		/// <summary>
		/// Returns the results of the action.
		/// </summary>
		void GetResults();

		#endregion
	}
}