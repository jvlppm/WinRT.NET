//
// IOutputStream.cs
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

using Windows.Foundation;
using Windows.Foundation.Metadata;
using System.Runtime.InteropServices;
using System;

namespace Windows.Storage.Streams
{
	/// <summary>
	/// Represents a sequential stream of bytes to be written.
	/// </summary>
	[Guid("905a0fe6-bc53-11df-8c49-001e4fc686da")]
	[Version(WindowsVersion.NTDDI_WIN8)]
	public interface IOutputStream : IDisposable
	{
		/// <summary>
		/// Flushes data asynchronously in a sequential stream.
		/// </summary>
		/// <returns>The stream flush operation.</returns>
		IAsyncOperation<bool> FlushAsync();

		/// <summary>
		/// Writes data asynchronously in a sequential stream.
		/// </summary>
		/// <param name="buffer">The buffer into which the asynchronous writer operation writes.</param>
		/// <returns>The byte writer operation.</returns>
		IAsyncOperationWithProgress<uint, uint> WriteAsync( IBuffer buffer );
	}
}