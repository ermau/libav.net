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

using System;
using System.Runtime.InteropServices;

namespace libavnet
{
	[StructLayout (LayoutKind.Sequential)]
	public unsafe struct AVFormatContext
	{
		public IntPtr pAVClass;
		public IntPtr pAVInputFormat;
		public IntPtr pAVOutputFormat;
		public IntPtr priv_data;

		#if AVFORMAT_VERSION_52
		public IntPtr pb;
		#else
		public ByteIOContext pb;
		#endif

		public int nb_streams;

		#if !X64
		public fixed int streams [FFmpeg.MAX_STREAMS];		
		#else
		public fixed long streams [ffmpeg.MAX_STREAMS];
		#endif

		public fixed byte filename [1024];
		public long timestamp;

		public fixed byte title[512];
		public fixed byte author[512];
		public fixed byte copyright[512];
		public fixed byte comment[512];
		public fixed byte album[512];
		public int year;
		public int tract;
		public fixed byte genre[32];

		public int ctx_flags;
		public IntPtr packet_buffer;
		public long start_time;
		public long duration;
		public long file_size;
		public int bit_rate;
		public IntPtr cur_st;
		public IntPtr cur_ptr;
		public int cur_len;
		public AVPacket cur_pkt;
		public long data_offset;
		public int index_built;
		public int mux_rate;
		public int packet_size;
		public int preload;
		public int max_delay;
		public int loop_output;
		public int flags;
		public int loop_input;
		public uint probesize;
		public int max_analyze_duration;
		public IntPtr key;
		public int keylen;
		public uint nb_programs;
		public IntPtr programs;
		public CodecID video_codec_id;
		public CodecID audio_codec_id;
		public CodecID subtitle_codec_id;
	}
}