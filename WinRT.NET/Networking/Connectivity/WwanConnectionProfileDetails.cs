//
// WwanConnectionProfileDetails.cs
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
#if Windows8_1_Preview
	//[MarshalingBehavior(Agile)]
	[DualApiPartition]
	[Version(WindowsVersion.Windows8_1_Preview)]
	public sealed class WwanConnectionProfileDetails
	{
		#region Properties

		/// <summary>
		/// Indicates the name of the access point used to establish the WWAN connection.
		/// </summary>
		public string AccessPointName { get; private set; }

		/// <summary>
		/// Indicates the Home Network Provider ID.
		/// </summary>
		public string HomeProviderId { get; private set; }

		#endregion

		#region Methods

		/// <summary>
		/// Indicates the class of data service offered by the network currently in use for the WWAN connection.
		/// </summary>
		/// <returns>The class of data service currently provided.</returns>
		public WwanDataClass GetCurrentDataClass()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Retrieves the current network registration state for the WWAN connection.
		/// </summary>
		/// <returns>The current network registration state.</returns>
		public WwanNetworkRegistrationState GetNetworkRegistrationState()
		{
			throw new NotImplementedException();
		}

		#endregion
	}
#endif
}
