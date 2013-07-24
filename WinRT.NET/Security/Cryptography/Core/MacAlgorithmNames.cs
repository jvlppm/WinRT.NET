//
// MacAlgorithmNames.cs
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

namespace Windows.Security.Cryptography.Core
{
	/// <summary>
	/// Contains static properties that enable you to
	/// retrieve algorithm names that can be used in the
	/// OpenAlgorithm method of the MacAlgorithmProvider class.
	/// </summary>
	//[Static(typeof(Windows.Security.Cryptography.Core.IMacAlgorithmNamesStatics), WindowsVersion.NTDDI_WIN8)]
	[DualApiPartition]
	[MarshalingBehavior(MarshalingType.Agile)]
	[Version(WindowsVersion.NTDDI_WIN8)]
	public static class MacAlgorithmNames
	{
		/// <summary>
		/// Retrieves a string that contains "AES_CMAC".
		/// </summary>
		/// <value>String that contains "AesCmac".</value>
		public static string AesCmac { get { return "AES_CMAC"; } }

		/// <summary>
		/// Retrieves a string that contains "HMAC_MD5".
		/// </summary>
		/// <value>String that contains "HMAC_MD5".</value>
		public static string HmacMd5 { get { return "HMAC_MD5"; } }

		/// <summary>
		/// Retrieves a string that contains "HMAC_SHA1".
		/// </summary>
		/// <value>String that contains "HMAC_SHA1".</value>
		public static string HmacSha1 { get { return "HMAC_SHA1"; } }

		/// <summary>
		/// Retrieves a string that contains "HMAC_SHA256".
		/// </summary>
		/// <value>String that contains "HMAC_SHA256".</value>
		public static string HmacSha256 { get { return "HMAC_SHA256"; } }

		/// <summary>
		/// Retrieves a string that contains "HMAC_SHA384".
		/// </summary>
		/// <value>String that contains "HMAC_SHA384".</value>
		public static string HmacSha384 { get { return "HMAC_SHA384"; } }

		/// <summary>
		/// Retrieves a string that contains "HMAC_SHA512".
		/// </summary>
		/// <value>String that contains "HMAC_SHA512".</value>
		public static string HmacSha512 { get { return "HMAC_SHA512"; } }
	}
}

