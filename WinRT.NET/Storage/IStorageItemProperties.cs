//
// IStorageItemProperties.cs
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

using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.Storage.FileProperties;

namespace Windows.Storage
{
	/// <summary>
	/// Provides access to common and content properties on items (like files and
	/// folders).
	/// </summary>
	[Guid("86664478-8029-46fe-a789-1c2f3e2ffb5c")]
	[Version(WindowsVersion.NTDDI_WIN8)]
	public interface IStorageItemProperties
	{
		#region Properties

		/// <summary>
		/// Gets the user-friendly name of the item.
		/// </summary>
		string DisplayName { get; }

		/// <summary>
		/// Gets the user-friendly type of the item.
		/// </summary>
		string DisplayType { get; }

		/// <summary>
		/// Gets an identifier for the current item. This ID is unique for the
		/// query result or StorageFolder that contains the item and can be used
		/// to distinguish between items that have the same name.
		/// </summary>
		string FolderRelativeId { get; }

		/// <summary>
		/// Gets an object that provides access to the content-related properties
		/// of the item.
		/// </summary>
		StorageItemContentProperties Properties { get; }

		#endregion

		#region Methods

		/// <summary>
		/// Retrieves an adjusted thumbnail image for the item, determined by the
		/// purpose of the thumbnail.
		/// </summary>
		/// <param name="mode">The enum value that describes the purpose of the thumbnail and determines how the thumbnail image is adjusted.</param>
		/// <returns>When this method completes successfully, it returns a StorageItemThumbnail that represents the thumbnail image or null if there is no thumbnail image associated with the item.</returns>
		IAsyncOperation<StorageItemThumbnail> GetThumbnailAsync(ThumbnailMode mode);

		/// <summary>
		/// Retrieves an adjusted thumbnail image for the item, determined by the
		/// purpose of the thumbnail and the requested size.
		/// </summary>
		/// <param name="mode">The enum value that describes the purpose of the thumbnail and determines how the thumbnail image is adjusted.</param>
		/// <param name="requestedSize">The requested size, in pixels, of the longest edge of the thumbnail. Windows uses the requestedSize as a guide and tries to scale the thumbnail image without reducing the quality of the image.</param>
		/// <returns>When this method completes successfully, it returns a StorageItemThumbnail that represents the thumbnail image or null if there is no thumbnail image associated with the item.</returns>
		IAsyncOperation<StorageItemThumbnail> GetThumbnailAsync(ThumbnailMode mode, uint requestedSize);

		/// <summary>
		/// Retrieves an adjusted thumbnail image for the item, determined by the
		/// purpose of the thumbnail, the requested size, and the specified
		/// options.
		/// </summary>
		/// <param name="mode">The enum value that describes the purpose of the thumbnail and determines how the thumbnail image is adjusted.</param>
		/// <param name="requestedSize">The requested size, in pixels, of the longest edge of the thumbnail. Windows uses the requestedSize as a guide and tries to scale the thumbnail image without reducing the quality of the image.</param>
		/// <param name="options">The enum value that describes the desired behavior to use to retrieve the thumbnail image. The specified behavior might affect the size and/or quality of the image and how quickly the thumbnail image is retrieved.</param>
		/// <returns>When this method completes successfully, it returns a StorageItemThumbnail that represents the thumbnail image or null if there is no thumbnail image associated with the item.</returns>
		IAsyncOperation<StorageItemThumbnail> GetThumbnailAsync(ThumbnailMode mode, uint requestedSize, ThumbnailOptions options);

		#endregion
	}
}