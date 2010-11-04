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
	[StructLayout(LayoutKind.Sequential)]
	public struct AVFormatParameters
	{
		public AVRational time_base;

		public int sample_rate;
		public int channels;
		public int width;
		public int height;
		public PixelFormat pix_fmt;
		public IntPtr image_format; // AVImageFormat
		public int channel;

		#if !AVFORMAT_VERSION_52
		[MarshalAs(UnmanagedType.LPStr)]
		public string device;
		#endif

		[MarshalAs(UnmanagedType.LPStr)]
		public string standard;
		public int mpeg2ts_raw;
		public int mpeg2ts_compute_pcr;
		public int initial_pause;
		public int prealloced_context;

		#if !AVFORMAT_VERSION_52
		public CodecID video_codec_id;
		public CodecID audio_codec_id;
		#endif
	}
}