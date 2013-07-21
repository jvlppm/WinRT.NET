//
// RoutePolicy.cs
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
	//[Activatable(Windows.Networking.Connectivity.IRoutePolicyFactory, WindowsVersion.Windows8_1_Preview)]
	//[DualApiPartition]
	//[MarshalingBehavior(Agile)]
	[Version(WindowsVersion.Windows8_1_Preview)]
	public sealed class RoutePolicy
	{
		#region Properties

		/// <summary>
		/// Retrieves the connection profile for an access point connection.
		/// </summary>
		public ConnectionProfile ConnectionProfile { get; private set; }

		/// <summary>
		/// Provides the host name for the route policy to the special PDP
		/// context.
		/// </summary>
		public HostName HostName { get; private set; }

		#endregion

		#region Constructors

		/// <summary>
		/// Creates an instance of RoutePolicy using the defined connection
		/// profile and host name values.
		/// </summary>
		/// <param name="pConnectionProfile">The connection profile</param>
		/// <param name="pHostName">
		/// The host name for the route policy to the special PDP context.
		/// </param>
		public RoutePolicy( ConnectionProfile pConnectionProfile, HostName pHostName )
		{
			ConnectionProfile = pConnectionProfile;
			HostName = pHostName;
		}

		#endregion
	}
#endif
}