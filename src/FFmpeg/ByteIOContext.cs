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
	public struct ByteIOContext
	{
		public IntPtr buffer;
		public int buffer_size;
		public IntPtr buf_ptr;
		public IntPtr buf_end;
		public IntPtr opaque;
		
		//public FFmpeg.Read_PacketCallback read_packet;
		public IntPtr read_packet;

		//public FFmpeg.WritePacketCallback write_packet;
		public IntPtr write_packet;

		//public FFmpeg.SeekCallback seek;
		public IntPtr seek;

		public long pos;
		public int must_flush;
		public int eof_reached;
		public int write_flag;
		public int is_streamed;
		public int max_packet_size;
		public uint checksum;
		public IntPtr checksum_ptr;

		//public FFmpeg.UpdateChecksumCallback update_checksum;
		public IntPtr update_cheksum;
		
		public int error;
	}
}