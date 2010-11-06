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

namespace libavnet
{
	public unsafe class CodecContext
	{
		internal readonly IntPtr ptr;
		private readonly AVCodecContext* context;

		private bool lookedForEncoder;
		private Codec encoder;
		private bool lookedForDecoder;
		private Codec decoder;

		internal CodecContext (IntPtr ptr)
		{
			if (ptr == IntPtr.Zero)
				throw new ArgumentException ("Null pointer");

			this.ptr = ptr;
			this.context = (AVCodecContext*)ptr;
		}

		public CodecID CodecID
		{
			get { return this.context->codec_id; }
		}

		public Codec Decoder
		{
			get
			{
				if (!this.lookedForDecoder)
				{
					IntPtr dptr = FFmpeg.avcodec_find_decoder (this.context->codec_id);
					if (dptr != IntPtr.Zero)
					{
						FFmpeg.avcodec_open (this.ptr, dptr).ThrowIfError();
						this.decoder = new Codec (dptr, this);
					}

					this.lookedForDecoder = true;
				}

				return this.decoder;
			}
		}

		public Codec Encoder
		{
			get
			{
				if (!this.lookedForEncoder)
				{
					IntPtr eptr = FFmpeg.avcodec_find_encoder (this.context->codec_id);
					if (eptr != IntPtr.Zero)
					{
						FFmpeg.avcodec_open (this.ptr, eptr).ThrowIfError();
						this.encoder = new Codec (eptr, this);
					}

					this.lookedForEncoder = true;
				}

				return this.encoder;
			}
		}

		public SampleFormat SampleFormat
		{
			get { return this.context->sample_fmt; }
		}

		public int SampleRate
		{
			get { return this.context->sample_rate; }
		}

		public int FrameSize
		{
			get { return this.context->frame_size; }
		}
	}
}