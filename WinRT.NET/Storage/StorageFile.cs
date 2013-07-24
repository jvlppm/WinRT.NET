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
using Windows.Foundation.Metadata;

namespace Windows.Storage
{
	//[Muse]
	//[Static(Windows.Storage.IStorageFileStatics, NTDDI_WIN8)]
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
		public string ContentType { get; private set; }

		/// <summary>
		/// Gets the name of the file including the file name extension.
		/// </summary>
		public string Name { get; private set; }
		#endregion

		#region Methods
		/// <summary>
		/// Opens a random-access stream over the current file for reading file contents.
		/// </summary>
		/// <returns>When this method completes, it returns the random-access stream (type IRandomAccessStreamWithContentType).</returns>
		public IAsyncOperation<IRandomAccessStreamWithContentType> OpenReadAsync()
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
