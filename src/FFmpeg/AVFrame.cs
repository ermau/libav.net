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
	public unsafe struct AVFrame
	{
		#if !X64
		public fixed int data[4];
		#else
		public fixed long data[4];
		#endif

		public fixed int linesize[4];
		#if !X64
		public fixed int @base[4];
		#else
		public fixed long @base[4];
		#endif

		public int key_frame;
		public int pict_type;
		public long pts;
		public int coded_picture_number;
		public int display_picture_number;
		public int quality;
		public int age;
		public int reference;
		public byte* qscale_table;
		public int qstride;
		public byte* mbskip_table;
		public uint* mb_type;
		public byte motion_subsample_log2;
		public IntPtr opaque;
		public fixed long error [4];
		public int type;
		public int repeat_pict;
		public int qscale_type;
		public int interlaced_frame;
		public int top_field_first;
		public IntPtr pan_scan;
		public int palette_has_changed;
		public int buffer_hints;
		public short* dct_coeff;

		#if !X64
		public fixed int ref_index [2];
		#else
		public fixed long ref_index[2];
		#endif
	} ;
}