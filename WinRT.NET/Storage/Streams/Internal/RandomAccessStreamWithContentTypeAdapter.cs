//
// RandomAccessStreamWithContentTypeAdapter.cs
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
using Windows.Storage.Streams;

namespace Windows
{
	internal class RandomAccessStreamWithContentTypeAdapter : IRandomAccessStreamWithContentType
	{
		IRandomAccessStream stream;
		string contentType;

		public RandomAccessStreamWithContentTypeAdapter (IRandomAccessStream stream, string contentType)
		{
			this.stream = stream;
			ContentType = contentType;
		}
		#region IRandomAccessStream implementation
		public IRandomAccessStream CloneStream ()
		{
			return stream.CloneStream ();
		}

		public IInputStream GetInputStreamAt (ulong position)
		{
			return stream.GetInputStreamAt (position);
		}

		public IOutputStream GetOutputStreamAt (ulong position)
		{
			return stream.GetOutputStreamAt (position);
		}

		public void Seek (ulong position)
		{
			stream.Seek (position);
		}

		public bool CanRead { get { return stream.CanRead; } }

		public bool CanWrite { get { return stream.CanWrite; } }

		public ulong Position { get { return stream.Position; } }

		public ulong Size {
			get { return stream.Size; }
			set { stream.Size = value; }
		}
		#endregion
		#region IOutputStream implementation
		public Windows.Foundation.IAsyncOperation<bool> FlushAsync ()
		{
			return stream.FlushAsync ();
		}

		public Windows.Foundation.IAsyncOperationWithProgress<uint, uint> WriteAsync (IBuffer buffer)
		{
			return stream.WriteAsync (buffer);
		}
		#endregion
		#region IInputStream implementation
		public Windows.Foundation.IAsyncOperationWithProgress<IBuffer, uint> ReadAsync (IBuffer buffer, uint count, InputStreamOptions options)
		{
			return stream.ReadAsync (buffer, count, options);
		}
		#endregion
		#region IDisposable implementation
		public void Dispose ()
		{
			stream.Dispose ();
		}
		#endregion

		#region IContentTypeProvider implementation
		public string ContentType { get; private set; }
		#endregion
	}
}

