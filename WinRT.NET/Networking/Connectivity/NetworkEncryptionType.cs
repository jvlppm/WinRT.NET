//
// NetworkEncryptionType.cs
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
	public enum NetworkEncryptionType
	{
		/// <summary>
		/// No encryption enabled.
		/// </summary>
		None,
		/// <summary>
		/// Encryption method unknown.
		/// </summary>
		Unknown,
		/// <summary>
		/// Specifies a WEP cipher algorithm with a cipher key of any length.
		/// </summary>
		Wep,
		/// <summary>
		/// Specifies a Wired Equivalent Privacy (WEP) algorithm, which is the
		/// RC4-based algorithm that is specified in the IEEE 802.11-1999
		/// standard. This enumerator specifies the WEP cipher algorithm with
		/// a 40-bit cipher key.
		/// </summary>
		Wep40,
		/// <summary>
		/// Specifies a WEP cipher algorithm with a 104-bit cipher key.
		/// </summary>
		Wep104,
		/// <summary>
		/// Specifies a Temporal Key Integrity Protocol (TKIP) algorithm, which
		/// is the RC4-based cipher suite that is based on the algorithms that
		/// are defined in the WPA specification and IEEE 802.11i-2004
		/// standard. This cipher also uses the Michael Message Integrity Code
		/// (MIC) algorithm for forgery protection.
		/// </summary>
		Tkip,
		/// <summary>
		/// Specifies an AES-CCMP algorithm, as specified in the
		/// IEEE 802.11i-2004 standard and RFC 3610.
		/// Advanced Encryption Standard (AES) is the encryption algorithm
		/// defined in FIPS PUB 197.
		/// </summary>
		Ccmp,
		/// <summary>
		/// Specifies a Wifi Protected Access (WPA) Use Group Key cipher suite.
		/// For more information about the Use Group Key cipher suite, refer to
		/// Clause 7.3.2.25.1 of the IEEE 802.11i-2004 standard.
		/// </summary>
		WpaUseGroup,
		/// <summary>
		/// Specifies a Robust Security Network (RSN) Use Group Key cipher
		/// suite. For more information about the Use Group Key cipher suite,
		/// refer to Clause 7.3.2.25.1 of the IEEE 802.11i-2004 standard.
		/// </summary>
		RsnUseGroup,
		/// <summary>
		/// Specifies an encryption type defined by an
		/// independent hardware vendor (IHV).
		/// </summary>
		Ihv
	}
}
