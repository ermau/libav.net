using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace libavnet
{
	[StructLayout (LayoutKind.Sequential)]
	public class AVFormatContext
	{
		public IntPtr av_class;
		public IntPtr iformat;
		public IntPtr oformat;
		private IntPtr priv_data;
		public IntPtr pb;
		public uint nb_streams;
		public IntPtr streams;

		[MarshalAs(UnmanagedType.LPStr, SizeConst = 1024)]
		public string filename;

		public long timestamp;
		#if FF_API_OLD_METADATA
		[MarshalAs(UnmanagedType.LPStr, SizeConst = 512)]
		public string title;
		[MarshalAs(UnmanagedType.LPStr, SizeConst = 512)]
		public string author;
		[MarshalAs(UnmanagedType.LPStr, SizeConst = 512)]
		public string copyright;
		[MarshalAs(UnmanagedType.LPStr, SizeConst = 512)]
		public string comment;
		[MarshalAs(UnmanagedType.LPStr, SizeConst = 512)]
		public string album;
		public int year;
		public int track;
		[MarshalAs(UnmanagedType.LPStr, SizeConst = 32)]
		public string genre;
		#endif

		public int ctx_flags;
		public IntPtr packet_buffer;
		public long start_time;
		public long duration;
		public long file_size;
		public int bit_rate;
		public IntPtr cur_st;

		#if FF_API_LAVF_UNUSED
		public IntPtr cur_ptr_deprecated;
		public int cur_len_deprecated;
		public IntPtr cur_pkt_deprecated;
		#endif

		public long data_offset;
		public int index_built;
		public int mux_rate;
		public uint packet_size;
		public int preload;
		public int max_delay;

		public int loop_output;
		public AVFMT_FLAGS flags;
		public int loop_input;
		public uint probesize;
		public int max_analyze_duration;
		
		public IntPtr key;
		public int keylen;

		public uint nb_programs;
		public IntPtr programs;

		public int video_codec_id;
		public int audio_codec_id;
		public int subtitle_codec_id;

		public uint max_index_size;
		public uint max_picture_buffer;
		
		public uint nb_chapters;
		public IntPtr chapters;

		public int debug;

		public IntPtr raw_packet_buffer;
		public IntPtr raw_packet_buffer_end;
		
		public IntPtr packet_buffer_end;

		public IntPtr metadata;

		public int raw_packet_buffer_remaining_size;
		public long start_time_realtime;
	}

	[Flags]
	public enum AVFMT_FLAGS
	{
		GENPTS = 0x0001,
		IGNIDX = 0x0002,
		NONBLOCK = 0x0004,
		IGNDTS = 0x0008,
		NOFILLIN = 0x0010,
		NOPARSE = 0x0020,
		RTP_HINT = 0x0040
	}
}