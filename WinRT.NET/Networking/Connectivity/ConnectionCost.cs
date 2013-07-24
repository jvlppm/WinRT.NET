//
// ConnectionCost.cs
//
// Author:
//   Eric Maupin <me@ermau.com>
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
	/// <summary>
	/// Provides access to property values that indicate the current cost of a
	/// network connection.
	/// </summary>
	[DualApiPartition]
	[MarshalingBehavior(MarshalingType.Agile)]
	[Version(WindowsVersion.NTDDI_WIN8)]
	public sealed class ConnectionCost
	{
		/// <summary>
		/// Gets a value that indicates if a connection is approaching the data usage allowance specified by the data plan.
		/// </summary>
		public bool ApproachingDataLimit { get; private set; }

		/// <summary>
		/// Gets a value that indicates the current network cost for a connection.
		/// </summary>
		public NetworkCostType NetworkCostType { get; private set; }

		/// <summary>
		/// Gets a value that indicates if the connection has exceeded the data usage allowance specified by the data plan.
		/// </summary>
		public bool OverDataLimit { get; private set; }

		/// <summary>
		/// Gets a value that indicates whether the connection is connected to a network outside of the home provider.
		/// </summary>
		public bool Roaming { get; private set; }
	}
}