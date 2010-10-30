using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace libavnet
{
	public delegate int read_probe ([MarshalAs (UnmanagedType.LPStruct)] out AVProbeData data);

	/// <summary>
	/// Read the format header and initialize the <see cref="AVFormatContext"/>.
	/// </summary>
	/// <returns>0 if OK, 'ap' if non-NULL contains additional parameters.</returns>
	public delegate int read_header ([MarshalAs (UnmanagedType.LPStruct)] out AVFormatContext context, [MarshalAs (UnmanagedType.LPStruct)] ref AVFormatParameters ap);

	[StructLayout (LayoutKind.Sequential)]
	public class AVInputFormat
	{
		/// <summary>
		/// A comma separated list of short names for the format.
		/// </summary>
		[MarshalAs (UnmanagedType.LPStr)]
		public string name;

		/// <summary>
		/// Descriptive name for the format, meant to be more human-
		/// readable than <see cref="name"/>.
		/// </summary>
		[MarshalAs (UnmanagedType.LPStr)]
		public string long_name;

		/// <summary>
		/// Size of private data so that it can be allocated in the wrapper.
		/// </summary>
		public int priv_data_size;

		/// <summary>
		/// Tell if a given file has a chance of being parsed as this format.
		/// The buffer provided is guaranteed to be <see cref="AVProbeData.PADDING_SIZE"/>
		/// bytes big so you don't have to check for that unless you need more.
		/// </summary>
		[MarshalAs (UnmanagedType.FunctionPtr)]
		public read_probe read_probe;

		[MarshalAs (UnmanagedType.FunctionPtr)]
		public read_header read_header;
	}
}