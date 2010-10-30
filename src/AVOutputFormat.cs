using System;
using System.Runtime.InteropServices;

namespace libavnet
{
	[StructLayout (LayoutKind.Sequential)]
	public class AVOutputFormat
	{
		public delegate int write_header_delegate (ref AVFormatContext context);
		public delegate int write_packet_delegate (ref AVFormatContext context, ref AVPacket pkt);
		public delegate int write_trailer_delegate (ref AVFormatContext context);
		public delegate int set_parameters_delegate (ref AVFormatContext context, ref AVFormatParameters parameters);
		public delegate int interleave_packet_delegate (ref AVFormatContext context, ref AVPacket pout, AVPacket pin, int flush);

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

		public write_header_delegate write_header;
		public write_packet_delegate write_packet;
		public write_trailer_delegate write_trailer;

		public int flags;

		public set_parameters_delegate set_parameters;
		public interleave_packet_delegate interleave_packet;

		public IntPtr codec_tag;
		public int subtitle_codec;

		#if FF_API_OLD_METADATA
		public IntPtr metadata_conv;
		#endif

		private IntPtr next;
	}
}