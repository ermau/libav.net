//
// MIT License
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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace libavnet
{
	public unsafe class Codec
	{
		internal readonly IntPtr ptr;
		private readonly CodecContext context;
		private readonly AVCodec* codec;

		internal Codec (IntPtr ptr, CodecContext context)
		{
			if (context == null)
				throw new ArgumentNullException ("context");
			if (ptr == IntPtr.Zero)
				throw new ArgumentException ("Null pointer");

			this.ptr = ptr;
			this.context = context;
			this.codec = (AVCodec*)ptr;

			Name = Marshal.PtrToStringAnsi ((IntPtr)this.codec->name);
		}

		public string Name
		{
			get;
			private set;
		}

		public CodecID ID
		{
			get { return this.codec->id; }
		}

		public CodecType Type
		{
			get { return this.codec->type; }
		}

		public byte[][] DecodeAudio (Packet packet)
		{
			if (packet == null)
				throw new ArgumentNullException ("packet");

			List<byte[]> buffers = new List<byte[]>();

			byte[] buffer = new byte[FFmpeg.AVCODEC_MAX_AUDIO_FRAME_SIZE];
			
			int audio_pkt_size = packet.Size;

			fixed (byte* bptr = buffer)
			{
				while (audio_pkt_size > 0)
				{
					int data_size = buffer.Length;

					int len = FFmpeg.avcodec_decode_audio2 (this.context.ptr, (IntPtr)bptr, ref data_size, packet.packet->data, audio_pkt_size);
					if (len < 0)
						break;

					#if !X64
					packet.packet->data = new IntPtr (packet.packet->data.ToInt32() + len);
					#else
					packet.packet->data = new IntPtr (packet.packet->data.ToInt64() + len);
					#endif

					audio_pkt_size -= len;

					byte[] pcm = new byte[data_size];
					Array.Copy (buffer, pcm, data_size);
					buffers.Add (pcm);
				}
			}

			return buffers.ToArray();
		}
	}
}