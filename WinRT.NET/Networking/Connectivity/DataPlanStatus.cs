//
// DataPlanStatus.cs
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
	//[DualApiPartition]
	//[MarshalingBehavior(Agile)]
	/// <summary>
	/// Represents the current status information for the data plan associated with a connection.
	/// </summary>
	[Version(WindowsVersion.NTDDI_WIN8)]
	public sealed class DataPlanStatus
	{
		/// <summary>
		/// Gets a value indicating the maximum data transfer allowance for a
		/// connection within each billing cycle, as defined by the data plan.
		/// </summary>
		public uint? DataLimitInMegabytes { get; private set; }

		/// <summary>
		/// Gets  a DataPlanUsage object that indicates the amount of data
		/// transferred over the connection, in megabytes, and the last time this
		/// value was refreshed.
		/// </summary>
		public DataPlanUsage DataPlanUsage { get; private set; }

		/// <summary>
		/// Gets a value indicating the nominal rate of the  inbound data
		/// transfer occurring on the connection.
		/// </summary>
		public ulong? InboundBitsPerSecond { get; private set; }

		/// <summary>
		/// Gets a value indicates the maximum size of a transfer that is allowed
		/// without user consent on a metered network.
		/// </summary>
		public uint? MaxTransferSizeInMegabytes { get; private set; }

		/// <summary>
		/// Gets a value indicating the date and time of the next billing cycle.
		/// </summary>
		public DateTimeOffset? NextBillingCycle { get; private set; }

		/// <summary>
		/// Gets a value indicating the nominal rate of the outbound data
		/// transfer.
		/// </summary>
		public ulong? OutboundBitsPerSecond { get; private set; }
	}
}