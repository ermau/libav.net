using System;
using System.Runtime.InteropServices;

namespace libavnet
{
	public delegate int write_header (ref AVFormatContext context);
	public delegate int write_packet (ref AVFormatContext context, ref AVPacket pkt);
	public delegate int write_trailer (ref AVFormatContext context);
	public delegate int set_parameters (ref AVFormatContext context, ref AVFormatParameters parameters);
	public delegate int interleave_packet (ref AVFormatContext context, ref AVPacket pout, AVPacket pin, int flush);

	[StructLayout (LayoutKind.Sequential)]
	public class AVOutputFormat
	{
		[MarshalAs(UnmanagedType.LPStr)]
		public string name;
		[MarshalAs(UnmanagedType.LPStr)]
		public string long_name;
		[MarshalAs(UnmanagedType.LPStr)]
		public string mime_type;
		[MarshalAs(UnmanagedType.LPStr)]
		public string extensions;

		public int priv_data_size;
		public int audio_codec;
		public int video_codec;

		public write_header write_header;
		public write_packet write_packet;
		public write_trailer write_trailer;

		public int flags;

		public set_parameters set_parameters;
		public interleave_packet interleave_packet;

		public IntPtr codec_tag;
		public int subtitle_codec;

		#if FF_API_OLD_METADATA
		public IntPtr metadata_conv;
		#endif

		private IntPtr next;
	}
}