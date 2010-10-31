using System;
using System.Runtime.InteropServices;

namespace libavnet
{
	[StructLayout (LayoutKind.Sequential)]
	public class AVClass
	{
		[MarshalAs (UnmanagedType.LPStr)]
		public string class_name;

		public delegate string item_name_delegate(IntPtr ctx);
		public item_name_delegate item_name;

		public IntPtr option;

		[MarshalAs (UnmanagedType.I4)]
		public int version;
		[MarshalAs (UnmanagedType.I4)]
		public int log_level_offset_offset;
		[MarshalAs (UnmanagedType.I4)]
		public int parent_log_context_offset;
	}
}