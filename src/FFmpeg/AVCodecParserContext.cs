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
	public unsafe struct AVCodecParserContext
	{
		public IntPtr priv_data;
		public AVCodecParser* parser;
		public long frame_offset;
		public long cur_offset;
		public long last_frame_offset;
		
		public int pict_type;
		public int repeat_pict;
		public long pts;
		public long dts;
		
		public long last_pts;
		public long last_dts;
		public int fetch_timestamp;
		public int cur_frame_start_index;
		public fixed long cur_frame_offset[FFmpeg.AV_PARSER_PTS_NB];
		public fixed long cur_frame_pts[FFmpeg.AV_PARSER_PTS_NB];
		public fixed long cur_frame_dts[FFmpeg.AV_PARSER_PTS_NB];
		public int flags;
	}
}