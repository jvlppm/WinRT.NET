using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.Foundation.Metadata;

namespace Windows.Storage.Streams
{
	/// <summary>
	/// Specifies the read options for an input stream.
	/// </summary>
	[Flags]
	[Version(WindowsVersion.NTDDI_WIN8)]
	public enum InputStreamOptions
	{
		/// <summary>
		/// No options are specified.
		/// </summary>
		None,
		/// <summary>
		/// The asynchronous read operation completes when one or more bytes is available.
		/// </summary>
		Partial,
		/// <summary>
		/// The asynchronous read operation may optionally read ahead and prefetch additional bytes.
		/// </summary>
		ReadAhead
	}
}
