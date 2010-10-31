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

		[DllImport ("libavformat.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern AVOutputFormat av_guess_format (
			[MarshalAs(UnmanagedType.LPStr)] string short_name,
			[MarshalAs(UnmanagedType.LPStr)] string filename,
			[MarshalAs(UnmanagedType.LPStr)] string mime_type);

		[DllImport ("libavformat.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int av_guess_codec (
		    AVOutputFormat fmt,
		    [MarshalAs (UnmanagedType.LPStr)] string short_name,
		    [MarshalAs (UnmanagedType.LPStr)] string filename,
		    [MarshalAs (UnmanagedType.LPStr)] string mime_type,
		    AVMediaType type);

		//public static int av_open_input_file (out AVFormatContext context, string filename)
		//{
		//    IntPtr ctx_ptr;
		//    int result = av_open_input_file (out ctx_ptr, filename, IntPtr.Zero, 0, IntPtr.Zero);

		//    context = (AVFormatContext)Marshal.PtrToStructure (ctx_ptr, typeof (AVFormatContext));
		//    return result;
		//}

		[DllImport("libavformat.dll")]
		public static extern int av_open_input_file (out IntPtr context,
		                                              [MarshalAs (UnmanagedType.LPStr)] string filename,
		                                              IntPtr fmt,
		                                              int buf_size,
		                                              IntPtr ap);

		[DllImport ("libavformat.dll")]
		public static extern int av_open_input_file (
			[MarshalAs(UnmanagedType.LPStruct)] out AVFormatContext context,
			[MarshalAs (UnmanagedType.LPStr)] string filename,
			[MarshalAs(UnmanagedType.LPStruct)] AVInputFormat fmt,
			int buf_size,
			[MarshalAs(UnmanagedType.LPStruct)] AVFormatParameters ap);

		[DllImport ("libavformat.dll")]
		public static extern int av_find_stream_info (AVFormatContext ic);

		[DllImport ("libavformat.dll")]
		public static extern int av_find_stream_info (IntPtr ptr);
	}

	public enum AVMediaType
	{
		UNKNOWN = -1,
		VIDEO = 0,
		AUDIO = 1,
		DATA = 2,
		SUBTITLE = 3,
		ATTACHMENT = 4,
		NB = 5
	}
}