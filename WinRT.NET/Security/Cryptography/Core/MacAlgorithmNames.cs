using System;

namespace Windows.Security.Cryptography.Core
{
	/// <summary>
	/// Contains static properties that enable you to
	/// retrieve algorithm names that can be used in the
	/// OpenAlgorithm method of the MacAlgorithmProvider class.
	/// </summary>
	//[DualApiPartition()]
	//[MarshalingBehavior(Agile)]
	//[Static(Windows.Security.Cryptography.Core.IMacAlgorithmNamesStatics, NTDDI_WIN8)]
	//[Version(NTDDI_WIN8)]
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

