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
	public struct AVStream
	{
		[MarshalAs(UnmanagedType.I4)]
		public int index; // stream index in AVFormatContext

		[MarshalAs(UnmanagedType.I4)]
		public int id; // format specific stream id

		public IntPtr codec; // AVCodecContext

		/**
			* real base frame rate of the stream.
			* for example if the timebase is 1/90000 and all frames have either
			* approximately 3600 or 1800 timer ticks then r_frame_rate will be 50/1
			*/
		public AVRational r_frame_rate;

		public IntPtr priv_data;

		[MarshalAs(UnmanagedType.I8)]
		public Int64 codec_info_duration; // internal data used in av_find_stream_info()

#if !AVFORMAT_VERSION_52



		[MarshalAs(UnmanagedType.I4)]
		public int codec_info_nb_frames;
#endif

		public AVFrac pts; // encoding: PTS generation when outputing stream

		/**
			* this is the fundamental unit of time (in seconds) in terms
			* of which frame timestamps are represented. for fixed-fps content,
			* timebase should be 1/framerate and timestamp increments should be
			* identically 1.
			*/
		public AVRational time_base;

		[MarshalAs(UnmanagedType.I4)]
		public int pts_wrap_bits; // number of bits in pts (used for wrapping control)

		[MarshalAs(UnmanagedType.I4)]
		public int stream_copy; // if TRUE, just copy stream

		public AVDiscard discard; // selects which packets can be discarded at will and dont need to be demuxed

		[MarshalAs(UnmanagedType.R4)]
		public float quality;

		[MarshalAs(UnmanagedType.I8)]
		public Int64 start_time;

		// decoding: duration of the stream, in AV_TIME_BASE fractional seconds.
		[MarshalAs(UnmanagedType.I8)]
		public Int64 duration;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] language; // ISO 639 3-letter language code (empty string if undefined)

		[MarshalAs(UnmanagedType.I4)]
		public int need_parsing;

		public IntPtr pAVCodecParserContext;

		[MarshalAs(UnmanagedType.I8)]
		public Int64 cur_dts;

		[MarshalAs(UnmanagedType.I4)]
		public int last_IP_duration;

		[MarshalAs(UnmanagedType.I8)]
		public Int64 last_IP_pts;

		public IntPtr pAVIndexEntry; // only used if the format does not support seeking natively

		[MarshalAs(UnmanagedType.I4)]
		public int nb_index_entries;

		[MarshalAs(UnmanagedType.I4)]
		public int index_entries_allocated_size;

		[MarshalAs(UnmanagedType.I8)]
		public Int64 nb_frames; // number of frames in this stream if known or 0

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = (FFmpeg.MAX_REORDER_DELAY + 1))]
		public Int64[] pts_buffer; // pts_buffer[MAX_REORDER_DELAY+1]
	}
}