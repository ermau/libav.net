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
	public struct AVImageFormat
	{
		public delegate int ImgProbeCallback (IntPtr pAVProbeData);
		public delegate int ImgReadCallback (IntPtr pByteIOContext, [MarshalAs(UnmanagedType.FunctionPtr)] FFmpeg.AllocCBCallback alloc_cb, IntPtr pVoid);
		public delegate int ImgWriteCallback (IntPtr pByteIOContext, IntPtr pAVImageInfo);

		[MarshalAs(UnmanagedType.LPTStr)]
		public string name;

		[MarshalAs(UnmanagedType.LPTStr)]
		public string extensions;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		public ImgProbeCallback img_probe;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		public ImgReadCallback img_read;

		public int supported_pixel_formats; // mask of supported formats for output

		[MarshalAs(UnmanagedType.FunctionPtr)]
		public ImgWriteCallback img_write;

		public int flags;
		public IntPtr next; // AVImageFormat
	};
}