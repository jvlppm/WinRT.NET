//
// ConnectionProfile.cs
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
using System.Collections.Generic;
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.Networking.Connectivity
{
	//[MarshalingBehavior(Agile)]
	/// <summary>
	/// Represents a network connection, which includes either the currently
	/// connected network or prior network connections. Provides information
	/// about the connection status and connectivity statistics.
	/// </summary>
	[DualApiPartition]
	[Version(WindowsVersion.NTDDI_WIN8)]
	public sealed class ConnectionProfile
	{
		#region Properties

		/// <summary>
		/// Gets the object representing the network adapter providing connectivity for the connection.
		/// </summary>
		public NetworkAdapter NetworkAdapter { get; private set; }

		/// <summary>
		/// Retrieves the security settings for the network.
		/// </summary>
		public NetworkSecuritySettings NetworkSecuritySettings { get; private set; }

		/// <summary>
		/// Gets the name of the connection profile.
		/// </summary>
		public string ProfileName { get; private set; }

#if Windows8_1_Preview
		/// <summary>
		/// Gets the ID of the network operator who provisioned the connection profile.
		/// </summary>
		public Guid? ServiceProviderGuid { get; private set; }

		/// <summary>
		/// Gets a value that indicates if connection profile is a WLAN (WiFi) connection. This determines whether or not WlanConnectionProfileDetails is null.
		/// </summary>
		public bool IsWlanConnectionProfile { get; private set; }

		/// <summary>
		/// Gets a value that indicates if connection profile is a WWAN (mobile) connection. This determines whether or not WwanConnectionProfileDetails is null.
		/// </summary>
		public bool IsWwanConnectionProfile { get; private set; }

		/// <summary>
		/// Contains properties and methods defined by WlanConnectionProfile that are specific to WLAN (WiFi) connections.
		/// </summary>
		public WlanConnectionProfileDetails WlanConnectionProfileDetails { get; private set; }

		/// <summary>
		/// Contains the properties and methods defined by WwanConnectionProfile that are specific to mobile broadband connections.
		/// </summary>
		public WwanConnectionProfileDetails WwanConnectionProfileDetails { get; private set; }
#endif

		#endregion

		#region Methods

		/// <summary>
		/// Gets the cost information for the connection.
		/// </summary>
		/// <returns>The cost information for the connection.</returns>
		public ConnectionCost GetConnectionCost()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the current status of the data plan associated with the connection.
		/// </summary>
		/// <returns>Current data plan status information.</returns>
		public DataPlanStatus GetDataPlanStatus()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the network connectivity level for this connection. This value indicates what network resources, if any, are currently available.
		/// </summary>
		/// <returns>The level of network connectivity.</returns>
		public NetworkConnectivityLevel GetNetworkConnectivityLevel()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Retrieves names associated with the network with which the connection is currently established.
		/// </summary>
		/// <returns>An array of string values representing friendly names used to identify the local endpoint.</returns>
		public IReadOnlyList<string> GetNetworkNames()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the estimated data usage for a connection during over a specific period of time.
		/// </summary>
		/// <param name="StartTime">The start date/time for the usage data request.</param>
		/// <param name="EndTime">The end date/time for the usage data request.</param>
		/// <returns>The requested local data usage information.</returns>
#if Windows8_1_Preview
		[Obsolete("GetLocalUsage may be altered or unavailable for releases after Windows&#194; 8.1 Preview. Instead, use GetNetworkUsageAsync")]
#endif
		public DataUsage GetLocalUsage(DateTimeOffset StartTime, DateTimeOffset EndTime)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the estimated data usage for a connection over a specific period of time and roaming state.
		/// </summary>
		/// <param name="StartTime">The start date/time for the usage data request.</param>
		/// <param name="EndTime">The end date/time for the usage data request.</param>
		/// <param name="States">The roaming state to scope the request to.</param>
		/// <returns>The requested local data usage information.</returns>
#if Windows8_1_Preview
		[Obsolete("GetLocalUsage may be altered or unavailable for releases after Windows&#194; 8.1 Preview. Instead, use GetNetworkUsageAsync")]
#endif
		public DataUsage GetLocalUsage(DateTimeOffset StartTime, DateTimeOffset EndTime, RoamingStates States)
		{
			throw new NotImplementedException();
		}

#if Windows8_1_Preview
		/// <summary>
		/// Gets a list of ConnectivityInterval objects, which indicate the timestamp for when the network connection began, and a time-span for the duration of that connection.
		/// </summary>
		/// <param name="startTime">The start time over which to retrieve data.  Can be no more than 60 days prior to the current time.</param>
		/// <param name="endTime">The end time over which to retrieve data.</param>
		/// <param name="states">The state of the connection profile for which usage data should be returned.</param>
		/// <returns>When the method completes, it returns a list of ConnectivityInterval objects, which indicate the start time and duration for the current or prior connections.</returns>
		public IAsyncOperation<IReadOnlyList<ConnectivityInterval>> GetConnectivityIntervalsAsync(DateTimeOffset startTime, DateTimeOffset endTime, NetworkUsageStates states)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets a list of the estimated data traffic and connection duration over a specified period of time, for a specific network usage state.
		/// </summary>
		/// <param name="startTime">The start time over which to retrieve data.  Can be no more than 60 days prior to the current time.  If the specified granularity is PerMinute, the start time can be no more than 120 minutes prior to the current time.</param>
		/// <param name="endTime">The end time over which to retrieve data.</param>
		/// <param name="granularity">The desired granularity of the returned usage statistics.  Each elements in the list corresponds to the network usage per the specified granularity, e.g., usage per hour.</param>
		/// <param name="states">The state of the connection profile for which usage data should be returned.</param>
		/// <returns>When the method completes, it returns a list of NetworkUsage objects, which indicate the sent and received values, in bytes, and the total amount of time the profile was connected during the corresponding time interval.</returns>
		public IAsyncOperation<IReadOnlyList<NetworkUsage>> GetNetworkUsageAsync(DateTimeOffset startTime, DateTimeOffset endTime, DataUsageGranularity granularity, NetworkUsageStates states)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets a value that indicates the current number of signal bars displayed by the Windows UI for the connection.
		/// </summary>
		/// <returns>An integer value within a range of 0-5 that corresponds to the number of signal bars displayed by the UI.</returns>
		public byte? GetSignalBars()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public DomainConnectivityLevel GetDomainConnectivityLevel()
		{
			throw new NotImplementedException();
		}
#endif

		#endregion
	}
}