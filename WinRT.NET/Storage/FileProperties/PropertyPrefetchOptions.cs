//
// PropertyPrefetchOptions.cs
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
using Windows.Foundation.Metadata;

namespace Windows.Storage.FileProperties
{
	[Flags]
	[Version(WindowsVersion.NTDDI_WIN8)]
	public enum PropertyPrefetchOptions
	{
		/// <summary>
		/// No specific, system-defined property group.
		/// </summary>
		None = 0,
		/// <summary>
		/// A group of music-related properties that can be access through a MusicProperties object.
		/// </summary>
		MusicProperties = 1,
		/// <summary>
		/// A group of video-related properties that can be access through a VideoProperties object.
		/// </summary>
		VideoProperties = 2,
		/// <summary>
		/// A group of image-related properties that can be access through a ImageProperties object.
		/// </summary>
		ImageProperties = 4,
		/// <summary>
		/// A group of document-related properties that can be access through a DocumentProperties object.
		/// </summary>
		DocumentProperties = 8,
		/// <summary>
		/// A group of basic properties that can be access through a BasicProperties object.
		/// </summary>
		BasicProperties = 16
	}
}