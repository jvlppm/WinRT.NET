//
// EndpointPair.cs
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

namespace Windows.Networking
{
	/// <summary>
	/// Provides data for the local endpoint and remote endpoint for a network
	/// connection used by network apps.
	/// </summary>
	//[Activatable(typeof(Windows.Networking.IEndpointPairFactory), NTDDI_WIN8)]
	[DualApiPartition]
	[Threading(ThreadingModel.Both)]
	[MarshalingBehavior(MarshalingType.Agile)]
	[Version(WindowsVersion.NTDDI_WIN8)]
	public sealed class EndpointPair
	{
		/// <summary>
		/// Get or set the local hostname for the EndpointPair object.
		/// </summary>
		public HostName LocalHostName { get; set; }

		/// <summary>
		/// Get or set the local service name for the EndpointPair object.
		/// </summary>
		public string LocalServiceName { get; set; }

		/// <summary>
		/// Get or set the remote hostname for the EndpointPair object.
		/// </summary>
		public HostName RemoteHostName { get; set; }

		/// <summary>
		/// Get or set the remote service name for the EndpointPair object.
		/// </summary>
		public string RemoteServiceName { get; set; }
	}
}