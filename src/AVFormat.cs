using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace libavnet
{
	public static class AVFormat
	{
		[DllImport ("libavformat.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void av_register_all();

		[DllImport ("libavformat.dll", EntryPoint = "av_guess_format", CallingConvention = CallingConvention.Cdecl)]
		public static extern AVOutputFormat av_guess_format (
			[MarshalAs(UnmanagedType.LPStr)] string short_name,
			[MarshalAs(UnmanagedType.LPStr)] string filename,
			[MarshalAs(UnmanagedType.LPStr)] string mime_type);

		public static int av_open_input_file (out AVFormatContext context, string filename)
		{
			return av_open_input_file (out context, filename, IntPtr.Zero, 0, IntPtr.Zero);
		}

		[DllImport("libavformat.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern int av_open_input_file ([MarshalAs (UnmanagedType.LPStruct)] out AVFormatContext context,
		                                              [MarshalAs (UnmanagedType.LPStr)] string filename,
		                                              IntPtr fmt,
		                                              int buf_size,
		                                              IntPtr ap);

		[DllImport ("libavformat.dll")]
		public static extern int av_open_input_file (
			[MarshalAs(UnmanagedType.LPStruct)] out AVFormatContext context,
			[MarshalAs (UnmanagedType.LPStr)] string filename,
			[MarshalAs(UnmanagedType.LPStruct)] ref AVInputFormat fmt,
			int buf_size,
			[MarshalAs(UnmanagedType.LPStruct)] ref AVFormatParameters ap);
	}
}