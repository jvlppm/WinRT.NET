//
// VideoProperties.cs
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
	/// <summary>
	/// [This documentation is preliminary and is subject to change.]
	/// Provides access to the video-related properties of an item (like a file
	/// or folder).
	/// </summary>
	[Version(WindowsVersion.NTDDI_WIN8)]
	public sealed class VideoProperties : IStorageItemExtraProperties
	{
		#region Properties

		/// <summary>
		/// Gets the sum audio and video bitrate of the video.
		/// </summary>
		public uint Bitrate { get; private set; }

		/// <summary>
		/// Gets the directors of the video.
		/// </summary>
		public IList<string> Directors { get; private set; }

		/// <summary>
		/// Gets the duration of the video.
		/// </summary>
		public TimeSpan Duration { get; private set; }

		/// <summary>
		/// Gets the height of the video.
		/// </summary>
		public uint Height { get; private set; }

		/// <summary>
		/// Gets the collection of keywords associated with the video.
		/// </summary>
		public IList<string> Keywords { get; private set; }

		/// <summary>
		/// Gets the latitude coordinate where the video was shot.
		/// </summary>
		public Nullable<double> Latitude { get; private set; }

		/// <summary>
		/// Gets the longitude coordinate where the video was shot.
		/// </summary>
		public Nullable<double> Longitude { get; private set; }

		/// <summary>
		/// Gets a VideoOrientation value that indicates how the video should be
		/// rotated to display it correctly.
		/// </summary>
		public VideoOrientation Orientation { get; private set; }

		/// <summary>
		/// Gets the producers of the video.
		/// </summary>
		public IList<string> Producers { get; private set; }

		/// <summary>
		/// Gets or sets the publisher of the video.
		/// </summary>
		public string Publisher { get; set; }

		/// <summary>
		/// Gets the rating associated with the video.
		/// </summary>
		public uint Rating { get; set; }

		/// <summary>
		/// Gets or sets the subtitle of the video.
		/// </summary>
		public string Subtitle { get; set; }

		/// <summary>
		/// Gets or sets the title of the video.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Gets the width of the video.
		/// </summary>
		public uint Width { get; private set; }

		/// <summary>
		/// Gets the script writers for the video.
		/// </summary>
		public IList<string> Writers { get; private set; }

		/// <summary>
		/// Gets or sets the year that the video was shot or released.
		/// </summary>
		public uint Year { get; set; }

		#endregion

		#region Methods

		/// <summary>
		/// Retrieves the specified properties associated with the item.
		/// </summary>
		/// <param name="propertiesToRetrieve">A collection that contains the names of the properties to retrieve.</param>
		/// <returns>When this method completes successfully, it returns a collection (type IMap) that contains the specified properties and values as key-value pairs.</returns>
		public IAsyncOperation<IDictionary<string, object>> RetrievePropertiesAsync(IEnumerable<string> propertiesToRetrieve)
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
		public IAsyncAction SavePropertiesAsync( IEnumerable<KeyValuePair<string, object>> propertiesToSave )
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}