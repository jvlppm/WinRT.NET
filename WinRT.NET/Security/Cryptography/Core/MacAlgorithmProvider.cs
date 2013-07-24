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
using Windows.Storage.Streams;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Collections.Generic;
using Windows.Foundation.Metadata;

namespace Windows.Security.Cryptography.Core
{
	/// <summary>
	/// Represents a message authentication code (MAC).
	/// A MAC uses symmetric key cryptography to prevent message tampering.
	/// For more information, see MACs, Hashes, and Signatures.
	/// </summary>
	//[Static(Windows.Security.Cryptography.Core.IMacAlgorithmProviderStatics, NTDDI_WIN8)]
	[DualApiPartition]
	[Threading(ThreadingModel.Both)]
	[MarshalingBehavior(MarshalingType.Agile)]
	[Version(WindowsVersion.NTDDI_WIN8)]
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
		public uint MacLength { get; private set; }

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
			if (CreateKeyFunc == null)
				throw new NotImplementedException();

			return CreateKeyFunc(keyMaterial);
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
		Func<IBuffer, CryptographicKey> CreateKeyFunc { get; set; }

		MacAlgorithmProvider(string algorithmName)
		{
			var createKeyByAlgorithm =
				new Dictionary<string, Func<IBuffer, CryptographicKey>>
			{
				{MacAlgorithmNames.AesCmac, CreateAesCmacKey},
				{MacAlgorithmNames.HmacMd5, CreateHmacKey<HMACMD5>},
				{MacAlgorithmNames.HmacSha1, CreateHmacKey<HMACSHA1>},
				{MacAlgorithmNames.HmacSha256, CreateHmacKey<HMACSHA256>},
				{MacAlgorithmNames.HmacSha384, CreateHmacKey<HMACSHA384>},
				{MacAlgorithmNames.HmacSha512, CreateHmacKey<HMACSHA512>}
			};

			Func<IBuffer, CryptographicKey> createKeyFunc;
			if (!createKeyByAlgorithm.TryGetValue(algorithmName, out createKeyFunc))
			{
				unchecked
				{
					// Element Not Found
					const uint ERROR_NOT_FOUND = 0x80070490;
					throw Marshal.GetExceptionForHR((int)ERROR_NOT_FOUND);
				}
			}

			var getKeySizeByAlgorithm = new Dictionary<string, uint>
			{
				//{MacAlgorithmNames.AesCmac, ? },
				{MacAlgorithmNames.HmacMd5, 16},
				{MacAlgorithmNames.HmacSha1, 20},
				{MacAlgorithmNames.HmacSha256, 32},
				{MacAlgorithmNames.HmacSha384, 48},
				{MacAlgorithmNames.HmacSha512, 64}
			};

			uint keySize;
			if (!getKeySizeByAlgorithm.TryGetValue(algorithmName, out keySize))
				throw new NotImplementedException();

			AlgorithmName = algorithmName;
			CreateKeyFunc = createKeyFunc;
			MacLength = keySize;
		}

		CryptographicKey CreateHmacKey<T>(IBuffer keyMaterial) where T : HMAC, new()
		{
			return new CryptographicKey(new T { Key = keyMaterial.ToArray() });
		}

		CryptographicKey CreateAesCmacKey(IBuffer keyMaterial)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}