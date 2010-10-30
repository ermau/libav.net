using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace libavnet
{
	[StructLayout (LayoutKind.Sequential)]
	public class AVChapter
	{
		public int id;
		public AVRational time_base;
		public long start;
		public long end;
		#if FF_API_OLD_METADATA
		[MarshalAs (UnmanagedType.LPStr)]
		public string title;
		#endif

		[MarshalAs (UnmanagedType.LPStruct)]
		public AVMetadata metadata;
	}
}