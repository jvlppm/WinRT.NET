//
// ThumbnailMode.cs
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

using Windows.Foundation.Metadata;

namespace Windows.Storage.FileProperties
{
	[Version(WindowsVersion.NTDDI_WIN8)]
	public enum ThumbnailMode
	{
		/// <summary>
		/// To display previews of picture files. Default, preferred size: Medium, preferably at least 190 pixels (if the image size is 190 x 130) Aspect ratio: Uniform, wide aspect ratio of about .7 (190 x 130 if the preferred size is 190)
		/// </summary>
		PicturesView,
		/// <summary>
		/// To display previews of video files. Default, preferred size: Medium, preferably at least 190 pixels (if the video size is 190 x 130) Aspect ratio: Uniform, wide aspect ratio of about .7 (190 x 130 if the requested size is 190)
		/// </summary>
		VideosView,
		/// <summary>
		/// To display previews of music files. Default, preferred size: Small, preferably at least 40 x 40 pixels Aspect ratio: Uniform, square aspect ratio
		/// </summary>
		MusicView,
		/// <summary>
		/// To display previews of document files. Default, preferred size: Small, preferably at least 40 x 40 pixels Aspect ratio: Uniform, square aspect ratio
		/// </summary>
		DocumentsView,
		/// <summary>
		/// To display previews of files (or other items) in a list. Default, preferred size: Small, preferably at least 40 x 40 pixels Aspect ratio: Uniform, square aspect ratio
		/// </summary>
		ListView,
		/// <summary>
		/// To display a preview of any single item (like a file, folder, or file group). Default, preferred size: Large, at least 256 pixels on the longest side Aspect ratio: Variable, uses the original aspect ratio of the file
		/// </summary>
		SingleItem
	}
}