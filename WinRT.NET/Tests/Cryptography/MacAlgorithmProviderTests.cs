using System;
using NUnit.Framework;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace WinRTNET.Tests
{
	[TestFixture]
	public class MacAlgorithmProviderTests
	{

		[Test]
		public void OpenAlgorithm_Invalid()
		{
			Assert.Throws<ArgumentNullException>(() => MacAlgorithmProvider.OpenAlgorithm(null));

			try
			{
				MacAlgorithmProvider.OpenAlgorithm(String.Empty);
				Assert.Fail("Empty algorithm should not be allowed");
			} catch (Exception ex)
			{
#if NET_4_5
				Assert.AreEqual(-2147023728, ex.HResult);
#endif
			}

			try
			{
				MacAlgorithmProvider.OpenAlgorithm("Monkeys!");
				Assert.Fail("Random algorithm should not be allowed");
			} catch (Exception ex)
			{
#if NET_4_5
				Assert.AreEqual(-2147023728, ex.HResult);
#endif
			}
		}

		[Test]
		public void HmacSha1EncryptionTest()
		{
			IBuffer keyMaterial = AsBufferAscii("password");
			IBuffer dataToBeSigned = AsBufferAscii("secret message");

			MacAlgorithmProvider hmacSha1Provider = MacAlgorithmProvider.OpenAlgorithm("HMAC_SHA1");
			CryptographicKey macKey = hmacSha1Provider.CreateKey(keyMaterial);

			IBuffer signatureBuffer = CryptographicEngine.Sign(macKey, dataToBeSigned);
			var signedData = signatureBuffer.ToArray();

			var expected = new[] { 162, 111, 251, 191, 147, 54, 153, 196, 146,
						192, 203, 254, 61, 111, 111, 172, 171, 246, 254, 95 };
			Assert.That(signedData, Is.EqualTo(expected));
		}

		public static IBuffer AsBufferAscii(string str)
		{
			return str.ToCharArray()
				.Select(c => (byte)(int)c)
				.ToArray()
				.AsBuffer();
		}
	}
}

