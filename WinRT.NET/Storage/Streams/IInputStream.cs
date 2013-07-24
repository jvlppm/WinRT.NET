//
// IInputStream.cs
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
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.Storage.Streams
{
	/// <summary>
	/// Represents a sequential stream of bytes to be read.
	/// </summary>
	[Guid("905a0fe2-bc53-11df-8c49-001e4fc686da")]
	[Version(WindowsVersion.NTDDI_WIN8)]
	public interface IInputStream : IDisposable
	{
		/// <summary>
		/// Returns an asynchronous byte reader object.
		/// </summary>
		/// <param name="buffer">The buffer into which the asynchronous read operation places the bytes that are read.</param>
		/// <param name="count">The number of bytes to read that is less than or equal to the Capacity value.</param>
		/// <param name="options">Specifies the type of the asynchronous read operation.</param>
		/// <returns>The asynchronous operation.</returns>
		IAsyncOperationWithProgress<IBuffer, uint> ReadAsync(IBuffer buffer, uint count, InputStreamOptions options);
	}
}