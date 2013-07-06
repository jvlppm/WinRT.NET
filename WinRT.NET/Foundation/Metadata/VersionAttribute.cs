//
// VersionAttribute.cs
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
    public enum WindowsVersion : uint
    {
#if Windows8_1_Preview
        Windows8_1_Preview = 0x6030000,
#endif

        Windows8 = 0x06020000,
        NTDDI_WIN8 = 0x06020000,

        Windows7 = 0x06010000,
        NTDDI_WIN7 = 0x06010000,

        WindowsServer2008 = 0x06000100,
        NTDDI_WS08 = 0x06000100,

        WindowsVista_SP1 = 0x06000100,
        NTDDI_VISTASP1 = 0x06000100,

        WindowsVista = 0x06000000,
        NTDDI_VISTA = 0x06000000,

        WindowsServer2003_SP2 = 0x05020200,
        NTDDI_WS03SP2 = 0x05020200,

        WindowsServer2003_SP1 = 0x05020100,
        NTDDI_WS03SP1 = 0x05020100,

        WindowsServer2003 = 0x05020000,
        NTDDI_WS03 = 0x05020000,

        WindowsXP_SP3 = 0x05010300,
        NTDDI_WINXPSP3 = 0x05010300,

        WindowsXP_SP2 = 0x05010200,
        NTDDI_WINXPSP2 = 0x05010200,

        WindowsXP_SP1 = 0x05010100,
        NTDDI_WINXPSP1 = 0x05010100,

        WindowsXP = 0x05010000,
        NTDDI_WINXP = 0x05010000
    }

    /// <summary>
    /// Indicates the version of the type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false)]
    [Version(WindowsVersion.NTDDI_WIN8)]
    public sealed class VersionAttribute : Attribute
    {
        /// <summary>
        /// Creates and initializes a new instance of the attribute.
        /// </summary>
        /// <param name="version">The version to associate with the marked object.</param>
        public VersionAttribute(uint version)
        {
            Version = version;
#if Windows8_1_Preview
            Platform = Platform.Windows;
#endif
        }

#if Windows8_1_Preview
        /// <summary>
        /// Creates and initializes a new instance of the attribute.
        /// </summary>
        /// <param name="version">The version to associate with the marked object.</param>
        /// <param name="platform">A value of the enumeration. The default is Windows.</param>
        public VersionAttribute(uint version, Platform platform)
        {
            Version = version;
            Platform = platform;
        }
#endif

        /// <summary>
        /// Creates and initializes a new instance of the attribute.
        /// </summary>
        /// <param name="version">The version to associate with the marked object.</param>
        public VersionAttribute(WindowsVersion version)
            : this((uint)version)
        {
        }

        /// <summary>
        /// Gets the version of the marked object.
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