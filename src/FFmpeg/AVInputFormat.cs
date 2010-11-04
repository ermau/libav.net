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
	public unsafe struct AVInputFormat
	{
		public byte* name;
		public byte* long_name;
		public int priv_data_size;

		//public FFmpeg.ReadProbeCallback read_probe;
		public IntPtr read_probe;

		//public FFmpeg.ReadHeaderCallback read_header;
		public IntPtr read_header;

		//public FFmpeg.ReadPacketCallback read_packet;
		public IntPtr read_packet;

		//public FFmpeg.ReadCloseCallback read_close;
		public IntPtr read_close;

		//public FFmpeg.ReadSeekCallback read_seek;
		public IntPtr read_seek;

		//public FFmpeg.ReadTimestampCallback read_timestamp;
		public IntPtr read_timestamp;

		// can use flags: AVFMT_NOFILE, AVFMT_NEEDNUMBER
		public int flags;
		public byte* extensions;
		public int value;

		//public FFmpeg.ReadPlayCallback read_play;
		public IntPtr read_play;

		//public FFmpeg.ReadPauseCallback read_pause;
		public IntPtr read_pause;

		public IntPtr nextAVInputFormat;
	}
}