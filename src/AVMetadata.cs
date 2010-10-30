using System.Runtime.InteropServices;

namespace libavnet
{
	[StructLayout (LayoutKind.Sequential)]
	#if FF_API_OLD_METADATA
	public class AVMetadataConv
	#else
	public class AVMetadata
	#endif
	{
	}
}