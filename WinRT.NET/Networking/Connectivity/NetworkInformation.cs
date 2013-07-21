//
// NetworkInformation.cs
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

namespace Windows.Networking.Connectivity
{
	//[DualApiPartition]
	//[MarshalingBehavior(Agile)]
	//[Static(Windows.Networking.Connectivity.INetworkInformationStatics2, WindowsVersion.Windows8_1_Preview)]
	//[Static(Windows.Networking.Connectivity.INetworkInformationStatics, NTDDI_WIN8)]
	/// <summary>
	/// Provides access to  network connection information for the local machine.
	/// </summary>
	[Version(WindowsVersion.NTDDI_WIN8)]
	public static class NetworkInformation
	{
		/// <summary>
		/// Returns an array of ConnectionProfile objects that match the
		/// filtering criteria defined by ConnectionProfileFilter.
		/// </summary>
		/// <param name="pProfileFilter">Provides the filtering criteria.</param>
		/// <returns>An array of ConnectionProfile objects.</returns>
		public static IAsyncOperation<IReadOnlyList<ConnectionProfile>> FindConnectionProfilesAsync(ConnectionProfileFilter pProfileFilter)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets  a list of profiles for connections, active or otherwise, on the
		/// local machine.
		/// </summary>
		/// <returns>An array of ConnectionProfile objects.</returns>
		public static IReadOnlyList<ConnectionProfile> GetConnectionProfiles()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets a list of host names associated with the local machine.
		/// </summary>
		/// <returns>An array of host names for the local machine.</returns>
		public static IReadOnlyList<HostName> GetHostNames()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the connection profile associated with the internet connection
		/// currently used by the local machine.
		/// </summary>
		/// <returns>The profile for the connection currently used to connect the machine to the internet.</returns>
		public static ConnectionProfile GetInternetConnectionProfile()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets an array of LanIdentifier objects that contain locality
		/// information for each NetworkAdapter object that currently connected
		/// to a network.
		/// </summary>
		/// <returns>An array of LanIdentifier objects.</returns>
		public static IReadOnlyList<LanIdentifier> GetLanIdentifiers()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets a proxy configuration for the connection using the specified
		/// URI.
		/// </summary>
		/// <param name="uri">The proxy configuration URI.</param>
		/// <returns>Information about the connection proxy.</returns>
		public static IAsyncOperation<ProxyConfiguration> GetProxyConfigurationAsync( Uri uri )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets a sorted list of EndpointPair objects.
		/// </summary>
		/// <param name="destinationList">A list of EndpointPair objects to be sorted.</param>
		/// <param name="sortOptions">Indicates sorting options for the returned array.</param>
		/// <returns>A sorted array of EndpointPair objects.</returns>
		public static IReadOnlyList<EndpointPair> GetSortedEndpointPairs( IEnumerable<EndpointPair> destinationList, HostNameSortOptions sortOptions )
		{
			throw new NotImplementedException();
		}
	}
}