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

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using WinRT.NET.Forms.Internal.Controls;

namespace Windows.Security.Authentication.Web
{
	//[Static(Windows.Security.Authentication.Web.IWebAuthenticationBrokerStatics, NTDDI_WIN8)]
	[Threading(ThreadingModel.Both)]
	[Version(WindowsVersion.NTDDI_WIN8)]
	public static class WebAuthenticationBroker
	{
		static Uri _applicationCallback;

		/// <summary>
		/// Starts the asynchronous authentication operation with two inputs. You can call this method multiple times in a single application or across multiple applications at the same time.
		/// </summary>
		/// <param name="options">The options for the authentication operation.</param>
		/// <param name="requestUri">The starting URI of the web service. This URI must be a secure address of https://.</param>
		/// <returns>The way to query the status and get the results of the authentication operation. If you are getting an invalid parameter error, the most common cause is that you are not using HTTPS for the requestUri parameter.</returns>
		public static IAsyncOperation<WebAuthenticationResult> AuthenticateAsync(WebAuthenticationOptions options, Uri requestUri)
		{
			return AuthenticateAsync(options, requestUri, GetCurrentApplicationCallbackUri());
		}

		/// <summary>
		/// Starts the asynchronous authentication operation with three inputs. You can call this method multiple times in a single application or across multiple applications at the same time.
		/// </summary>
		/// <param name="options">The options for the authentication operation.</param>
		/// <param name="requestUri">The starting URI of the web service. This URI must be a secure address of https://.</param>
		/// <param name="callbackUri">The callback URI that indicates the completion of the web authentication. The broker matches this URI against every URI that it is about to navigate to. The broker never navigates to this URI, instead the broker returns the control back to the application when the user clicks a link or a web server redirection is made.</param>
		/// <returns>The way to query the status and get the results of the authentication operation. If you are getting an invalid parameter error, the most common cause is that you are not using HTTPS for the requestUri parameter.</returns>
		public static IAsyncOperation<WebAuthenticationResult> AuthenticateAsync(WebAuthenticationOptions options, Uri requestUri, Uri callbackUri)
		{
			var tcs = new TaskCompletionSource<WebAuthenticationResult>();

			if (options != WebAuthenticationOptions.None)
				throw new NotImplementedException();

			var t = new Thread((ThreadStart)delegate
			{
				var result = WebAuthenticationResult.UserCancel;

				// TODO: Create a Dialog/Window class.
				var backWin = new Form
				{
					BackColor = global::System.Drawing.Color.Black,
					Opacity = 0.55,
					WindowState = FormWindowState.Maximized,
					FormBorderStyle = FormBorderStyle.None,
					TopMost = true
				};

				var win = new Form
				{
					FormBorderStyle = FormBorderStyle.None,
					TopMost = true
				};
				win.SizeChanged += delegate
				{
					win.Top = (backWin.Height - win.Height) / 2;
					win.Left = backWin.Left;
				};
				backWin.SizeChanged += delegate
				{
					win.Width = backWin.Width;
					win.Height = backWin.Height - 230;
				};

				var headerPanel = new Panel { Width = 566, Height = 80 };
				var bodyPanel = new Panel
				{
					Top = 80,
					BackColor = global::System.Drawing.Color.White,
				};

				var backButton = new BackButton
				{
					Location = new global::System.Drawing.Point(0, 35),
					TabStop = false
				};
				headerPanel.Controls.Add(backButton);
				backButton.Click += (s, e) => win.Close();

				var lbl = new Label
				{
					Location = new global::System.Drawing.Point(35, 30),
					Font = new global::System.Drawing.Font("Segoe UI", 19.5f),
					Text = WinRT.NET.Forms.Properties.Resources.AuthenticationBrokerTitle,
					AutoSize = true
				};
				headerPanel.Controls.Add(lbl);
				win.Controls.Add(headerPanel);
				win.Controls.Add(bodyPanel);

				var browser = new WebBrowser { Width = 566 };
				win.SizeChanged += delegate
				{
					bodyPanel.Width = win.Width;
					bodyPanel.Height = win.Height - bodyPanel.Top;
					browser.Height = win.Height - 80;
					browser.Left = (win.Width - browser.Width) / 2;
					headerPanel.Left = browser.Left;
				};

				browser.PreviewKeyDown += (sender, e) =>
				{
					if (e.KeyCode == Keys.Escape)
						win.DialogResult = DialogResult.Abort;
				};
				bodyPanel.Controls.Add(browser);
				win.Deactivate += (sender, e) =>
				{
					if (win.CanFocus)
						win.DialogResult = DialogResult.Abort;
				};

				browser.Navigated += (sender, e) =>
				{
					if (e.Url.GetLeftPart(UriPartial.Path).EndsWith(callbackUri.ToString()))
					{
						result = WebAuthenticationResult.FromResponseData(e.Url.ToString());
						win.DialogResult = DialogResult.OK;
					}
				};

				browser.Navigate(requestUri);

				backWin.Show();
				win.ShowDialog();
				backWin.Close();

				tcs.TrySetResult(result);
			});

			t.SetApartmentState(ApartmentState.STA);
			t.Start();

			return tcs.Task.AsAsyncOperation();
		}

		/// <summary>
		/// Gets the current application callback URI.
		/// </summary>
		/// <returns>The URI of the current application.</returns>
		public static Uri GetCurrentApplicationCallbackUri()
		{
			if (_applicationCallback == null)
				_applicationCallback = new Uri(new Guid().ToString(), UriKind.Relative);

			return _applicationCallback;
		}
	}
}