//
// StorageFile.cs
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

using Windows.Storage.Streams;
using Windows.Foundation;
using System;
using System.Linq;
using Windows.Foundation.Metadata;
using Windows.Storage.FileProperties;
using System.IO;
using System.Text.RegularExpressions;
using Windows.System.Threading;

namespace Windows.Storage
{
	//[Static(typeof(Windows.Storage.IStorageFileStatics), WindowsVersion.NTDDI_WIN8)]
	[Muse]
	[MarshalingBehavior(MarshalingType.Agile)]
	[Version(WindowsVersion.NTDDI_WIN8)]
	public sealed class StorageFile
		: IStorageFile, IStorageItem,
		  IRandomAccessStreamReference, IInputStreamReference,
		  IStorageItemProperties
	{

		#region Properties

		/// <summary>
		/// Gets the MIME type of the contents of the file.
		/// </summary>
		public string ContentType { get { throw new NotImplementedException(); } }

		/// <summary>
		/// Gets the name of the file including the file name extension.
		/// </summary>
		public string Name { get { return Path.GetFileName(info.FullName); } }

		/// <summary>
		/// Gets a user-friendly name for the file.
		/// </summary>
		public string DisplayName { get { return Path.GetFileNameWithoutExtension(info.FullName); } }

		/// <summary>
		/// Gets a user-friendly description of the type of the file.
		/// </summary>
		public string DisplayType { get { throw new NotImplementedException(); } }

		/// <summary>
		/// Gets an identifier for the file. This ID is unique for the query
		/// result or StorageFolder that contains the file and can be used to
		/// distinguish between items that have the same name.
		/// </summary>
		public string FolderRelativeId { get { throw new NotImplementedException(); } }

		/// <summary>
		/// Gets an object that provides access to the content-related properties
		/// of the file.
		/// </summary>
		public StorageItemContentProperties Properties { get { throw new NotImplementedException(); } }

		#endregion

		#region Methods

		/// <summary>
		/// Opens a random-access stream over the current file for reading file contents.
		/// </summary>
		/// <returns>When this method completes, it returns the random-access stream (type IRandomAccessStreamWithContentType).</returns>
		public IAsyncOperation<IRandomAccessStreamWithContentType> OpenReadAsync()
		{
			return ThreadPool.RunAsyncOperation(() => (IRandomAccessStreamWithContentType)
				new RandomAccessStreamWithContentTypeAdapter(new FileRandomAccessStream(info.OpenRead()), ContentType));
		}

		/// <summary>
		/// Opens a sequential-access stream over the current file for reading
		/// file contents.
		/// </summary>
		/// <returns>When this method completes, it returns the sequential-access stream (type IInputStream).</returns>
		public IAsyncOperation<IInputStream> OpenSequentialReadAsync()
		{
			return ThreadPool.RunAsyncOperation(() => (IInputStream)
				new FileRandomAccessStream(info.OpenRead()));
		}

		/// <summary>
		/// Retrieves an adjusted thumbnail image for the file, determined by the
		/// purpose of the thumbnail.
		/// </summary>
		/// <param name="mode">The enum value that describes the purpose of the thumbnail and determines how the thumbnail image is adjusted.</param>
		/// <returns>When this method completes successfully, it returns a StorageItemThumbnail that represents the thumbnail image or null if there is no thumbnail image associated with the file.</returns>
		public IAsyncOperation<StorageItemThumbnail> GetThumbnailAsync(ThumbnailMode mode)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Retrieves an adjusted thumbnail image for the file, determined by the
		/// purpose of the thumbnail and the requested size.
		/// </summary>
		/// <param name="mode">The enum value that describes the purpose of the thumbnail and determines how the thumbnail image is adjusted.</param>
		/// <param name="requestedSize">The requested size, in pixels, of the longest edge of the thumbnail. Windows uses the requestedSize as a guide and tries to scale the thumbnail image without reducing the quality of the image.</param>
		/// <returns>When this method completes successfully, it returns a StorageItemThumbnail that represents the thumbnail image or null if there is no thumbnail image associated with the file.</returns>
		public IAsyncOperation<StorageItemThumbnail> GetThumbnailAsync(ThumbnailMode mode, uint requestedSize)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Retrieves an adjusted thumbnail image for the file, determined by the
		/// purpose of the thumbnail, the requested size, and the specified
		/// options.
		/// </summary>
		/// <param name="mode">The enum value that describes the purpose of the thumbnail and determines how the thumbnail image is adjusted.</param>
		/// <param name="requestedSize">The requested size, in pixels, of the longest edge of the thumbnail. Windows uses the requestedSize as a guide and tries to scale the thumbnail image without reducing the quality of the image.</param>
		/// <param name="options">The enum value that describes the desired behavior to use to retrieve the thumbnail image. The specified behavior might affect the size and/or quality of the image and how quickly the thumbnail image is retrieved.</param>
		/// <returns>When this method completes successfully, it returns a StorageItemThumbnail that represents the thumbnail image or null if there is no thumbnail image associated with the file.</returns>
		public IAsyncOperation<StorageItemThumbnail> GetThumbnailAsync(ThumbnailMode mode, uint requestedSize, ThumbnailOptions options)
		{
			throw new NotImplementedException();
		}
		#endregion

		#region Internal
		FileInfo info;

		internal StorageFile(FileInfo info)
		{
			this.info = info;
		}
		#endregion
	}
}
