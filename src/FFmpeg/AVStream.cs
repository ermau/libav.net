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
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct AVStream
	{
		public int index;
		public int id;

		public AVCodecContext* codec;
		public AVRational r_frame_rate;

		public IntPtr priv_data;

		public long codec_info_duration;

		#if !AVFORMAT_VERSION_52
		public int codec_info_nb_frames;
		#endif

		public AVFrac pts;

		public AVRational time_base;
		public int pts_wrap_bits;
		public int stream_copy;
		public AVDiscard discard;
		public float quality;
		public long start_time;

		public long duration;

		public fixed byte language[4];
		public int need_parsing;

		public IntPtr pAVCodecParserContext;
		public long cur_dts;

		public int last_IP_duration;
		public long last_IP_pts;
		public IntPtr pAVIndexEntry;
		public int nb_index_entries;
		public int index_entries_allocated_size;

		public long nb_frames;

		public fixed long pts_buffer[FFmpeg.MAX_REORDER_DELAY + 1];
	}
}