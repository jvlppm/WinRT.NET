//
// Geocoordinate.cs
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

namespace Windows.Devices.Geolocation
{
	//[MarshalingBehavior(Agile)]
	//[Version(NTDDI_WIN8)]
	public sealed class Geocoordinate
	{
		/// <summary>
		/// The accuracy of the location in meters.
		/// </summary>
		public double Accuracy { get; private set; }

		/// <summary>
		/// The altitude of the location, in meters.
		/// </summary>
		public double? Altitude { get; private set; }

		/// <summary>
		/// The accuracy of the altitude, in meters.
		/// </summary>
		public double? AltitudeAccuracy { get; private set; }

		/// <summary>
		/// The current heading in degrees relative to true north.
		/// </summary>
		public double? Heading { get; private set; }

		/// <summary>
		/// The latitude in degrees.
		/// </summary>
		public double Latitude { get; private set; }

		/// <summary>
		/// The longitude in degrees.
		/// </summary>
		public double Longitude { get; private set; }

		/// <summary>
		/// The speed in meters per second.
		/// </summary>
		public double? Speed { get; private set; }

		/// <summary>
		/// The time at which the location was determined.
		/// </summary>
		public DateTimeOffset Timestamp { get; private set; }
	}
}