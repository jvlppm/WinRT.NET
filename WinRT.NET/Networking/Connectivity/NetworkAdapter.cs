//
// NetworkAdapter.cs
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
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.Networking.Connectivity
{
	/// <summary>
	/// Represents a network adapter.
	/// </summary>
	[DualApiPartition]
	[MarshalingBehavior(MarshalingType.Agile)]
	[Version(WindowsVersion.NTDDI_WIN8)]
	public sealed class NetworkAdapter
	{
		#region Properties

		/// <summary>
		/// Gets a value indicating the network interface type as defined by the
		/// Internet Assigned Names Authority (IANA) for the NetworkAdapter.
		/// </summary>
		public uint IanaInterfaceType { get; private set; }

		/// <summary>
		/// Gets a value indicating the maximum inbound data transfer rate in
		/// bits per second.
		/// </summary>
		public ulong InboundMaxBitsPerSecond { get; private set; }

		/// <summary>
		/// Gets the network adapter ID.
		/// </summary>
		public Guid NetworkAdapterId { get; private set; }

		/// <summary>
		/// Gets the NetworkItem object that represents the connected network.
		/// </summary>
		public NetworkItem NetworkItem { get; private set; }

		/// <summary>
		/// Gets a value indicating the maximum outbound speed in bits per
		/// second.
		/// </summary>
		public ulong OutboundMaxBitsPerSecond { get; private set; }

		#endregion

		#region Methods

		/// <summary>
		/// Gets  the connection profile currently associated with the network
		/// adapter.
		/// </summary>
		/// <returns>The connection profile associated with this network adapter.</returns>
		public IAsyncOperation<ConnectionProfile> GetConnectedProfileAsync()
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}