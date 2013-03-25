//
// CryptographicEngine.cs
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

using Windows.Storage.Streams;
using System;

namespace Windows.Security.Cryptography.Core
{
	//[DualApiPartition]
	//[MarshalingBehavior(Agile)]
	//[Static(Windows.Security.Cryptography.Core.ICryptographicEngineStatics, NTDDI_WIN8)]
	//[Threading(Both)]
	//[Version(NTDDI_WIN8)]
	public static class CryptographicEngine
	{
		/// <summary>
		/// Signs digital content. For more information, see MACs, Hashes, and Signatures.
		/// </summary>
		/// <param name="key">Key used for signing.</param>
		/// <param name="data">Data to be signed.</param>
		/// <returns>Signed data.</returns>
		public static IBuffer Sign( CryptographicKey key, IBuffer data )
		{
			throw new NotImplementedException();
		}
	}
}