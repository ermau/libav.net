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
using System.Runtime.InteropServices;

namespace libavnet
{
	public unsafe class OutputFormat
		: Format, IDisposable
	{
		internal OutputFormat (IntPtr pFormat)
		{
			if (pFormat == IntPtr.Zero)
				throw new ArgumentException ("Null pointer");

			this.pFormat = pFormat;
			this.format = (AVOutputFormat*)pFormat;
			Names = Marshal.PtrToStringAnsi (new IntPtr (this.format->name));
			Description = Marshal.PtrToStringAnsi (new IntPtr (this.format->long_name));
		}

		public CodecID AudioCodec
		{
			get { return this.format->audio_codec; }
		}

		public CodecID VideoCodec
		{
			get { return this.format->video_codec; }
		}

		#region Cleanup
		public void Dispose()
		{
			Dispose (true);
			GC.SuppressFinalize (this);
		}

		protected void Dispose (bool disposing)
		{
		}

		~OutputFormat()
		{
			Dispose (false);
		}
		#endregion

		private readonly IntPtr pFormat;
		private readonly AVOutputFormat* format;

		public static OutputFormat Guess (string path)
		{
			IntPtr pFormat = FFmpeg.guess_format (null, path, null);
			if (pFormat == IntPtr.Zero)
				return null;

			return new OutputFormat (pFormat);
		}
	}
}