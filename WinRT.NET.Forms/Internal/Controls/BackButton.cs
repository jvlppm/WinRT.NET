using System;
using System.Drawing;
using System.Windows.Forms;
using WinRT.NET.Forms.Properties;

namespace WinRT.NET.Forms.Internal.Controls
{
	internal class BackButton : PictureButton
	{
		public BackButton()
		{
			BackgroundImage = Resources.Image_BackButton_Normal;
			OverImage = Resources.Image_BackButton_Over;
			PressedImage = Resources.Image_BackButton_Pressed;

			Width = Height = 30;
		}
	}
}
