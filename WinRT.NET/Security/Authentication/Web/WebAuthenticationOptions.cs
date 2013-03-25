//
// WebAuthenticationOptions.cs
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

namespace Windows.Security.Authentication.Web
{
	[Flags]
	//[Version(NTDDI_WIN8)]
	public enum WebAuthenticationOptions
	{
		/// <summary>
		/// No options are requested.
		/// </summary>
		None = 0,
		/// <summary>
		/// Tells the web authentication broker to not render any UI. For use with Single Sign On (SSO). If the server tries to display a webpage, the authentication operation fails. You should try again without this option.
		/// </summary>
		SilentMode = 1,
		/// <summary>
		/// Tells the web authentication broker to return the window title string of the webpage in the ResponseData property.
		/// </summary>
		UseTitle = 2,
		/// <summary>
		/// Tells the web authentication broker to return the body of the HTTP POST in the ResponseData property. For use with single sign-on (SSO) only.
		/// </summary>
		UseHttpPost = 4,
		/// <summary>
		/// Tells the web authentication broker to render the webpage in an app container that supports privateNetworkClientServer, enterpriseAuthentication, and sharedUserCertificate capabilities. Note the application that uses this flag must have these capabilities as well.
		/// </summary>
		UseCorporateNetwork = 8
	}
}