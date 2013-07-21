//
// ConnectionProfileFilter.cs
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

namespace Windows.Networking.Connectivity
{
#if Windows8_1_Preview
	//[Activatable(WindowsVersion.Windows8_1_Preview)]
	//[DualApiPartition]
	//[MarshalingBehavior(Agile)]
	//[Threading(Both)]
	[Version(WindowsVersion.Windows8_1_Preview)]
	public sealed class ConnectionProfileFilter
	{
		#region Properties

		/// <summary>
		/// Indicates if  connection profiles that represent currently
		/// established connections are included in query results.
		/// </summary>
		public bool IsConnected { get; set; }

		/// <summary>
		/// Indicates if  connection profiles that represent WLAN (WiFi)
		/// connections are included in query results.
		/// </summary>
		public bool IsWlanConnectionProfile { get; set; }

		/// <summary>
		/// Indicates if  connection profiles that represent WWAN (mobile)
		/// connections are included in query results.
		/// </summary>
		public bool IsWwanConnectionProfile { get; set; }

		/// <summary>
		/// Defines a specific NetworkCostType value to query for.
		/// </summary>
		public NetworkCostType NetworkCostType { get; set; }

		/// <summary>
		/// Indicates a specific network operator ID to query for.
		/// </summary>
		public Guid? ServiceProviderGuid { get; set; }

		#endregion

		#region Constructors

		/// <summary>
		/// Creates an instance of ConnectionProfileFilter, which contains a set
		/// of properties that are used to improve the relevance of
		/// FindConnectionProfilesAsync results.
		/// </summary>
		public ConnectionProfileFilter()
		{
		}

		#endregion
	}
#endif
}