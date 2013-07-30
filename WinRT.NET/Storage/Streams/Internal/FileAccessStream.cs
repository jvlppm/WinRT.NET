using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Windows.System.IO.Internal;
using Windows.System.Threading;

namespace Windows.Storage.Streams.Internal
{
	internal class FileAccessStream : IRandomAccessStream
	{
		#region Attributes
		FileInfo fileInfo;
		Stream stream;
		bool disposed;
		#endregion

		public FileAccessStream(FileInfo fileInfo, Stream stream)
		{
			this.fileInfo = fileInfo;
			this.stream = stream;
		}

		~FileAccessStream()
		{
			Dispose(false);
		}

		/// <summary>
		/// Gets a value that indicates whether the stream can be read from.
		/// </summary>
		public bool CanRead
		{
			get { return this.stream.CanRead; }
		}

		/// <summary>
		/// Gets a value that indicates whether the stream can be written to.
		/// </summary>
		public bool CanWrite
		{
			get { return this.stream.CanWrite; }
		}

		/// <summary>
		/// Gets the byte offset of the stream.
		/// </summary>
		public ulong Position
		{
			get { return (ulong)this.stream.Position; }
			private set { this.stream.Position = (long)value; }
		}

		/// <summary>
		/// Gets or sets the size of the random access stream.
		/// </summary>
		public ulong Size
		{
			get { return (ulong)this.fileInfo.Length; }
			set { this.stream.SetLength((long)value); }
		}

		/// <summary>
		/// Creates a new instance of a IRandomAccessStream over the same
		/// resource as the current stream.
		/// </summary>
		/// <returns>The new stream. The initial, internal position of the stream is 0.</returns>
		public IRandomAccessStream CloneStream()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Returns an input stream at a specified location in a stream.
		/// </summary>
		/// <param name="position">The location in the stream at which to begin.</param>
		/// <returns>The input stream.</returns>
		public IInputStream GetInputStreamAt(ulong position)
		{
			var stream = this.fileInfo.OpenRead();
			stream.Position = (long)position;
			return new StreamToInputStreamAdapter(stream);
		}

		/// <summary>
		/// Returns an output stream at a specified location in a stream.
		/// </summary>
		/// <param name="position">The location in the output stream at which to begin.</param>
		/// <returns>The output stream.</returns>
		public IOutputStream GetOutputStreamAt(ulong position)
		{
			var stream = this.fileInfo.OpenWrite();
			stream.Position = (long)position;
			return new StreamToOutputStreamAdapter(stream);
		}

		/// <summary>
		/// Sets the position of the stream to the specified value.
		/// </summary>
		/// <param name="position">The new position of the stream.</param>
		public void Seek(ulong position)
		{
			Position = position;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					if (this.stream != null)
					{
						this.stream.Dispose();
						this.stream = null;
					}
				}

				this.disposed = true;
			}
		}

		public Foundation.IAsyncOperationWithProgress<IBuffer, uint> ReadAsync(IBuffer buffer, uint count, InputStreamOptions options)
		{
			throw new NotImplementedException();
			/*return ThreadPool.RunAsyncWithProgress<IBuffer, uint>(p =>
			{
				return (IBuffer)null;
			});*/
		}

		public Foundation.IAsyncOperation<bool> FlushAsync()
		{
			Func<bool> flushSync = () => {
				this.stream.Flush();
				return true;
			};
			return ThreadPool.RunAsyncOperation(flushSync);
		}

		public Foundation.IAsyncOperationWithProgress<uint, uint> WriteAsync(IBuffer buffer)
		{
			throw new NotImplementedException();
		}
	}
}
