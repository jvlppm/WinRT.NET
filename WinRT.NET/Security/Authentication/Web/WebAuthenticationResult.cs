//
// WebAuthenticationResult.cs
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

namespace Windows.Security.Authentication.Web
{
	//[Version(NTDDI_WIN8)]
	public sealed class WebAuthenticationResult
	{
		/// <summary>
		/// Contains the protocol data when the operation successfully completes.
		/// </summary>
		public string ResponseData { get; private set; }

		/// <summary>
		/// Returns the HTTP error code when ResponseStatus is equal to WebAuthenticationStatus.ErrorHttp.
		/// This is only available if there is an error.
		/// </summary>
		public uint ResponseErrorDetail { get; private set; }

		/// <summary>
		/// Contains the status of the asynchronous operation when it completes.
		/// </summary>
		public WebAuthenticationStatus ResponseStatus { get; private set; }
	}
}