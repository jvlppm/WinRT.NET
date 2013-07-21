//
// LanIdentifier.cs
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
	//[DualApiPartition]
	//[MarshalingBehavior(Agile)]
	/// <summary>
	/// Represents physical identification data for a specific NetworkAdapter
	/// object.
	/// </summary>
	[Version(WindowsVersion.NTDDI_WIN8)]
	public sealed class LanIdentifier
	{
		/// <summary>
		/// Gets a  LanIdentifierData object containing locality identification
		/// information for the network adapter&#39;s connection.
		/// </summary>
		public LanIdentifierData InfrastructureId { get; private set; }

		/// <summary>
		/// Gets the adapter GUID that identifies the network adapter to
		/// associate with the locality information.
		/// </summary>
		public Guid NetworkAdapterId { get; private set; }

		/// <summary>
		/// Gets a LanIdentifierData object containing the port ID from the Link
		/// Layer Discovery Protocol (LLDP) locality information for an Ethernet
		/// type network adapter.
		/// </summary>
		public LanIdentifierData PortId { get; private set; }
	}
}