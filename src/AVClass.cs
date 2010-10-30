using System;
using System.Runtime.InteropServices;

namespace libavnet
{
	[StructLayout (LayoutKind.Sequential)]
	public class AVClass
	{
		[MarshalAs (UnmanagedType.LPStr)]
		public string class_name;

		public Func<string, IntPtr> item_name;

		public IntPtr option;

		public int version;
		public int log_level_offset_offset;
		public int parent_log_context_offset;
	}
}