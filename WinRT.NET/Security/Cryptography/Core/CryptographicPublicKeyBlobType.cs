//
// CryptographicPublicKeyBlobType.cs
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

namespace Windows.Security.Cryptography.Core
{
	[Version(WindowsVersion.NTDDI_WIN8)]
	public enum CryptographicPublicKeyBlobType
	{
		/// <summary>
		/// This is the default value. The public key is encoded as an ASN.1 SubjectPublicKeyInfo type defined in RFC 5280 and RFC 3280. Copy SubjectPublicKeyInfo ::= SEQUENCE { algorithm AlgorithmIdentifier, subjectPublicKey BIT STRING }
		/// </summary>
		X509SubjectPublicKeyInfo,
		/// <summary>
		/// The key is an RSA public key defined in the PKCS #1 standard. For more information, see the RSA Cryptography Specification in RFC 3347.
		/// </summary>
		Pkcs1RsaPublicKey,
		/// <summary>
		/// Microsoft public key format defined by Cryptography API: Next Generation (CNG). For examples, see the following CNG structures: BCRYPT_DH_KEY_BLOB BCRYPT_DSA_KEY_BLOB BCRYPT_ECCKEY_BLOB BCRYPT_KEY_BLOB BCRYPT_RSAKEY_BLOB
		/// </summary>
		BCryptPublicKey,
		/// <summary>
		/// Microsoft public key format defined by the legacy Cryptography API (CAPI). For more information, see Base Provider Key BLOBs.
		/// </summary>
		Capi1PublicKey
	}
}