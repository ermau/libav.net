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

namespace libavnet
{
	public enum SampleFormat
	{
		SAMPLE_FMT_NONE = -1,
		SAMPLE_FMT_U8, //< unsigned 8 bits
		SAMPLE_FMT_S16, //< signed 16 bits
		SAMPLE_FMT_S24, //< signed 24 bits
		SAMPLE_FMT_S32, //< signed 32 bits
		SAMPLE_FMT_FLT, //< float
	}

	public unsafe struct AVCodecContext
	{
		public AVClass* av_class;
		public int bit_rate;
		public int bit_rate_tolerance;
		public int flags;
		public int sub_id;
		public int me_method;
		public IntPtr extradata;
		public int extradata_size;
		public AVRational time_base;
		public int width;
		public int height;
		public int gop_size;
		public PixelFormat pix_fmt;
		public int rate_emu;
		
		//public FFmpeg.DrawhorizBandCallback draw_horiz_band;
		public IntPtr draw_horiz_band;
		
		public int sample_rate;
		public int channels;
		public SampleFormat sample_fmt;
		
		public int frame_size;
		public int frame_number;
		public int real_pict_num;
		
		public int delay;
		public float qcompress;
		public float qblur;
		public int qmin;
		public int qmax;
		public int max_qdiff;
		public int max_b_frames;
		public float b_quant_factor;
		
		public int rc_strategy;
		public int b_frame_strategy;
		public int hurry_up;
		public IntPtr codec;
		public IntPtr priv_data;
		
		/* unused, FIXME remove*/
		public int rtp_mode;
		public int rtp_payload_size;

		//public FFmpeg.RtpCallback rtp_callback;
		public IntPtr rtp_callback;

		public int mv_bits;
		public int header_bits;
		public int i_tex_bits;
		public int p_tex_bits;
		public int i_count;
		public int p_count;
		public int skip_count;
		public int misc_bits;
		public int frame_bits;
		public IntPtr opaque;
		public fixed byte codec_name [32];
		public CodecType codec_type;
		public CodecID codec_id;

		public uint codec_tag;
		public int workaround_bugs;
		public int luma_elim_threshold;
		public int chroma_elim_threshold;
		public int strict_std_compliance;
		public float b_quant_offset;
		public int error_resilience;

		//public FFmpeg.GetBufferCallback get_buffer;
		public IntPtr get_buffer;

		//public FFmpeg.ReleaseBufferCallback release_buffer;
		public IntPtr release_buffer;

		public int has_b_frames;
		public int block_align;
		public int parse_only;
		public int mpeg_quant;

		public byte* stats_out;
		public byte* stats_in;

		public float rc_qsquish;
		public float rc_qmod_amp;
		public int rc_qmod_freq;
		public RcOverride* rc_override;
		public int rc_override_count;

		public byte* rc_eq;

		public int rc_max_rate;
		public int rc_min_rate;
		public int rc_buffer_size;
		public float rc_buffer_aggressivity;
		public float i_quant_factor;
		public float i_quant_offset;
		public float rc_initial_cplx;
		public int dct_algo;
		public float lumi_masking;
		public float temporal_cplx_masking;
		public float spatial_cplx_masking;
		public float p_masking;
		public float dark_masking;
		public int unused;
		public int idct_algo;
		public int slice_count;
		public IntPtr slice_offset;
		public int error_concealment;
		public uint dsp_mask;
		public int bits_per_sample;
		public int prediction_method;
		public AVRational sample_aspect_ratio;
		public IntPtr coded_frame; // AVFrame* coded_frame;
		public int debug;
		public int debug_mv;
		
		public fixed long error[4];

		public int mb_qmin;
		public int mb_qmax;
		public int me_cmp;
		public int me_sub_cmp;
		public int mb_cmp;
		public int ildct_cmp;
		public int dia_size;
		public int last_predictor_count;
		public int pre_me;
		public int me_pre_cmp;
		public int pre_dia_size;

		//public FFmpeg.GetFormatCallback get_format;
		public IntPtr get_format;

		public int dtg_active_format;
		public int me_range;
		public int intra_quant_bias;
		public int inter_quant_bias;
		public int color_table_id;
		public int internal_buffer_count;
		public IntPtr internal_buffer;
		public int global_quality;
		public int coder_type;
		public int context_model;
		public int slice_flags;
		public int xvmc_acceleration;
		public int mb_decision;
		public IntPtr intra_matrix; // uint16_t* intra_matrix;
		public IntPtr inter_matrix; // uint16_t* inter_matrix;
		public uint stream_codec_tag;
		public int scenechange_threshold;
		public int lmin;
		public int lmax;
		public AVPaletteControl* palctrl; // AVPaletteControl *palctrl;
		public int noise_reduction;
		
		//public FFmpeg.RegetBufferCallback reget_buffer;
		public IntPtr reget_buffer;

		public int rc_initial_buffer_occupancy;
		public int inter_threshold;
		public int flags2;
		public int error_rate;
		public int antialias_algo;
		public int quantizer_noise_shaping;
		public int thread_count;
		
		//public FFmpeg.ExecuteCallback execute;
		public IntPtr execute;
		
		public IntPtr thread_opaque;
		public int me_threshold;
		public int mb_threshold;
		public int intra_dc_precision;
		public int nsse_weight;
		public int skip_top;
		public int skip_bottom;
		public int profile;
		public int level;
		public int lowres;
		public int coded_width, coded_height;
		public int frame_skip_threshold;
		public int frame_skip_factor;
		public int frame_skip_exp;
		public int frame_skip_cmp;
		public float border_masking;
		public int mb_lmin;
		public int mb_lmax;
		public int me_penalty_compensation;
		public AVDiscard skip_loop_filter;
		public AVDiscard skip_frame;
		public int bidir_refine;
		public int brd_scale;
		public int crf;
		public int cqp;
		public int keyint_min;
		public int refs;
		public int chromaoffset;
		public int bframebias;
		public int trellis;
		public float complexityblur;
		public int deblockalpha;
		public int deblockbeta;
		public int partitions;
		public int directpred;
		public int cutoff;
		public int scenechange_factor;
		public int mv0_threshold;
		public int b_sensitivity;
		public int compression_level;
		public int use_lpc;
		public int lpc_coeff_precision;
		public int min_prediction_order;
		public int max_prediction_order;
		public int prediction_order_method;
		public int min_partition_order;
		public int max_partition_order;
	}
}