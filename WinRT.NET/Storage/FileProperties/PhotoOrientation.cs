//
// PhotoOrientation.cs
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

namespace Windows.Storage.FileProperties
{
	/// <summary>
	/// Indicates the Exchangeable Image File (EXIF) orientation flag of the
	/// photo. This flag describes how to rotate the photo to display it
	/// correctly.
	/// </summary>	[Version(WindowsVersion.NTDDI_WIN8)]
	public enum PhotoOrientation
	{
		/// <summary>
		/// An orientation flag is not set.
		/// </summary>
		Unspecified,
		/// <summary>
		/// No rotation needed. The photo can be displayed using its current orientation.
		/// </summary>
		Normal,
		/// <summary>
		/// Flip the photo horizontally.
		/// </summary>
		FlipHorizontal,
		/// <summary>
		/// Rotate the photo counter-clockwise 180 degrees.
		/// </summary>
		Rotate180,
		/// <summary>
		/// Flip the photo vertically.
		/// </summary>
		FlipVertical,
		/// <summary>
		/// Rotate the photo counter-clockwise 90 degrees and then flip it horizontally.
		/// </summary>
		Transpose,
		/// <summary>
		/// Rotate the photo counter-clockwise 270 degrees.
		/// </summary>
		Rotate270,
		/// <summary>
		/// Rotate the photo counter-clockwise 270 degrees and then flip it horizontally.
		/// </summary>
		Transverse,
		/// <summary>
		/// Rotate the photo 90 degrees.
		/// </summary>
		Rotate90
	}
}