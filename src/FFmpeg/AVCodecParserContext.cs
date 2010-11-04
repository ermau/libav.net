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
	public struct AVCodecParserContext
	{
		public IntPtr priv_data;
		public IntPtr parser; // AVCodecParser *parser
		[MarshalAs (UnmanagedType.I8)] public Int64 frame_offset; // offset of the current frame
		[MarshalAs (UnmanagedType.I8)] public Int64 cur_offset; // current offset incremented by each av_parser_parse()
		[MarshalAs (UnmanagedType.I8)] public Int64 last_frame_offset; // offset of the last frame
		/* video info */
		[MarshalAs (UnmanagedType.I4)] public int pict_type; /* XXX: put it back in AVCodecContext */
		[MarshalAs (UnmanagedType.I4)] public int repeat_pict; /* XXX: put it back in AVCodecContext */
		[MarshalAs (UnmanagedType.I8)] public Int64 pts; /* pts of the current frame */
		[MarshalAs (UnmanagedType.I8)] public Int64 dts; /* dts of the current frame */
		/* private data */
		[MarshalAs (UnmanagedType.I8)] public Int64 last_pts;
		[MarshalAs (UnmanagedType.I8)] public Int64 last_dts;
		[MarshalAs (UnmanagedType.I4)] public int fetch_timestamp;
		[MarshalAs (UnmanagedType.I4)] public int cur_frame_start_index;
		[MarshalAs (UnmanagedType.ByValArray, SizeConst = FFmpeg.AV_PARSER_PTS_NB)] public Int64[] cur_frame_offset;
		[MarshalAs (UnmanagedType.ByValArray, SizeConst = FFmpeg.AV_PARSER_PTS_NB)] public Int64[] cur_frame_pts;
		[MarshalAs (UnmanagedType.ByValArray, SizeConst = FFmpeg.AV_PARSER_PTS_NB)] public Int64[] cur_frame_dts;
		[MarshalAs (UnmanagedType.I4)] public int flags;
	}
}