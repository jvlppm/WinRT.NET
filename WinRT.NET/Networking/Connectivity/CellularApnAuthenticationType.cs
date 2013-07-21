//
// CellularApnAuthenticationType.cs
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

using Windows.Foundation.Metadata;

namespace Windows.Networking.Connectivity
{
#if Windows8_1_Preview
	/// <summary>
	/// Defines values that indicate the authentication type used for a APN.
	/// These values are referenced when providing APN details using a
	/// CellularApnContext object.
	/// </summary>
	[Version(WindowsVersion.Windows8_1_Preview)]
	public enum CellularApnAuthenticationType
	{
		/// <summary>
		/// No authentication.
		/// </summary>
		None,
		/// <summary>
		/// Password authentication.
		/// </summary>
		Pap,
		/// <summary>
		/// Challenge-Handshake authentication.
		/// </summary>
		Chap,
		/// <summary>
		/// Microsoft Challenge-Handshake authentication (v2)
		/// </summary>
		Mschapv2
	}
#endif
}