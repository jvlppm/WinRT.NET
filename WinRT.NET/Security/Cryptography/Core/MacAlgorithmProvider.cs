//
// MacAlgorithmProvider.cs
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
using System.Linq;
using Windows.Storage.Streams;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Windows.Security.Cryptography.Core
{
	/// <summary>
	/// Represents a message authentication code (MAC).
	/// A MAC uses symmetric key cryptography to prevent message tampering.
	/// For more information, see MACs, Hashes, and Signatures.
	/// </summary>
	//[DualApiPartition]
	//[MarshalingBehavior(Agile)]
	//[Static(Windows.Security.Cryptography.Core.IMacAlgorithmProviderStatics, NTDDI_WIN8)]
	//[Threading(Both)]
	//[Version(NTDDI_WIN8)]
	public sealed class MacAlgorithmProvider
	{
		#region Properties

		/// <summary>
		/// Gets the name of the open MAC algorithm.
		/// </summary>
		public string AlgorithmName { get; private set; }

		/// <summary>
		/// Gets the length, in bytes, of the message authentication code.
		/// </summary>
		public uint MacLength { get { return (uint)Hash.HashSize; } }

		#endregion

		#region Methods

		/// <summary>
		/// Creates a symmetric key that can be used to create the MAC value.
		/// </summary>
		/// <param name="keyMaterial">
		///   Random data used to help generate the key.
		///   You can call the GenerateRandom method to create the random data.
		/// </param>
		/// <returns>Symmetric key.</returns>
		public CryptographicKey CreateKey(IBuffer keyMaterial)
		{
			var hash = Hash.ComputeHash(keyMaterial.ToArray());
			throw new NotImplementedException();
			//return new CryptographicKey();
		}

		/// <summary>
		/// Creates a MacAlgorithmProvider object and opens the specified algorithm for use.
		/// </summary>
		/// <param name="algorithm">Algorithm name.</param>
		/// <returns>Represents a provider that implements MAC algorithms.</returns>
		public static MacAlgorithmProvider OpenAlgorithm(string algorithm)
		{
			return new MacAlgorithmProvider(algorithm);
		}

		#endregion

		#region Private
		HMAC Hash { get; set; }

		MacAlgorithmProvider(string algorithmName)
		{
			var validAlgorithms = new [] {
				MacAlgorithmNames.AesCmac,
				MacAlgorithmNames.HmacMd5,
				MacAlgorithmNames.HmacSha1,
				MacAlgorithmNames.HmacSha256,
				MacAlgorithmNames.HmacSha384,
				MacAlgorithmNames.HmacSha512
			};

			if (!validAlgorithms.Contains(algorithmName))
			{
				unchecked
				{
					// Element Not Found
					const uint ERROR_NOT_FOUND = 0x80070490;
					throw Marshal.GetExceptionForHR((int)ERROR_NOT_FOUND);
				}
			}

			AlgorithmName = algorithmName;
			if (algorithmName == MacAlgorithmNames.HmacMd5)
				Hash = new HMACMD5();
			else if (algorithmName == MacAlgorithmNames.HmacSha1)
				Hash = new HMACSHA1();
			else if (algorithmName == MacAlgorithmNames.HmacSha256)
				Hash = new HMACSHA256();
			else if (algorithmName == MacAlgorithmNames.HmacSha384)
				Hash = new HMACSHA384();
			else if (algorithmName == MacAlgorithmNames.HmacSha512)
				Hash = new HMACSHA512();
			else
				throw new NotImplementedException();
		}

		#endregion
	}
}