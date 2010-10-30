using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace libavnet
{
	public static class AVFormat
	{
		[DllImport ("libavformat.dll")]
		public static extern void av_register_all();

		[DllImport ("libavformat.dll")]
		public static extern int av_open_input_file (
			[MarshalAs(UnmanagedType.LPStruct)] out AVFormatContext context,
			[MarshalAs (UnmanagedType.LPStr)] string filename,
			[MarshalAs(UnmanagedType.LPStruct)] ref AVInputFormat fmt,
			int buf_size,
			[MarshalAs(UnmanagedType.LPStruct)] ref AVFormatParameters ap);
	}
}