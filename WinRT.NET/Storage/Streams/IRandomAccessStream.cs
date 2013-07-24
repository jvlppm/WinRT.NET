//
// IRandomAccessStream.cs
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
using Windows.Foundation.Metadata;

namespace Windows.Storage.Streams
{
	/// <summary>
	/// Supports random access of data in input and output streams.
	/// </summary>
	[Guid("905a0fe1-bc53-11df-8c49-001e4fc686da")]
	[Version(WindowsVersion.NTDDI_WIN8)]
	public interface IRandomAccessStream : IDisposable, IInputStream, IOutputStream
	{
		#region Properties

		/// <summary>
		/// Gets a value that indicates whether the stream can be read from.
		/// </summary>
		bool CanRead { get; }

		/// <summary>
		/// Gets a value that indicates whether the stream can be written to.
		/// </summary>
		bool CanWrite { get; }

		/// <summary>
		/// Gets the byte offset of the stream.
		/// </summary>
		ulong Position { get; }

		/// <summary>
		/// Gets or sets the size of the random access stream.
		/// </summary>
		ulong Size { get; set; }

		#endregion

		#region Methods

		/// <summary>
		/// Creates a new instance of a IRandomAccessStream over the same
		/// resource as the current stream.
		/// </summary>
		/// <returns>The new stream. The initial, internal position of the stream is 0.</returns>
		IRandomAccessStream CloneStream();

		/// <summary>
		/// Returns an input stream at a specified location in a stream.
		/// </summary>
		/// <param name="position">The location in the stream at which to begin.</param>
		/// <returns>The input stream.</returns>
		IInputStream GetInputStreamAt(ulong position);

		/// <summary>
		/// Returns an output stream at a specified location in a stream.
		/// </summary>
		/// <param name="position">The location in the output stream at which to begin.</param>
		/// <returns>The output stream.</returns>
		IOutputStream GetOutputStreamAt(ulong position);

		/// <summary>
		/// Sets the position of the stream to the specified value.
		/// </summary>
		/// <param name="position">The new position of the stream.</param>
		void Seek(ulong position);

		#endregion
	}
}
