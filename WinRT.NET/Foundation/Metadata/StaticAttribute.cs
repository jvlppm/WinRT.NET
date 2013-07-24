//
// StaticAttribute.cs
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

namespace Windows.Foundation.Metadata
{
	/// <summary>
	/// Indicates that the type contains only static methods.
	/// </summary>
	[AllowMultiple]
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	[Version(WindowsVersion.NTDDI_WIN8)]
	public sealed class StaticAttribute : Attribute
	{
		/// <summary>
		/// Creates and initializes a new instance of the attribute.
		/// </summary>
		/// <param name="type">The type that contains the static methods for the runtime class.</param>
		/// <param name="version">The version in which the static interface was added.</param>
		public StaticAttribute( Type type, uint version )
		{
			Type = type;
			Version = version;
#if Windows8_1_Preview
			Platform = Platform.Windows;
#endif
		}

#if Windows8_1_Preview
		/// <summary>
		/// [This documentation is preliminary and is subject to change.]
		/// Creates and initializes a new instance of the attribute.
		/// </summary>
		/// <param name="type">The type that contains the static methods for the runtime class.</param>
		/// <param name="version">The version in which the static interface was added.</param>
		/// <param name="platform">A value of the enumeration. The default is Windows.</param>
		public StaticAttribute( Type type, uint version, Platform platform )
			: this(type, version)
		{
			Platform = platform;
		}
#endif
		/// <summary>
		/// Gets the type that contains the static methods for the runtime class.
		/// </summary>
		internal Type Type { get; private set; }

		/// <summary>
		/// Gets the version in which the static interface was added.
		/// </summary>
		internal uint Version { get; private set; }

#if Windows8_1_Preview
		/// <summary>
		/// Gets the platform of the type.
		/// </summary>
		internal Platform Platform { get; private set; }
#endif
	}
}