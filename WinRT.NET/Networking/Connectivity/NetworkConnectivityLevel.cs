//
// NetworkConnectivityLevel.cs
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
	[Version(WindowsVersion.NTDDI_WIN8)]
	public enum NetworkConnectivityLevel
	{
		/// <summary>
		/// No connectivity.
		/// </summary>
		None,
		/// <summary>
		/// Local network access only.
		/// </summary>
		LocalAccess,
		/// <summary>
		/// Limited internet access. This value indicates captive portal
		/// connectivity, where local access to a web portal is provided, but
		/// access to the Internet requires that specific credentials are
		/// provided via the portal. This level of connectivity is generally
		/// encountered when using connections hosted in public locations
		/// (e.g. coffee shops and book stores).
		/// Note&#194; &#194;
		/// This doesn&#39;t guarantee detection of a captive portal.
		/// Windows Store apps should also test if the captive portal can be
		/// reached using a URL for the captive portal, or by attempting access
		/// to a public web site which will then redirect to the captive portal
		/// when Windows reports LocalAccess as the current
		/// NetworkConnectivityLevel.
		/// </summary>
		ConstrainedInternetAccess,
		/// <summary>
		/// Local and Internet access.
		/// </summary>
		InternetAccess
	}
}
