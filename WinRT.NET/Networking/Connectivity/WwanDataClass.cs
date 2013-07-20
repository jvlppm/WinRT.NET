//
// WwanDataClass.cs
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
	[Flags]
	[Version(WindowsVersion.Windows8_1_Preview)]
	public enum WwanDataClass : uint
	{
		/// <summary>
		/// The network does not provide a data service.
		/// </summary>
		None = 0,
		/// <summary>
		/// The network provides General Packet Radio Service (GPRS) data
		/// service.
		/// </summary>
		Gprs = 1,
		/// <summary>
		/// The network provides Enhanced Data for Global Evolution (EDGE).
		/// </summary>
		Edge = 2,
		/// <summary>
		/// The network provides Universal Mobile Telecommunications
		/// System (UMTS) data service.
		/// </summary>
		Umts = 4,
		/// <summary>
		/// The network provides High-Speed Downlink Packet Access (HSDPA)
		/// data service.
		/// </summary>
		Hsdpa = 8,
		/// <summary>
		/// The network provides High-Speed Uplink Packet Access (HSUPA) data
		/// service.
		/// </summary>
		Hsupa = 16,
		/// <summary>
		/// The network provides LTE Advanced data service.
		/// </summary>
		LteAdvanced = 32,
		/// <summary>
		/// The network provides CDMA 1x Radio Transmission Technology (1xRTT)
		/// data service.
		/// </summary>
		Cdma1xRtt = 65536,
		/// <summary>
		/// This network provides CDMA Evolution-Data Optimized
		/// (originally Data Only, 1xEDVO, also known as CDMA2000 1x EV-DO,
		/// or 1x EVDO) data service.
		/// </summary>
		Cdma1xEvdo = 131072,
		/// <summary>
		/// The network provides 1xEVDO RevA data service.
		/// </summary>
		Cdma1xEvdoRevA = 262144,
		/// <summary>
		/// The network provides CDMA Evolution-Data/Voice (also known as CDMA
		/// 2000 1x EV-DV, or 1x EVDV) data service is supported.
		/// </summary>
		Cdma1xEvdv = 524288,
		/// <summary>
		/// The network provides CDMA 3x Radio Transmission Technology (3xRTT)
		/// data service.
		/// </summary>
		Cdma3xRtt = 1048576,
		/// <summary>
		/// The network provides 1xEVDO RevB data service.
		/// </summary>
		Cdma1xEvdoRevB = 2097152,
		/// <summary>
		/// The network provides UMB data service.
		/// </summary>
		CdmaUmb = 4194304,
		/// <summary>
		/// The network provides a data service not listed in this table.
		/// </summary>
		Custom = 2147483648
	}
#endif
}
