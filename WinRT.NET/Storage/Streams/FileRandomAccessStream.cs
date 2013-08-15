//
// FileRandomAccessStream.cs
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
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.System.IO.Internal;
using Windows.System.Threading;

namespace Windows.Storage.Streams
{
	/// <summary>
	/// Supports reading and writing to a file at a specified position.
	/// </summary>
	[MarshalingBehavior(MarshalingType.Agile)]
	[Version(WindowsVersion.NTDDI_WIN8)]
	public sealed class FileRandomAccessStream : IRandomAccessStream, IDisposable, IInputStream, IOutputStream
	{
		#region Properties

		/// <summary>
		/// Gets a value that indicates whether the stream can be read from.
		/// </summary>
		public bool CanRead { get { return this.baseStream.CanRead; } }

		/// <summary>
		/// Gets a value that indicates whether the file can be written to.
		/// </summary>
		public bool CanWrite { get { return this.baseStream.CanWrite; } }

		/// <summary>
		/// Gets the byte offset of the stream.
		/// </summary>
		public ulong Position { get { return (ulong)this.baseStream.Position; } }

		/// <summary>
		/// Gets or sets the size of the random access stream.
		/// </summary>
		public ulong Size
		{
			get { return (ulong)this.baseStream.Length; }
			set { this.baseStream.SetLength((long)value); }
		}

		#endregion

		#region Methods

		/// <summary>
		/// Creates a new instance of a IRandomAccessStream over the same
		/// resource as the current stream.
		/// </summary>
		/// <returns>The new stream. The initial, internal position of the stream is 0.</returns>
		public IRandomAccessStream CloneStream()
		{
			var access = (CanRead ? FileAccess.Read : 0) | (CanWrite ? FileAccess.Write : 0);
			return new FileRandomAccessStream(new FileStream(this.baseStream.SafeFileHandle, access));
		}

		/// <summary>
		/// Performs tasks associated with freeing, releasing, or resetting
		/// unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Flushes data asynchronously in a sequential stream.
		/// </summary>
		/// <returns>The stream flush operation.</returns>
		public IAsyncOperation<bool> FlushAsync()
		{
			return ThreadPool.RunAsyncOperation(() => this.baseStream.Flush(flushToDisk: true));
		}

		/// <summary>
		/// Returns an input stream at a specified location in a stream.
		/// </summary>
		/// <param name="position">The location in the stream at which to begin.</param>
		/// <returns>The input stream.</returns>
		public IInputStream GetInputStreamAt(ulong position)
		{
			if (!CanRead)
				throw new UnauthorizedAccessException();

			var stream = (FileRandomAccessStream)CloneStream();
			stream.Seek(position);
			return new StreamToInputStreamAdapter(stream.baseStream);
		}

		/// <summary>
		/// Returns an output stream at a specified location in a stream.
		/// </summary>
		/// <param name="position">The location in the output stream at which to begin.</param>
		/// <returns>The output stream.</returns>
		public IOutputStream GetOutputStreamAt(ulong position)
		{
			if (!CanWrite)
				throw new UnauthorizedAccessException();

			var stream = (FileRandomAccessStream)CloneStream();
			stream.Seek(position);
			return new StreamToOutputStreamAdapter(stream.baseStream);
		}

		/// <summary>
		/// Returns an asynchronous byte reader object.
		/// </summary>
		/// <param name="buffer">The buffer into which the asynchronous read operation places the bytes that are read.</param>
		/// <param name="count">The number of bytes to read that is less than or equal to the Capacity value.</param>
		/// <param name="options">Specifies the type of the asynchronous read operation.</param>
		/// <returns>The asynchronous operation.</returns>
		public IAsyncOperationWithProgress<IBuffer, uint> ReadAsync(IBuffer buffer, uint count, InputStreamOptions options)
		{
			return ThreadPool.RunAsyncWithProgress<IBuffer, uint>(p =>
			{
				var data = new byte[count];
				this.baseStream.Read(data, 0, (int)count);
				return data.AsBuffer();
			});
		}

		/// <summary>
		/// Sets the position of the stream to the specified value.
		/// </summary>
		/// <param name="position">The new position of the stream.</param>
		public void Seek(ulong position)
		{
			this.baseStream.Seek((long)position, SeekOrigin.Begin);
		}

		/// <summary>
		/// Writes data asynchronously to a file.
		/// </summary>
		/// <param name="buffer">The buffer into which the asynchronous writer operation writes.</param>
		/// <returns>The byte writer operation.</returns>
		public IAsyncOperationWithProgress<uint, uint> WriteAsync(IBuffer buffer)
		{
			return ThreadPool.RunAsyncWithProgress<uint, uint>(p =>
			{
				buffer.AsStream().CopyTo(this.baseStream);
				return buffer.Length;
			});
		}

		#endregion

		#region Internal
		FileStream baseStream;
		bool disposed;

		internal FileRandomAccessStream(FileStream stream)
		{
			this.baseStream = stream;
		}

		~FileRandomAccessStream()
		{
			Dispose(false);
		}

		void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					if (this.baseStream != null)
					{
						this.baseStream.Dispose();
						this.baseStream = null;
					}
				}

				this.disposed = true;
			}
		}
		#endregion
	}
}