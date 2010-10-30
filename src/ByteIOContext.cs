using System;
using System.Runtime.InteropServices;

namespace libavnet
{
	public class ByteIOContext
	{
		public IntPtr buffer;
		public int buffer_size;
		public IntPtr buf_ptr;
		public IntPtr buf_end;
		public IntPtr opaque;

		public Func<int, IntPtr, IntPtr, int> read_packet;
		public Func<int, IntPtr, IntPtr, int> write_packet;
		public Func<long, IntPtr, long, int> seek;

		public long pos;
		[MarshalAs (UnmanagedType.Bool)]
		public bool must_flush;
		[MarshalAs (UnmanagedType.Bool)]
		public bool eof_reached;
		[MarshalAs (UnmanagedType.Bool)]
		public bool write_flag;
		[MarshalAs (UnmanagedType.Bool)]
		public bool is_streamed;

		public int max_packet_size;

		public ulong checksum;
		public IntPtr checksum_ptr;

		public Func<ulong, IntPtr, uint, long> update_checksum;

		public int error;

		public Func<int, IntPtr, int, long, int> read_pause;
	}
}