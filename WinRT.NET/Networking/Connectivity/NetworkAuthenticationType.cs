//
// NetworkAuthenticationType.cs
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
	public enum NetworkAuthenticationType
	{
		/// <summary>
		/// No authentication enabled.
		/// </summary>
		None,
		/// <summary>
		/// Authentication method unknown.
		/// </summary>
		Unknown,
		/// <summary>
		/// Open authentication over 802.11 wireless.
		/// Devices are authenticated and can connect to an access point,
		/// but communication with the network requires a matching 
		/// Wired Equivalent Privacy (WEP) key.
		/// </summary>
		Open80211,
		/// <summary>
		/// Specifies an IEEE 802.11 Shared Key authentication algorithm that
		/// requires the use of a pre-shared Wired Equivalent Privacy (WEP) key
		/// for the 802.11 authentication.
		/// </summary>
		SharedKey80211,
		/// <summary>
		/// Specifies a Wi-Fi Protected Access (WPA) algorithm.
		/// IEEE 802.1X port authorization is performed by the supplicant,
		/// authenticator, and authentication server.
		/// Cipher keys are dynamically derived through the authentication process.
		/// </summary>
		Wpa,
		/// <summary>
		/// Specifies a Wi-Fi Protected Access (WPA) algorithm that uses
		/// pre-shared keys (PSK). IEEE 802.1X port authorization is performed
		/// by the supplicant and authenticator. Cipher keys are dynamically
		/// derived through a pre-shared key that is used on both the
		/// supplicant and authenticator.
		/// </summary>
		WpaPsk,
		/// <summary>
		/// Wi-Fi Protected Access.
		/// </summary>
		WpaNone,
		/// <summary>
		/// Specifies an IEEE 802.11i Robust Security Network Association
		/// (RSNA) algorithm. IEEE 802.1X port authorization is performed
		/// by the supplicant, authenticator, and authentication server.
		/// Cipher keys are dynamically derived through the authentication
		/// process.
		/// </summary>
		Rsna,
		/// <summary>
		/// Specifies an IEEE 802.11i RSNA algorithm that uses PSK. IEEE 802.1X
		/// port authorization is performed by the supplicant and
		/// authenticator. Cipher keys are dynamically derived through a
		/// pre-shared key that is used on both the supplicant
		/// and authenticator.
		/// </summary>
		RsnaPsk,
		/// <summary>
		/// Specifies an authentication type defined by an
		/// independent hardware vendor (IHV).
		/// </summary>
		Ihv
	}
}
