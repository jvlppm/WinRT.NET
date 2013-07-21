//
// CellularApnContext.cs
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
	//[Activatable(WindowsVersion.Windows8_1_Preview)]
	//[DualApiPartition]
	//[MarshalingBehavior(Agile)]
	/// <summary>
	/// This class contains properties used to specify an Access Point Name
	/// (APN) for a 3GPP based cellular Data Connection (PDP context).
	/// </summary>
	[Version(WindowsVersion.Windows8_1_Preview)]
	public sealed class CellularApnContext
	{
		#region Properties

		/// <summary>
		/// [This documentation is preliminary and is subject to change.]
		/// Indicates the name of the access point to establish a connection
		/// with.
		/// </summary>
		public string AccessPointName { get; set; }

		/// <summary>
		/// [This documentation is preliminary and is subject to change.]
		/// Indicates the authentication method, as defined by
		/// CellularApnAuthenticationType, that is used by the access point.
		/// </summary>
		public CellularApnAuthenticationType AuthenticationType { get; set; }

		/// <summary>
		/// [This documentation is preliminary and is subject to change.]
		/// Indicates if data compression will be used at the data link for
		/// header and data transfer.
		/// </summary>
		public bool IsCompressionEnabled { get; set; }

		/// <summary>
		/// [This documentation is preliminary and is subject to change.]
		/// Indicates the password used to authenticate when connecting to the
		/// access point.
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// [This documentation is preliminary and is subject to change.]
		/// Indicates the provider ID associated with the access point.
		/// </summary>
		public string ProviderId { get; set; }

		/// <summary>
		/// [This documentation is preliminary and is subject to change.]
		/// Indicates the user name used to authenticate when connecting to the
		/// access point.
		/// </summary>
		public string UserName { get; set; }

		#endregion

		#region Constructors

		/// <summary>
		/// [This documentation is preliminary and is subject to change.]
		/// Creates an instance of CellularApnContext.
		/// </summary>
		public CellularApnContext()
		{
		}

		#endregion
	}
}