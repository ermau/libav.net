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

namespace libavnet
{
	public unsafe class FormatContext
	{
		internal FormatContext (IntPtr formatPtr)
		{
			this.ptr = formatPtr;
			this.format = (AVFormatContext*)formatPtr;

			Title = Marshal.PtrToStringAnsi (new IntPtr (this.format->title));
			Author = Marshal.PtrToStringAnsi (new IntPtr (this.format->author));
			Copyright = Marshal.PtrToStringAnsi (new IntPtr (this.format->copyright));

			this.streams = new List<MediaStream> (this.format->nb_streams);
			for (int i = 0; i < this.format->nb_streams; ++i)
				this.streams.Add (new MediaStream (new IntPtr (this.format->streams[i])));
		}

		public string Title
		{
			get;
			private set;
		}

		public string Author
		{
			get;
			private set;
		}

		public string Copyright
		{
			get;
			private set;
		}

		public int Track
		{
			get { return this.format->tract; }
		}

		public int Year
		{
			get { return this.format->year; }
		}

		public CodecID AudioCodec
		{
			get { return this.format->audio_codec_id; }
		}

		public CodecID VideoCodec
		{
			get { return this.format->video_codec_id; }
		}

		public IEnumerable<MediaStream> Streams
		{
			get { return this.streams; }
		}

		public bool ReadPacket (out Packet packet)
		{
			packet = null;

			IntPtr pptr;
			if (FFmpeg.av_read_frame (this.ptr, out pptr) < 0)
				return false;

			AVPacket* p = (AVPacket*)pptr;
			packet = new Packet (pptr, this.streams[p->stream_index]);
			return true;
		}

		private readonly AVFormatContext* format;
		private readonly IntPtr ptr;
		private readonly List<MediaStream> streams;
	}
}