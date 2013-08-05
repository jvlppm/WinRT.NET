//
// StorageItemContentProperties.cs
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
using System.Collections.Generic;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.Storage.FileProperties
{
	[Version(WindowsVersion.NTDDI_WIN8)]
	public sealed class StorageItemContentProperties : IStorageItemExtraProperties
	{
		/// <summary>
		/// Retrieves the document properties of the item (like a file of folder).
		/// </summary>
		/// <returns>When this method completes successfully, it returns a documentProperties object.</returns>
		public IAsyncOperation<DocumentProperties> GetDocumentPropertiesAsync()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Retrieves the image properties of the item (like a file of folder).
		/// </summary>
		/// <returns>When this method completes successfully, it returns an imageProperties object.</returns>
		public IAsyncOperation<ImageProperties> GetImagePropertiesAsync()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Retrieves the music properties of the item (like a file of folder).
		/// </summary>
		/// <returns>When this method completes successfully, it returns a musicProperties object.</returns>
		public IAsyncOperation<MusicProperties> GetMusicPropertiesAsync()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Retrieves the video properties of the item (like a file of folder).
		/// </summary>
		/// <returns>When this method completes successfully, it returns a videoProperties object.</returns>
		public IAsyncOperation<VideoProperties> GetVideoPropertiesAsync()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Retrieves the specified properties associated with the item.
		/// </summary>
		/// <param name="propertiesToRetrieve">A collection that contains the names of the properties to retrieve.</param>
		/// <returns>When this method completes successfully, it returns a collection (type IMap) that contains the specified properties and values as key-value pairs.</returns>
		public IAsyncOperation<IDictionary<string, object>> RetrievePropertiesAsync( IEnumerable<string> propertiesToRetrieve )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Saves all properties associated with the item.
		/// </summary>
		/// <returns>No object or value is returned when this method completes.</returns>
		public IAsyncAction SavePropertiesAsync()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Saves the specified properties and values associated with the item.
		/// </summary>
		/// <param name="propertiesToSave">A collection that contains the names and values of the properties to save as key-value pairs (type IKeyValuePair).</param>
		/// <returns>No object or value is returned when this method completes.</returns>
		public IAsyncAction SavePropertiesAsync( IEnumerable<KeyValuePair<string,object>> propertiesToSave )
		{
			throw new NotImplementedException();
		}
	}
}