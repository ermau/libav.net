//
// MIT License
// Copyright ©2003-2006 Tao Framework Team
// Copyright ©2010 Eric Maupin
// All rights reserved.

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

/* Define all previous supported version numbers
this is a hack to be able to test #if VERSION < 52
by doing #if !VERSION_52 */
#if AVFORMAT_VERSION_52
	#define AVFORMAT_VERSION_51
#elif AVFORMAT_VERSION_51
// nothing to do
#else
#define AVFORMAT_VERSION_51
#warning No version for avformat specified, defaulting to 51
#endif

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace libavnet
{
	public static unsafe partial class FFmpeg
	{
		private const CallingConvention CALLING_CONVENTION = CallingConvention.Cdecl;
		
		#if AVFORMAT_VERSION_52
		private const string AVFORMAT_NATIVE_LIBRARY = "avformat-52.dll";
		#elif AVFORMAT_VERSION_51
		private const string AVFORMAT_NATIVE_LIBRARY = "avformat-51.dll";
		#endif

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int register_protocol (IntPtr protocol);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void av_destruct_packet_nofree (IntPtr pAVPacket);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void av_destruct_packet (IntPtr pAVPacket);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void av_init_packet (IntPtr pAVPacket);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_new_packet (IntPtr pAVPacket, int size);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_get_packet (IntPtr pByteIOContext, IntPtr pAVPacket, int size);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_dup_packet (IntPtr pAVPacket);

		// av_free_packet is internal, so reimplemented in managed code
		public static void av_free_packet (IntPtr pAVPacket)
		{
			if (pAVPacket == IntPtr.Zero)
				return;

			AVPacket* p = (AVPacket*)pAVPacket.ToPointer();
			DestructCallback d =
				(DestructCallback)Marshal.GetDelegateForFunctionPointer ((*p).destruct, typeof (DestructCallback));
			d (pAVPacket);

			//AVPacket packet = (AVPacket) Marshal.PtrToStructure(pAVPacket, typeof (AVPacket));
			//if (packet.destruct == null)
			//    return;

			//packet.destruct(pAVPacket);
		}

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void av_register_image_format (IntPtr pAVImageFormat);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr av_probe_image_format (IntPtr pAVProbeData);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr guess_image_format ([MarshalAs (UnmanagedType.LPTStr)] string filename);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern CodecID av_guess_image2_codec ([MarshalAs (UnmanagedType.LPTStr)] string filename);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_read_image (IntPtr pByteIOContext,
		                                        [MarshalAs (UnmanagedType.LPTStr)] string filename,
		                                        IntPtr pAVImageFormat,
		                                        [MarshalAs (UnmanagedType.FunctionPtr)] AllocCBCallback alloc_cb,
		                                        IntPtr opaque);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_write_image (IntPtr pByteIOContext, IntPtr pAVImageFormat, IntPtr pAVImageInfo);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void av_register_input_format (IntPtr pAVInputFormat);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void av_register_output_format (IntPtr pAVOutputFormat);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr guess_stream_format ([MarshalAs (UnmanagedType.LPTStr)] string short_name,
		                                                 [MarshalAs (UnmanagedType.LPTStr)] string filename,
		                                                 [MarshalAs (UnmanagedType.LPTStr)] string mime_type);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr guess_format ([MarshalAs (UnmanagedType.LPTStr)] string short_name,
		                                          [MarshalAs (UnmanagedType.LPTStr)] string filename,
		                                          [MarshalAs (UnmanagedType.LPTStr)] string mime_type);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern CodecID av_guess_codec (IntPtr pAVOutoutFormat,
		                                             [MarshalAs (UnmanagedType.LPTStr)] string short_name,
		                                             [MarshalAs (UnmanagedType.LPTStr)] string filename,
		                                             [MarshalAs (UnmanagedType.LPTStr)] string mime_type,
		                                             CodecType type);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void av_hex_dump (IntPtr pFile, IntPtr buf, int size);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void av_pkt_dump (IntPtr pFile, IntPtr pAVPacket, int dump_payload);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void av_register_all();

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr av_find_input_format ([MarshalAs (UnmanagedType.LPTStr)] string short_name);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr av_probe_input_format (IntPtr pAVProbeData, int is_opened);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_open_input_file ([Out] out IntPtr pFormatContext,
		                                             [MarshalAs (UnmanagedType.LPStr)] string filename,
		                                             IntPtr pAVInputFormat, int buf_size, IntPtr pAVFormatParameters);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr av_alloc_format_context();

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_find_stream_info (IntPtr pAVFormatContext);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_read_packet (IntPtr pAVFormatContext, IntPtr pAVPacket);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_read_frame (IntPtr pAVFormatContext, IntPtr pAVPacket);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_seek_frame (IntPtr pAVFormatContext, int stream_index, Int64 timestamp, int flags);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_read_play (IntPtr pAVFormatContext);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_read_pause (IntPtr pAVFormatContext);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void av_close_input_stream (IntPtr pAVFormatContext);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void av_close_input_file (IntPtr pAVFormatContext);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr av_new_stream (IntPtr pAVFormatContext, int id);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr av_new_program (IntPtr pAVFormatContext, int id);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void av_set_pts_info (IntPtr pAVStream, int pts_wrap_bits, int pts_num, int pts_den);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_find_default_stream_index (IntPtr pAVFormatContext);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_index_search_timestamp (IntPtr pAVStream, Int64 timestamp, int flags);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_add_index_entry (IntPtr pAVStream, Int64 pos, Int64 timestamp, int size, int distance,
		                                             int flags);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_seek_frame_binary (IntPtr pAVFormatContext, int stream_index, Int64 target_ts, int flags);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void av_update_cur_dts (IntPtr pAVFormatContext, IntPtr pAVStream, Int64 timestamp);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_set_parameters (IntPtr pAVFormatContext, IntPtr pAVFormatParameters);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_write_header (IntPtr pAVFormatContext);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_write_frame (IntPtr pAVFormatContext, IntPtr pAVPacket);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_interleaved_write_frame (IntPtr pAVFormatContext, IntPtr pAVPacket);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_interleave_packet_per_dts (IntPtr pAVFormatContext, out IntPtr p_out_AVPacket,
		                                                       IntPtr pAVPacket, int flush);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_write_trailer (IntPtr pAVFormatContext);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void dump_format (IntPtr pAVFormatContext, int index,
		                                       [MarshalAs (UnmanagedType.LPTStr)] string url, int is_output);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int parse_image_size (IntPtr width_ptr, IntPtr height_ptr,
		                                           [MarshalAs (UnmanagedType.LPTStr)] string arg);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int parse_frame_rate (IntPtr pFrame_rate, IntPtr pFrame_rate_base,
		                                           [MarshalAs (UnmanagedType.LPTStr)] string arg);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern Int64 parse_date ([MarshalAs (UnmanagedType.LPTStr)] string datestr, int duration);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern Int64 av_gettime();

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern Int64 ffm_read_write_index (int fd);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void ffm_write_write_index (int fd, Int64 pos);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void ffm_set_write_index (IntPtr pAVFormatContext, Int64 pos, Int64 file_size);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int find_info_tag ([MarshalAs (UnmanagedType.LPTStr)] string arg,
		                                        int arg_size,
		                                        [MarshalAs (UnmanagedType.LPTStr)] string tag1,
		                                        [MarshalAs (UnmanagedType.LPTStr)] string info);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_get_frame_filename (IntPtr buf, int buf_size,
		                                                [MarshalAs (UnmanagedType.LPTStr)] string path, int number);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_filename_number_test ([MarshalAs (UnmanagedType.LPTStr)] string filename);

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int video_grab_init();

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int audio_init();

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int dv1394_init();

		[DllImport (AVFORMAT_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int dc1394_init();

		public const int AV_TIME_BASE = 1000000;
		public const int AVFMT_INFINITEOUTPUTLOOP = 0;

		[CLSCompliant (false)] public const uint AVFMT_FLAG_GENPTS = 0x0001;
		[CLSCompliant (false)] public const uint AVFMT_FLAG_IGNIDX = 0x0002;
		[CLSCompliant (false)] public const int AVFMT_NOOUTPUTLOOP = -1;
		[CLSCompliant (false)] public const uint AVFMT_NOFILE = 0x0001;
		[CLSCompliant (false)] public const uint AVFMT_NEEDNUMBER = 0x0002;
		[CLSCompliant (false)] public const uint AVFMT_SHOW_IDS = 0x0008;
		[CLSCompliant (false)] public const uint AVFMT_RAWPICTURE = 0x0020;
		[CLSCompliant (false)] public const uint AVFMT_GLOBALHEADER = 0x0040;
		[CLSCompliant (false)] public const uint AVFMT_NOTIMESTAMPS = 0x0080;
		[CLSCompliant (false)] public const uint AVIMAGE_INTERLEAVED = 0x0001;

		public const int AVPROBE_SCORE_MAX = 100;
		public const int PKT_FLAG_KEY = 0x0001;
		public const int AVINDEX_KEYFRAME = 0x001;
		public const int MAX_REORDER_DELAY = 4;

		[CLSCompliant (false)] public const uint AVFMTCTX_NOHEADER = 0x001;

		public const int MAX_STREAMS = 20;
		public const int AVERROR_UNKNOWN = -1;
		public const int AVERROR_IO = -2;
		public const int AVERROR_NUMEXPECTED = -3;
		public const int AVERROR_INVALIDDATA = -4;
		public const int AVERROR_NOMEM = -5;
		public const int AVERROR_NOFMT = -6;
		public const int AVERROR_NOTSUPP = -7;
		public const int AVSEEK_FLAG_BACKWARD = 1;
		public const int AVSEEK_FLAG_BYTE = 2;
		public const int AVSEEK_FLAG_ANY = 4;
		public const int FFM_PACKET_SIZE = 4096;

		public delegate void DestructCallback (IntPtr pAVPacket);
		public delegate int WriteHeader (IntPtr pAVFormatContext);
		public delegate int WritePacket (IntPtr pAVFormatContext, IntPtr pAVPacket);
		public delegate int WriteTrailer (IntPtr pAVFormatContext);
		public delegate int SetParametersCallback (IntPtr pAVFormatContext, IntPtr avFormatParameters);
		public delegate int InterleavePacketCallback (IntPtr pAVFormatContext, IntPtr pOutAVPacket, IntPtr pInAVPacket, int flush);
		public delegate int ReadProbeCallback (IntPtr pAVProbeData);
		public delegate int ReadHeaderCallback (IntPtr pAVFormatContext, IntPtr pAVFormatParameters);
		public delegate int ReadPacketCallback (IntPtr pAVFormatContext, IntPtr pAVPacket);
		public delegate int ReadCloseCallback (IntPtr pAVFormatContext);
		public delegate int ReadSeekCallback (IntPtr pAVFormatContext, int stream_index, Int64 timestamp, int flags);
		public delegate int ReadTimestampCallback (IntPtr pAVFormatContext, int stream_index, IntPtr pos, Int64 pos_limit);
		public delegate int ReadPlayCallback (IntPtr pAVFormatContext);
		public delegate int ReadPauseCallback (IntPtr pAVFormatContext);
		public delegate int AllocCBCallback (IntPtr pVoid, IntPtr pAVImageInfo);
	}
}
