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
using System.Security;

namespace libavnet
{
	public static partial class FFmpeg
	{
		private const string AVUTIL_NATIVE_LIBRARY = "avutil-49.dll";

		[DllImport (AVUTIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void av_free (IntPtr ptr);

		[DllImport (AVUTIL_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void av_freep (IntPtr ptr);

		public delegate int Read_PacketCallback (IntPtr opaque, IntPtr buf, int buf_size);
		public delegate int WritePacketCallback (IntPtr opaque, IntPtr buf, int buf_size);
		public delegate Int64 SeekCallback (IntPtr opaque, Int64 offset, int whence);

		[CLSCompliant (false)]
		public delegate UInt32 UpdateChecksumCallback (UInt32 checksum, IntPtr buf, UInt32 size);

		public delegate string ItemNameCallback();
	}

	public struct AVOption
	{
	}
}