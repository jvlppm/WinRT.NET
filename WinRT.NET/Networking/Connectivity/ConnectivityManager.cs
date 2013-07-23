//
// ConnectivityManager.cs
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
using Windows.Foundation;
using Windows.Foundation.Metadata;

namespace Windows.Networking.Connectivity
{
#if Windows8_1_Preview
	//[MarshalingBehavior(Agile)]
	//[Static(Windows.Networking.Connectivity.IConnectivityManagerStatics, WindowsVersion.Windows8_1_Preview)]
	/// <summary>
	/// Methods defined by the ConnectivityManager class enable enforcement of
	/// traffic routing on a specific network adapter for the specified
	/// destination suffix. Once a policy is set using AddHttpRoutePolicy,
	/// traffic that matches the policy will either be routed or dropped.
	/// </summary>
	[DualApiPartition]
	[Version(WindowsVersion.Windows8_1_Preview)]
	public static class ConnectivityManager
	{
		/// <summary>
		/// Establishes a connection to a specific access point on a network. The
		/// request is defined using a CellularApnContext object.
		/// </summary>
		/// <param name="CellularApnContext">Provides specific details about the APN.</param>
		/// <returns>The established APN connection.</returns>
		public static IAsyncOperation<ConnectionSession> AcquireConnectionAsync( CellularApnContext CellularApnContext )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Specifies a RoutePolicy that  the Http stack (WinInet) will follow
		/// when routing traffic.
		/// </summary>
		/// <param name="RoutePolicy">Indicates the policy for traffic routing.</param>
		public static void AddHttpRoutePolicy( RoutePolicy RoutePolicy )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Removes a previously specified RoutePolicy from the Http stack
		/// (WinInet).
		/// </summary>
		/// <param name="RoutePolicy">The RoutePolicy to remove.</param>
		public static void RemoveHttpRoutePolicy( RoutePolicy RoutePolicy )
		{
			throw new NotImplementedException();
		}
	}
#endif
}