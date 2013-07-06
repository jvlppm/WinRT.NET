//
// IAsyncOperationWithProgress.cs
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
	[Guid("e85df41d-6aa7-46e3-a8e2-f009d840c627")]
	[Version(WindowsVersion.NTDDI_WIN8)]
	public delegate void AsyncOperationWithProgressCompletedHandler<TResult, TProgress>(IAsyncOperationWithProgress<TResult, TProgress> asyncInfo, AsyncStatus asyncStatus);
	[Guid("55690902-0aab-421a-8778-f8ce5026d758")]
	[Version(WindowsVersion.NTDDI_WIN8)]
	public delegate void AsyncOperationProgressHandler<TResult, TProgress>(IAsyncOperationWithProgress<TResult, TProgress> asyncInfo, TProgress progressInfo);

	[Guid("b5d036d7-e297-498f-ba60-0289e76e23dd")]
	[Version(WindowsVersion.NTDDI_WIN8)]
	public interface IAsyncOperationWithProgress<TResult, TProgress> : IAsyncInfo
	{
		#region Properties

		/// <summary>
		/// Gets or sets the method that handles the operation completed event.
		/// </summary>
		AsyncOperationWithProgressCompletedHandler<TResult, TProgress> Completed { get; set; }

		/// <summary>
		/// Gets or sets the method that handles progress events.
		/// </summary>
		AsyncOperationProgressHandler<TResult, TProgress> Progress { get; set; }

		#endregion

		#region Methods

		/// <summary>
		/// Returns the results of the operation.
		/// </summary>
		/// <returns>The results of the operation.</returns>
		TResult GetResults();

		#endregion
	}
}