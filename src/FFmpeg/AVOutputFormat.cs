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
	public unsafe struct AVOutputFormat
	{
		public byte* name;
		public byte* long_name;
		public byte* mime_types;
		public byte* extensions;

		public int priv_data_size;

		public CodecID audio_codec;

		public CodecID video_codec;

		//public FFmpeg.WriteHeader write_header;
		public IntPtr write_header;

		//public FFmpeg.WritePacket write_packet;
		public IntPtr write_packet;

		//public FFmpeg.WriteTrailer write_trailer;
		public IntPtr write_trailer;

		public int flags;

		//public FFmpeg.SetParametersCallback set_parameters;
		public IntPtr set_parameters;

		//public FFmpeg.InterleavePacketCallback interleave_packet;
		public IntPtr interleave_packet;

		public IntPtr nextAVOutputFormat;
	}
}