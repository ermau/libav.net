using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace libavnet
{
	[StructLayout (LayoutKind.Sequential)]
	public class AVMetadataTag
	{
		[MarshalAs (UnmanagedType.LPStr)]
		public string key;
		
		[MarshalAs (UnmanagedType.LPStr)]
		public string value;
	}
}