using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace libavnet
{
	[StructLayout (LayoutKind.Sequential)]
	public class AVFormatParameters
	{
		public AVRational time_base;
		public int sample_rate;
		public int channels;
		public int width;
		public int height;
		public int pix_fmt;
		public int channel;

		[MarshalAs(UnmanagedType.LPStr)]
		public string standard;
		
		public uint bitvector1;
	
		public uint mpeg2ts_raw {
			get {
				return ((uint)((this.bitvector1 & 1u)));
			}
			set {
				this.bitvector1 = ((uint)((value | this.bitvector1)));
			}
		}
	
		public uint mpeg2ts_compute_pcr {
			get {
				return ((uint)(((this.bitvector1 & 2u) 
							/ 2)));
			}
			set {
				this.bitvector1 = ((uint)(((value * 2) 
							| this.bitvector1)));
			}
		}
	
		public uint initial_pause {
			get {
				return ((uint)(((this.bitvector1 & 4u) 
							/ 4)));
			}
			set {
				this.bitvector1 = ((uint)(((value * 4) 
							| this.bitvector1)));
			}
		}
	
		public uint prealloced_context {
			get {
				return ((uint)(((this.bitvector1 & 8u) 
							/ 8)));
			}
			set {
				this.bitvector1 = ((uint)(((value * 8) 
							| this.bitvector1)));
			}
		}

		#if FF_API_PARAMETERS_CODEC_ID
		public int video_codec_id;
		public int audio_codec_id;
		#endif
	}
}