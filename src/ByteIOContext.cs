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

		public delegate int read_packet_delegate(IntPtr opaque, IntPtr buf, int buf_size);
		public read_packet_delegate read_packet;

		public delegate int write_packet_delegate (IntPtr opaque, IntPtr buf, int buf_size);
		public write_packet_delegate write_packet;

		public delegate int seek_delegate (IntPtr opaque, long offset, int whence);
		public seek_delegate seek;

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

		public delegate ulong update_checksum_delegate (ulong checksum, IntPtr buf, int size);
		public update_checksum_delegate update_checksum;

		public int error;

		public delegate int read_pause_delegate (IntPtr opaque, int pause);
		public read_pause_delegate read_pause;

		public delegate long read_seek_delegate (IntPtr opaque, int stream_index, long timestamp, int flags);
		public read_seek_delegate read_seek;
	}
}