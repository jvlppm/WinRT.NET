//
// CryptographicKey.cs
//
// Author:
//   Eric Maupin <me@ermau.com>
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

using Windows.Storage.Streams;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;

namespace Windows.Security.Cryptography.Core
{
	//[DualApiPartition]
	//[MarshalingBehavior(Agile)]
	//[Version(NTDDI_WIN8)]
	public sealed class CryptographicKey
	{
		#region Properties

		/// <summary>
		/// Gets the size, in bits, of the key.
		/// </summary>
		public uint KeySize { get; private set; }

		#endregion

		#region Methods

		/// <summary>
		/// Exports the key pair to a buffer.
		/// </summary>
		/// <returns>Buffer that contains the key pair.</returns>
		public IBuffer Export()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Exports the key pair to a buffer given a specified format.
		/// </summary>
		/// <param name="BlobType">A CryptographicPrivateKeyBlobType enumeration value that specifies the format of the key in the buffer. The default value is Pkcs8RawPrivateKeyInfo.</param>
		/// <returns>Buffer that contains the key pair.</returns>
		public IBuffer Export( CryptographicPrivateKeyBlobType BlobType )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Exports a public key to a buffer.
		/// </summary>
		/// <returns>Buffer that contains the public key.</returns>
		public IBuffer ExportPublicKey()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Exports a public key to a buffer given a specified format.
		/// </summary>
		/// <param name="BlobType">A CryptographicPublicKeyBlobType enumeration value that specifies the format of the key in the buffer. The default value is X509SubjectPublicKeyInfo.</param>
		/// <returns>Buffer that contains the public key.</returns>
		public IBuffer ExportPublicKey( CryptographicPublicKeyBlobType BlobType )
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Private

		#region Hash
		internal CryptographicKey(HMAC hash)
		{
			if (hash == null)
				throw new ArgumentNullException("hash");
			if (hash.Key == null)
				throw new ArgumentNullException("hash.Key");

			Hash = hash;
			KeySize = (uint)(hash.Key.Length * 8);
		}

		internal HMAC Hash { get; private set; }
		#endregion

		#endregion
	}
}