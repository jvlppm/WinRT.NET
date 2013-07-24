﻿//
// StreamToInputStreamAdapter.cs
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
using System.IO;
using Windows.Foundation;
using Windows.Storage.Streams;

namespace Windows.System.IO.Internal
{
	internal class StreamToInputStreamAdapter
		: IInputStream
	{
		private Stream stream;
		private bool disposed;

		internal StreamToInputStreamAdapter (Stream stream)
		{
			this.stream = stream;
		}

		~StreamToInputStreamAdapter()
		{
			Dispose(false);
		}

		public IAsyncOperationWithProgress<IBuffer, uint> ReadAsync (IBuffer buffer, uint count, InputStreamOptions options)
		{
			if (disposed)
				throw new ObjectDisposedException(GetType().FullName);

			throw new NotImplementedException();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					this.stream.Dispose();
					this.stream = null;
				}
				disposed = true;
			}
			stream.Dispose();
		}
	}
}
