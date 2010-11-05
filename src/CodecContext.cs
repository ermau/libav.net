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
		private IntPtr ptr;
		private AVCodecContext* context;

		internal CodecContext (IntPtr ptr)
		{
			this.ptr = ptr;
			this.context = (AVCodecContext*)ptr;
		}

		public CodecID Codec
		{
			get { return this.context->codec_id; }
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