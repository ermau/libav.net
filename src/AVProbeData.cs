using System;
using System.Runtime.InteropServices;

namespace libavnet
{
	[StructLayout (LayoutKind.Sequential)]
	public class AVProbeData
	{
		[MarshalAs (UnmanagedType.LPStr)]
		public string filename;

		public IntPtr buf;
		public int buf_size;
	}
}