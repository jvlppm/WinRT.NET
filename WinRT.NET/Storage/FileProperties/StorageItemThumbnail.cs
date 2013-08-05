//
// StorageItemThumbnail.cs
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
using Windows.Foundation.Metadata;
using Windows.Storage.Streams;

namespace Windows.Storage.FileProperties
{
	/// <summary>
	/// [This documentation is preliminary and is subject to change.]
	/// Represents the thumbnail image associated with a system resource (like a
	/// file or folder).
	/// </summary>
	[Version(WindowsVersion.NTDDI_WIN8)]
	public sealed class StorageItemThumbnail : IRandomAccessStreamWithContentType, IRandomAccessStream, IDisposable, IInputStream, IOutputStream, IContentTypeProvider
	{
		#region Properties

		/// <summary>
		/// Gets a value that indicates whether the thumbnail stream can be read
		/// from.
		/// </summary>
		public bool CanRead { get; private set; }

		/// <summary>
		/// Gets a value that indicates whether the thumbnail stream can be
		/// written to.
		/// </summary>
		public bool CanWrite { get; private set; }

		/// <summary>
		/// Gets the MIME content type of the thumbnail image.
		/// </summary>
		public string ContentType { get; private set; }

		/// <summary>
		/// Gets the original (not scaled) height of the thumbnail image.
		/// </summary>
		public uint OriginalHeight { get; private set; }

		/// <summary>
		/// Gets the original (not scaled) width of the thumbnail image.
		/// </summary>
		public uint OriginalWidth { get; private set; }

		/// <summary>
		/// Gets the byte offset of the thumbnail stream.
		/// </summary>
		public ulong Position { get; private set; }

		/// <summary>
		/// Gets a value that indicates whether the thumbnail image returned was
		/// a cached version with a smaller size.
		/// </summary>
		public bool ReturnedSmallerCachedSize { get; private set; }

		/// <summary>
		/// Gets or sets the size of the thumbnail image.
		/// </summary>
		public ulong Size { get; set; }

		/// <summary>
		/// Gets a value that indicates if the thumbnail is an icon or an image.
		/// </summary>
		public ThumbnailType Type { get; private set; }

		#endregion

		#region Methods

		/// <summary>
		/// Creates a new stream  over the thumbnail that is represented by the
		/// current storageItemThumbnail object.
		/// </summary>
		/// <returns>The new thumbnail stream. The initial, internal position of the stream is 0.</returns>
		public IRandomAccessStream CloneStream()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Performs tasks associated with freeing, releasing, or resetting
		/// unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Flushes data asynchronously in a sequential stream.
		/// </summary>
		/// <returns>The stream flush operation.</returns>
		public IAsyncOperation<bool> FlushAsync()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Retrieves the thumbnail image data as an undecoded stream.
		/// </summary>
		/// <param name="position">The position in the storage item to start reading thumbnail image data.</param>
		/// <returns>An object for reading the thumbnail image data.</returns>
		public IInputStream GetInputStreamAt( ulong position )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Retrieves an output  stream object for writing  thumbnail image data
		/// to a storage item.
		/// </summary>
		/// <param name="position">The position in the storage item to start writing thumbnail image data.</param>
		/// <returns>The output stream.</returns>
		public IOutputStream GetOutputStreamAt( ulong position )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Returns an asynchronous byte reader object.
		/// </summary>
		/// <param name="buffer">The buffer into which the asynchronous read operation places the bytes that are read.</param>
		/// <param name="count">The number of bytes to read that is less than or equal to the Capacity value.</param>
		/// <param name="options">Specifies the type of the asynchronous read operation.</param>
		/// <returns>The asynchronous operation.</returns>
		public IAsyncOperationWithProgress<IBuffer, UInt32> ReadAsync( IBuffer buffer, uint count, InputStreamOptions options )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Sets the offset of the thumbnail stream  to the specified value.
		/// </summary>
		/// <param name="position">The number of bytes from the start of the thumbnail stream where the position of the thumbnail stream is set.</param>
		public void Seek( ulong position )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Writes data asynchronously in a sequential stream.
		/// </summary>
		/// <param name="buffer">The buffer into which the asynchronous writer operation writes.</param>
		/// <returns>The byte writer operation.</returns>
		public IAsyncOperationWithProgress<UInt32, UInt32> WriteAsync( IBuffer buffer )
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}