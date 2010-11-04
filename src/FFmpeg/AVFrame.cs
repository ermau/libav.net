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
	public struct AVFrame
	{
		[MarshalAs (UnmanagedType.ByValArray, SizeConst = 4)] public IntPtr[] data;
		[MarshalAs (UnmanagedType.ByValArray, SizeConst = 4)] public int[] linesize;
		[MarshalAs (UnmanagedType.ByValArray, SizeConst = 4)] public IntPtr[] @base;
		public int key_frame;
		/*
			 * Picture type of the frame, see ?_TYPE below.
			 * - encoding: Set by libavcodec. for coded_picture (and set by user for input).
			 * - decoding: Set by libavcodec.
			 */
		public int pict_type;
		/*
			 * presentation timestamp in time_base units (time when frame should be shown to user)
			 * If AV_NOPTS_VALUE then frame_rate = 1/time_base will be assumed.
			 * - encoding: MUST be set by user.
			 * - decoding: Set by libavcodec.
			 */
		public long pts;
		/*
			 * picture number in bitstream order
			 * - encoding: set by
			 * - decoding: Set by libavcodec.
			 */
		public int coded_picture_number;
		/*
			 * picture number in display order
			 * - encoding: set by
			 * - decoding: Set by libavcodec.
			 */
		public int display_picture_number;
		/*
			 * quality (between 1 (good) and FF_LAMBDA_MAX (bad)) 
			 * - encoding: Set by libavcodec. for coded_picture (and set by user for input).
			 * - decoding: Set by libavcodec.
			 */
		public int quality;
		/*
			 * buffer age (1->was last buffer and dint change, 2->..., ...).
			 * Set to INT_MAX if the buffer has not been used yet.
			 * - encoding: unused
			 * - decoding: MUST be set by get_buffer().
			 */
		public int age;
		/**
			 * is this picture used as reference
			 * - encoding: unused
			 * - decoding: Set by libavcodec. (before get_buffer() call)).
			 */
		public int reference;
		public byte[] qscale_table;
		/**
			 * QP store stride
			 * - encoding: unused
			 * - decoding: Set by libavcodec.
			 */
		public int qstride;
		/**
			 * mbskip_table[mb]>=1 if MB didn't change
			 * stride= mb_width = (width+15)>>4
			 * - encoding: unused
			 * - decoding: Set by libavcodec.
			 */
		public byte[] mbskip_table;
		[CLSCompliant (false)] public uint[] mb_type;
		public byte motion_subsample_log2;
		public IntPtr opaque;
		[MarshalAs (UnmanagedType.ByValArray, SizeConst = 4)] public long[] error;
		/*
			 * type of the buffer (to keep track of who has to deallocate data[*])
			 * - encoding: Set by the one who allocates it.
			 * - decoding: Set by the one who allocates it.
			 * Note: User allocated (direct rendering) & internal buffers cannot coexist currently.
			 */
		public int type;
		/*
			 * When decoding, this signals how much the picture must be delayed.
			 * extra_delay = repeat_pict / (2*fps)
			 * - encoding: unused
			 * - decoding: Set by libavcodec.
			 */
		public int repeat_pict;
		/*
			 * 
			 */
		public int qscale_type;
		/*
			 * The content of the picture is interlaced.
			 * - encoding: Set by user.
			 * - decoding: Set by libavcodec. (default 0)
			 */
		public int interlaced_frame;
		/*
			 * If the content is interlaced, is top field displayed first.
			 * - encoding: Set by user.
			 * - decoding: Set by libavcodec.
			 */
		public int top_field_first;
		public IntPtr pan_scan;
		/*
			 * Tell user application that palette has changed from previous frame.
			 * - encoding: ??? (no palette-enabled encoder yet)
			 * - decoding: Set by libavcodec. (default 0).
			 */
		public int palette_has_changed;
		/*
			 * codec suggestion on buffer type if != 0
			 * - encoding: unused
			 * - decoding: Set by libavcodec. (before get_buffer() call)).
			 */
		public int buffer_hints;
		/*
			 * DCT coefficients
			 * - encoding: unused
			 * - decoding: Set by libavcodec.
			 */
		public short[] dct_coeff;
		[MarshalAs (UnmanagedType.ByValArray, SizeConst = 2)] public IntPtr[] ref_index;
	} ;
}