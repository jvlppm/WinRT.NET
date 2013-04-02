//
// WebAuthenticationBroker.cs
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

using Windows.Foundation;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Windows.Security.Authentication.Web
{
	//[Static(Windows.Security.Authentication.Web.IWebAuthenticationBrokerStatics, NTDDI_WIN8)]
	//[Threading(Both)]
	//[Version(NTDDI_WIN8)]
	public static class WebAuthenticationBroker
	{
		/// <summary>
		/// Starts the asynchronous authentication operation with two inputs. You can call this method multiple times in a single application or across multiple applications at the same time.
		/// </summary>
		/// <param name="options">The options for the authentication operation.</param>
		/// <param name="requestUri">The starting URI of the web service. This URI must be a secure address of https://.</param>
		/// <returns>The way to query the status and get the results of the authentication operation. If you are getting an invalid parameter error, the most common cause is that you are not using HTTPS for the requestUri parameter.</returns>
		public static IAsyncOperation<WebAuthenticationResult> AuthenticateAsync( WebAuthenticationOptions options, Uri requestUri )
		{
			var tcs = new TaskCompletionSource<WebAuthenticationResult>();

			if (options != WebAuthenticationOptions.None)
				throw new NotImplementedException();

			var win = new Form();
			var browser = new WebBrowser
			{
				Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom
			};
			win.Controls.Add(browser);

			browser.Navigated += (sender, e) => {
			};

			browser.Navigate(requestUri);

			win.Show();

			return tcs.Task.AsAsyncOperation();
		}

		/// <summary>
		/// Starts the asynchronous authentication operation with three inputs. You can call this method multiple times in a single application or across multiple applications at the same time.
		/// </summary>
		/// <param name="options">The options for the authentication operation.</param>
		/// <param name="requestUri">The starting URI of the web service. This URI must be a secure address of https://.</param>
		/// <param name="callbackUri">The callback URI that indicates the completion of the web authentication. The broker matches this URI against every URI that it is about to navigate to. The broker never navigates to this URI, instead the broker returns the control back to the application when the user clicks a link or a web server redirection is made.</param>
		/// <returns>The way to query the status and get the results of the authentication operation. If you are getting an invalid parameter error, the most common cause is that you are not using HTTPS for the requestUri parameter.</returns>
		public static IAsyncOperation<WebAuthenticationResult> AuthenticateAsync( WebAuthenticationOptions options, Uri requestUri, Uri callbackUri )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the current application callback URI.
		/// </summary>
		/// <returns>The URI of the current application.</returns>
		public static Uri GetCurrentApplicationCallbackUri()
		{
			throw new NotImplementedException();
		}
	}
}