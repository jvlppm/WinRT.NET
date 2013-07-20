//
// WwanNetworkRegistrationState.cs
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
	[Version(WindowsVersion.Windows8_1_Preview)]
	public enum WwanNetworkRegistrationState
	{
		/// <summary>
		/// No networks found for this connection.
		/// </summary>
		None,
		/// <summary>
		/// The connection is not registered with a network.
		/// </summary>
		Deregistered,
		/// <summary>
		/// Searching for available networks.
		/// </summary>
		Searching,
		/// <summary>
		/// The connection is registered with a home network.
		/// </summary>
		Home,
		/// <summary>
		/// The connection is registered with a roaming network.
		/// </summary>
		Roaming,
		/// <summary>
		/// The connection is registered with a roaming network partner.
		/// </summary>
		Partner,
		/// <summary>
		/// Registration of the connection with all available networks is
		/// denied. However, emergency voice calls may still be made. This
		/// value applies only to voice connections, and not to data
		/// connections.
		/// </summary>
		Denied
	}
#endif
}
