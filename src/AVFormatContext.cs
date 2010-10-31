#define FF_API_OLD_METADATA
#define FF_API_LAVF_UNUSED

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace libavnet
{
	[StructLayout (LayoutKind.Sequential)]
	public struct AVFormatContext
	{
	    public IntPtr av_class;
	    public IntPtr iformat;
	    public IntPtr oformat;
	    public IntPtr priv_data;
	    public IntPtr pb;
		
	    [MarshalAs (UnmanagedType.I4)]
	    public int nb_streams;
	    public IntPtr streams;

	    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 1024)]
	    public string filename;

	    [MarshalAs (UnmanagedType.I8)]
	    public long timestamp;
	    #if FF_API_OLD_METADATA
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	    public string title;
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	    public string author;
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	    public string copyright;
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	    public string comment;
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	    public string album;
	    [MarshalAs (UnmanagedType.I4)]
	    public int year;
	    [MarshalAs (UnmanagedType.I4)]
	    public int track;
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	    public string genre;
	    #endif

	    [MarshalAs (UnmanagedType.I4)]
	    public int ctx_flags;
	    public IntPtr packet_buffer;
	    [MarshalAs (UnmanagedType.I8)]
	    public long start_time;
	    [MarshalAs (UnmanagedType.I8)]
	    public long duration;
	    [MarshalAs (UnmanagedType.I8)]
	    public long file_size;
	    [MarshalAs (UnmanagedType.I4)]
	    public int bit_rate;
	    public IntPtr cur_st;

	    #if FF_API_LAVF_UNUSED
	    public IntPtr cur_ptr_deprecated;
	    [MarshalAs (UnmanagedType.I4)]
	    public int cur_len_deprecated;
	    public IntPtr cur_pkt_deprecated;
	    #endif

	    [MarshalAs (UnmanagedType.I8)]
	    public long data_offset;
	    [MarshalAs (UnmanagedType.I4)]
	    public int index_built;
	    [MarshalAs (UnmanagedType.I4)]
	    public int mux_rate;
	    [MarshalAs (UnmanagedType.U4)]
	    public uint packet_size;
	    [MarshalAs (UnmanagedType.I4)]
	    public int preload;
	    [MarshalAs (UnmanagedType.I4)]
	    public int max_delay;

	    [MarshalAs (UnmanagedType.I4)]
	    public int loop_output;
	    public AVFMT_FLAGS flags;

	    [MarshalAs (UnmanagedType.I4)]
	    public int loop_input;
	    [MarshalAs (UnmanagedType.U4)]
	    public uint probesize;
	    [MarshalAs (UnmanagedType.I4)]
	    public int max_analyze_duration;
		
	    public IntPtr key;
	    [MarshalAs (UnmanagedType.I4)]
	    public int keylen;

	    [MarshalAs (UnmanagedType.U4)]
	    public uint nb_programs;
	    public IntPtr programs;

	    [MarshalAs (UnmanagedType.I4)]
	    public int video_codec_id;
	    [MarshalAs (UnmanagedType.I4)]
	    public int audio_codec_id;
	    [MarshalAs (UnmanagedType.I4)]
	    public int subtitle_codec_id;

	    [MarshalAs (UnmanagedType.U4)]
	    public uint max_index_size;
	    [MarshalAs (UnmanagedType.U4)]
	    public uint max_picture_buffer;
		
	    [MarshalAs (UnmanagedType.U4)]
	    public uint nb_chapters;
	    public IntPtr chapters;

	    [MarshalAs (UnmanagedType.I4)]
	    public int debug;

	    public IntPtr raw_packet_buffer;
	    public IntPtr raw_packet_buffer_end;
		
	    public IntPtr packet_buffer_end;

	    public IntPtr metadata;

	    [MarshalAs (UnmanagedType.I4)]
	    public int raw_packet_buffer_remaining_size;
	    [MarshalAs (UnmanagedType.I8)]
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