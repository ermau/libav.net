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
using System.Runtime.InteropServices;
using System.Security;

namespace libavnet
{
	public static partial class FFmpeg
	{
		private const string AVCODEC_NATIVE_LIBRARY = "avcodec-51.dll";

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr audio_resample_init (int output_channels, int input_channels,
		                                                 int output_rate, int input_rate);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int audio_resample (IntPtr pResampleContext, IntPtr output, IntPtr intput, int nb_samples);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void audio_resample_close (IntPtr pResampleContext);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr av_resample_init (int out_rate, int in_rate, int filter_length, int log2_phase_count,
		                                              int linear, double cutoff);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_resample (IntPtr pAVResampleContext, IntPtr dst, IntPtr src, IntPtr consumed, int src_size,
		                                      int udpate_ctx);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void av_resample_compensate (IntPtr pAVResampleContext, int sample_delta,
		                                                  int compensation_distance);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void av_resample_close (IntPtr pAVResampleContext);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr img_resample_init (int output_width, int output_height,
		                                               int input_width, int input_height);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr img_resample_full_init (int owidth, int oheight,
		                                                    int iwidth, int iheight,
		                                                    int topBand, int bottomBand,
		                                                    int leftBand, int rightBand,
		                                                    int padtop, int padbottom,
		                                                    int padleft, int padright);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void img_resample (IntPtr pImgReSampleContext, IntPtr p_output_AVPicture,
		                                        IntPtr p_input_AVPicture);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void ImgReSampleContext (IntPtr pImgReSampleContext);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int avpicture_alloc (IntPtr pAVPicture, int pix_fmt, int width, int height);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void avpicture_free (IntPtr pAVPicture);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int avpicture_fill (IntPtr pAVPicture, IntPtr ptr, int pix_fmt, int width, int height);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int avpicture_layout (IntPtr p_src_AVPicture, int pix_fmt, int width, int height,
		                                           IntPtr dest, int dest_size);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int avpicture_get_size (int pix_fmt, int width, int height);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void avcodec_get_chroma_sub_sample (int pix_fmt, IntPtr h_shift, IntPtr v_shift);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern string avcodec_get_pix_fmt_name (int pix_fmt);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void avcodec_set_dimensions (IntPtr pAVCodecContext, int width, int height);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern PixelFormat avcodec_get_pix_fmt ([MarshalAs (UnmanagedType.LPStr)] string name);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity,
		 CLSCompliant (false)]
		public static extern uint avcodec_pix_fmt_to_codec_tag (PixelFormat p);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_get_pix_fmt_loss (int dst_pix_fmt, int src_pix_fmt, int has_alpha);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_find_best_pix_fmt (int pix_fmt_mask, int src_pix_fmt, int has_alpha, IntPtr loss_ptr);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int img_get_alpha_info (IntPtr pAVPicture, int pix_fmt, int width, int height);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int img_convert (IntPtr p_dst_AVPicture, int dst_pix_fmt,
		                                      IntPtr p_src_AVPicture, int pix_fmt, int width, int height);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int avpicture_deinterlace (IntPtr p_dst_AVPicture, IntPtr p_src_AVPicture,
		                                                int pix_fmt, int width, int height);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity,
		 CLSCompliant (false)]
		public static extern uint avcodec_version();

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity,
		 CLSCompliant (false)]
		public static extern uint avcodec_build();

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity,
		 CLSCompliant (false)]
		public static extern uint avcodec_init();

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void register_avcodec (IntPtr pAVCodec);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr avcodec_find_encoder (CodecID id);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr avcodec_find_encoder_by_name (
			[MarshalAs (UnmanagedType.LPStr)] string mame);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr avcodec_find_decoder (CodecID id);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr avcodec_find_decoder_by_name (
			[MarshalAs (UnmanagedType.LPStr)] string mame);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void avcodec_string (
			[MarshalAs (UnmanagedType.LPStr)] string mam, int buf_size,
			IntPtr pAVCodeContext, int encode);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void avcodec_get_context_defaults (IntPtr pAVCodecContext);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr avcodec_alloc_context();

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void avcodec_get_frame_defaults (IntPtr pAVFrame);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr avcodec_alloc_frame();

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_default_get_buffer (IntPtr pAVCodecContext, IntPtr pAVFrame);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void avcodec_default_release_buffer (IntPtr pAVCodecContext, IntPtr pAVFrame);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void avcodec_default_reget_buffer (IntPtr pAVCodecContext, IntPtr pAVFrame);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void avcodec_align_dimensions (IntPtr pAVCodecContext, ref int width, ref int height);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity,
		 CLSCompliant (false)]
		public static extern int avcodec_check_dimensions (IntPtr av_log_ctx, ref uint width, ref uint height);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern PixelFormat avcodec_default_get_format (IntPtr pAVCodecContext, ref PixelFormat fmt);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_thread_init (IntPtr pAVCodecContext, int thread_count);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void avcodec_thread_free (IntPtr pAVCodecContext);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_thread_execute (IntPtr pAVCodecContext,
		                                                 [MarshalAs (UnmanagedType.FunctionPtr)] FuncCallback func,
		                                                 [MarshalAs (UnmanagedType.LPArray)] IntPtr[] arg, ref int ret,
		                                                 int count);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_default_execute (IntPtr pAVCodecContext,
		                                                  [MarshalAs (UnmanagedType.FunctionPtr)] FuncCallback func,
		                                                  [MarshalAs (UnmanagedType.LPArray)] IntPtr[] arg, ref int ret,
		                                                  int count);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_open (IntPtr pAVCodecContext, IntPtr pAVCodec);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_decode_audio (IntPtr pAVCodecContext,
		                                               IntPtr samples, [In, Out] ref int frame_size_ptr,
		                                               IntPtr buf, int buf_size);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_decode_audio2 (IntPtr pAVCodecContext,
		                                                IntPtr samples, [In, Out] ref int frame_size_ptr,
		                                                IntPtr buf, int buf_size);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_decode_video (IntPtr pAVCodecContext, IntPtr pAVFrame,
		                                               ref int got_picture_ptr, IntPtr buf, int buf_size);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_decode_subtitle (IntPtr pAVCodecContext, IntPtr pAVSubtitle,
		                                                  ref int got_sub_ptr, IntPtr buf, int buf_size);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_parse_frame (IntPtr pAVCodecContext,
		                                              [MarshalAs (UnmanagedType.LPArray)] IntPtr[] pdata,
		                                              IntPtr data_size_ptr, IntPtr buf, int buf_size);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_encode_audio (IntPtr pAVCodecContext, IntPtr buf, int buf_size,
		                                               IntPtr samples);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_encode_video (IntPtr pAVCodecContext, IntPtr buf, int buf_size,
		                                               IntPtr pAVFrame);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_encode_subtitle (IntPtr pAVCodecContext, IntPtr buf, int buf_size,
		                                                  IntPtr pAVSubtitle);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int avcodec_close (IntPtr pAVCodecContext);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void avcodec_register_all();

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void avcodec_flush_buffers (IntPtr pAVCodecContext);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void avcodec_default_free_buffers (IntPtr pAVCodecContext);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern byte av_get_pict_type_char (int pict_type);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_get_bits_per_sample (CodecID codec_id);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void av_register_codec_parser (IntPtr pAVcodecParser);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr av_parser_init (int codec_id);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_parser_parse (IntPtr pAVCodecParserContext,
		                                          IntPtr pAVCodecContext,
		                                          [MarshalAs (UnmanagedType.LPArray)] IntPtr[] poutbuf, ref int poutbuf_size,
		                                          IntPtr buf, int buf_size, Int64 pts, Int64 dts);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_parser_change (IntPtr pAVCodecParserContext,
		                                           IntPtr pAVCodecContext,
		                                           [MarshalAs (UnmanagedType.LPArray)] IntPtr[] poutbuf, ref int poutbuf_size,
		                                           IntPtr buf, int buf_size, int keyframe);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void av_parser_close (IntPtr pAVCodecParserContext);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void av_register_bitstream_filter (IntPtr pAVBitStreamFilter);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr av_bitstream_filter_init ([MarshalAs (UnmanagedType.LPStr)] string name);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int av_bitstream_filter_filter (IntPtr pAVBitStreamFilterContext,
		                                                     IntPtr pAVCodecContext,
		                                                     [MarshalAs (UnmanagedType.LPStr)] string args,
		                                                     [MarshalAs (UnmanagedType.LPArray)] IntPtr[] poutbuf,
		                                                     ref int poutbuf_size, IntPtr buf, int buf_size, int keyframe);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void av_bitstream_filter_close (IntPtr pAVBitStreamFilterContext);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity,
		 CLSCompliant (false)]
		public static extern void av_mallocz (uint size);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern IntPtr av_strdup ([MarshalAs (UnmanagedType.LPStr)] string s);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity,
		 CLSCompliant (false)]
		public static extern void av_fast_realloc (IntPtr ptr, ref uint size, ref uint min_size);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void av_free_static();

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity,
		 CLSCompliant (false)]
		public static extern void av_mallocz_static (uint size);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity,
		 CLSCompliant (false)]
		public static extern void av_realloc_static (IntPtr ptr, uint size);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern void img_copy (IntPtr pAVPicture, IntPtr p_src_AVPicture,
		                                    int pix_fmt, int width, int height);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int img_crop (IntPtr p_dst_pAVPicture, IntPtr p_src_pAVPicture,
		                                   int pix_fmt, int top_band, int left_band);

		[DllImport (AVCODEC_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public static extern int img_pad (IntPtr p_dst_pAVPicture, IntPtr p_src_pAVPicture,
		                                  int height, int width, int pix_fmt, int padtop, int padbottom,
		                                  int padleft, int padright, ref int color);


		/// <summary>
		/// 1 second of 48khz 32bit audio in bytes
		/// </summary>
		public const int AVCODEC_MAX_AUDIO_FRAME_SIZE = 192000;
		public const int FF_INPUT_BUFFER_PADDING_SIZE = 8;
		/*
		* minimum encoding buffer size.
		* used to avoid some checks during header writing
		*/
		public const int FF_MIN_BUFFER_SIZE = 16384;
		public const int FF_MAX_B_FRAMES = 16;
		/* encoding support
		these flags can be passed in AVCodecContext.flags before initing
		Note: not everything is supported yet.
		*/
		public const int CODEC_FLAG_QSCALE = 0x0002; // use fixed qscale
		public const int CODEC_FLAG_4MV = 0x0004; // 4 MV per MB allowed / Advanced prediction for H263
		public const int CODEC_FLAG_QPEL = 0x0010; // use qpel MC
		public const int CODEC_FLAG_GMC = 0x0020; // use GMC
		public const int CODEC_FLAG_MV0 = 0x0040; // always try a MB with MV=<0,0>
		public const int CODEC_FLAG_PART = 0x0080; // use data partitioning
		/* parent program gurantees that the input for b-frame containing streams is not written to
		for at least s->max_b_frames+1 frames, if this is not set than the input will be copied */
		public const int CODEC_FLAG_INPUT_PRESERVED = 0x0100;
		public const int CODEC_FLAG_PASS1 = 0x0200; // use internal 2pass ratecontrol in first pass mode
		public const int CODEC_FLAG_PASS2 = 0x0400; // use internal 2pass ratecontrol in second pass mode
		public const int CODEC_FLAG_EXTERN_HUFF = 0x1000; // use external huffman table (for mjpeg)
		public const int CODEC_FLAG_GRAY = 0x2000; // only decode/encode grayscale
		public const int CODEC_FLAG_EMU_EDGE = 0x4000; // don't draw edges
		public const int CODEC_FLAG_PSNR = 0x8000; // error[?] variables will be set during encoding
		public const int CODEC_FLAG_TRUNCATED = 0x00010000;
		/** input bitstream might be truncated at a random location instead
of only at frame boundaries */
		public const int CODEC_FLAG_NORMALIZE_AQP = 0x00020000; // normalize adaptive quantization
		public const int CODEC_FLAG_INTERLACED_DCT = 0x00040000; // use interlaced dct
		public const int CODEC_FLAG_LOW_DELAY = 0x00080000; // force low delay
		public const int CODEC_FLAG_ALT_SCAN = 0x00100000; // use alternate scan
		public const int CODEC_FLAG_TRELLIS_QUANT = 0x00200000; // use trellis quantization
		public const int CODEC_FLAG_GLOBAL_HEADER = 0x00400000; // place global headers in extradata instead of every keyframe
		public const int CODEC_FLAG_BITEXACT = 0x00800000; // use only bitexact stuff (except (i)dct)
		/* Fx : Flag for h263+ extra options */
		public const int CODEC_FLAG_H263P_AIC = 0x01000000; // H263 Advanced intra coding / MPEG4 AC prediction (remove this)
		public const int CODEC_FLAG_AC_PRED = 0x01000000; // H263 Advanced intra coding / MPEG4 AC prediction
		public const int CODEC_FLAG_H263P_UMV = 0x02000000; // Unlimited motion vector
		public const int CODEC_FLAG_CBP_RD = 0x04000000; // use rate distortion optimization for cbp
		public const int CODEC_FLAG_QP_RD = 0x08000000; // use rate distortion optimization for qp selectioon
		public const int CODEC_FLAG_H263P_AIV = 0x00000008; // H263 Alternative inter vlc
		public const int CODEC_FLAG_OBMC = 0x00000001; // OBMC
		public const int CODEC_FLAG_LOOP_FILTER = 0x00000800; // loop filter
		public const int CODEC_FLAG_H263P_SLICE_STRUCT = 0x10000000;
		public const int CODEC_FLAG_INTERLACED_ME = 0x20000000; // interlaced motion estimation
		public const int CODEC_FLAG_SVCD_SCAN_OFFSET = 0x40000000; // will reserve space for SVCD scan offset user data
		[CLSCompliant (false)] public const uint CODEC_FLAG_CLOSED_GOP = ((uint)0x80000000);
		public const int CODEC_FLAG2_FAST = 0x00000001; // allow non spec compliant speedup tricks
		public const int CODEC_FLAG2_STRICT_GOP = 0x00000002; // strictly enforce GOP size
		public const int CODEC_FLAG2_NO_OUTPUT = 0x00000004; // skip bitstream encoding
		public const int CODEC_FLAG2_LOCAL_HEADER = 0x00000008;
		// place global headers at every keyframe instead of in extradata
		public const int CODEC_FLAG2_BPYRAMID = 0x00000010; // H.264 allow b-frames to be used as references
		public const int CODEC_FLAG2_WPRED = 0x00000020; // H.264 weighted biprediction for b-frames
		public const int CODEC_FLAG2_MIXED_REFS = 0x00000040; // H.264 multiple references per partition
		public const int CODEC_FLAG2_8X8DCT = 0x00000080; // H.264 high profile 8x8 transform
		public const int CODEC_FLAG2_FASTPSKIP = 0x00000100; // H.264 fast pskip
		public const int CODEC_FLAG2_AUD = 0x00000200; // H.264 access unit delimiters
		public const int CODEC_FLAG2_BRDO = 0x00000400; // b-frame rate-distortion optimization
		public const int CODEC_FLAG2_INTRA_VLC = 0x00000800; // use MPEG-2 intra VLC table
		public const int CODEC_FLAG2_MEMC_ONLY = 0x00001000; // only do ME/MC (I frames -> ref, P frame -> ME+MC)
		/* Unsupported options :
		* Syntax Arithmetic coding (SAC)
		* Reference Picture Selection
		* Independant Segment Decoding */
		/* /Fx */
		/* codec capabilities */
		public const int CODEC_CAP_DRAW_HORIZ_BAND = 0x0001; // decoder can use draw_horiz_band callback
		/*
		* Codec uses get_buffer() for allocating buffers.
		* direct rendering method 1
		*/
		public const int CODEC_CAP_DR1 = 0x0002;
		/* if 'parse_only' field is true, then avcodec_parse_frame() can be
		used */
		public const int CODEC_CAP_PARSE_ONLY = 0x0004;
		public const int CODEC_CAP_TRUNCATED = 0x0008;
		/* codec can export data for HW decoding (XvMC) */
		public const int CODEC_CAP_HWACCEL = 0x0010;
		/*
		* codec has a non zero delay and needs to be feeded with NULL at the end to get the delayed data.
		* if this is not set, the codec is guranteed to never be feeded with NULL data
		*/
		public const int CODEC_CAP_DELAY = 0x0020;
		public const int CODEC_CAP_SMALL_LAST_FRAME = 0x0040;
		//the following defines may change, don't expect compatibility if you use them
		public const int MB_TYPE_INTRA4x4 = 0x001;
		public const int MB_TYPE_INTRA16x16 = 0x0002; //FIXME h264 specific
		public const int MB_TYPE_INTRA_PCM = 0x0004; //FIXME h264 specific
		public const int MB_TYPE_16x16 = 0x0008;
		public const int MB_TYPE_16x8 = 0x0010;
		public const int MB_TYPE_8x16 = 0x0020;
		public const int MB_TYPE_8x8 = 0x0040;
		public const int MB_TYPE_INTERLACED = 0x0080;
		public const int MB_TYPE_DIRECT2 = 0x0100; //FIXME
		public const int MB_TYPE_ACPRED = 0x0200;
		public const int MB_TYPE_GMC = 0x0400;
		public const int MB_TYPE_SKIP = 0x0800;
		public const int MB_TYPE_P0L0 = 0x1000;
		public const int MB_TYPE_P1L0 = 0x2000;
		public const int MB_TYPE_P0L1 = 0x4000;
		public const int MB_TYPE_P1L1 = 0x8000;
		public const int MB_TYPE_L0 = (MB_TYPE_P0L0 | MB_TYPE_P1L0);
		public const int MB_TYPE_L1 = (MB_TYPE_P0L1 | MB_TYPE_P1L1);
		public const int MB_TYPE_L0L1 = (MB_TYPE_L0 | MB_TYPE_L1);
		public const int MB_TYPE_QUANT = 0x00010000;
		public const int MB_TYPE_CBP = 0x00020000;
		//Note bits 24-31 are reserved for codec specific use (h264 ref0, mpeg1 0mv, ...)
		public const int FF_QSCALE_TYPE_MPEG1 = 0;
		public const int FF_QSCALE_TYPE_MPEG2 = 1;
		public const int FF_QSCALE_TYPE_H264 = 2;
		public const int FF_BUFFER_TYPE_INTERNAL = 1;
		public const int FF_BUFFER_TYPE_USER = 2; // Direct rendering buffers (image is (de)allocated by user)
		public const int FF_BUFFER_TYPE_SHARED = 4;
		// buffer from somewhere else, don't dealloc image (data/base), all other tables are not shared
		public const int FF_BUFFER_TYPE_COPY = 8; // just a (modified) copy of some other buffer, don't dealloc anything
		public const int FF_I_TYPE = 1; // Intra
		public const int FF_P_TYPE = 2; // Predicted
		public const int FF_B_TYPE = 3; // Bi-dir predicted
		public const int FF_S_TYPE = 4; // S(GMC)-VOP MPEG4
		public const int FF_SI_TYPE = 5;
		public const int FF_SP_TYPE = 6;
		public const int FF_BUFFER_HINTS_VALID = 0x01; // Buffer hints value is meaningful (if 0 ignore)
		public const int FF_BUFFER_HINTS_READABLE = 0x02; // Codec will read from buffer
		public const int FF_BUFFER_HINTS_PRESERVE = 0x04; // User must not alter buffer content
		public const int FF_BUFFER_HINTS_REUSABLE = 0x08; // Codec will reuse the buffer (update)
		public const int DEFAULT_FRAME_RATE_BASE = 1001000;
		public const int FF_ASPECT_EXTENDED = 15;
		public const int FF_RC_STRATEGY_XVID = 1;
		public const int FF_BUG_AUTODETECT = 1; // autodetection
		public const int FF_BUG_OLD_MSMPEG4 = 2;
		public const int FF_BUG_XVID_ILACE = 4;
		public const int FF_BUG_UMP4 = 8;
		public const int FF_BUG_NO_PADDING = 16;
		public const int FF_BUG_AMV = 32;
		public const int FF_BUG_AC_VLC = 0; // will be removed, libavcodec can now handle these non compliant files by default
		public const int FF_BUG_QPEL_CHROMA = 64;
		public const int FF_BUG_STD_QPEL = 128;
		public const int FF_BUG_QPEL_CHROMA2 = 256;
		public const int FF_BUG_DIRECT_BLOCKSIZE = 512;
		public const int FF_BUG_EDGE = 1024;
		public const int FF_BUG_HPEL_CHROMA = 2048;
		public const int FF_BUG_DC_CLIP = 4096;
		public const int FF_BUG_MS = 8192; // workaround various bugs in microsofts broken decoders
		// public const int FF_BUG_FAKE_SCALABILITY =16; //autodetection should work 100%
		public const int FF_COMPLIANCE_VERY_STRICT = 2;
		// strictly conform to a older more strict version of the spec or reference software
		public const int FF_COMPLIANCE_STRICT = 1;
		// strictly conform to all the things in the spec no matter what consequences
		public const int FF_COMPLIANCE_NORMAL = 0;
		public const int FF_COMPLIANCE_INOFFICIAL = -1; // allow inofficial extensions
		public const int FF_COMPLIANCE_EXPERIMENTAL = -2; // allow non standarized experimental things
		public const int FF_ER_CAREFUL = 1;
		public const int FF_ER_COMPLIANT = 2;
		public const int FF_ER_AGGRESSIVE = 3;
		public const int FF_ER_VERY_AGGRESSIVE = 4;
		public const int FF_DCT_AUTO = 0;
		public const int FF_DCT_FASTINT = 1;
		public const int FF_DCT_INT = 2;
		public const int FF_DCT_MMX = 3;
		public const int FF_DCT_MLIB = 4;
		public const int FF_DCT_ALTIVEC = 5;
		public const int FF_DCT_FAAN = 6;
		public const int FF_IDCT_AUTO = 0;
		public const int FF_IDCT_INT = 1;
		public const int FF_IDCT_SIMPLE = 2;
		public const int FF_IDCT_SIMPLEMMX = 3;
		public const int FF_IDCT_LIBMPEG2MMX = 4;
		public const int FF_IDCT_PS2 = 5;
		public const int FF_IDCT_MLIB = 6;
		public const int FF_IDCT_ARM = 7;
		public const int FF_IDCT_ALTIVEC = 8;
		public const int FF_IDCT_SH4 = 9;
		public const int FF_IDCT_SIMPLEARM = 10;
		public const int FF_IDCT_H264 = 11;
		public const int FF_IDCT_VP3 = 12;
		public const int FF_IDCT_IPP = 13;
		public const int FF_IDCT_XVIDMMX = 14;
		public const int FF_IDCT_CAVS = 15;
		public const int FF_EC_GUESS_MVS = 1;
		public const int FF_EC_DEBLOCK = 2;
		public const uint FF_MM_FORCE = 0x80000000; /* force usage of selected flags (OR) */
		// /* lower 16 bits - CPU features */
		public const int FF_MM_MMX = 0x0001; /* standard MMX */
		public const int FF_MM_3DNOW = 0x0004; /* AMD 3DNOW */
		public const int FF_MM_MMXEXT = 0x0002; /* SSE integer functions or AMD MMX ext */
		public const int FF_MM_SSE = 0x0008; /* SSE functions */
		public const int FF_MM_SSE2 = 0x0010; /* PIV SSE2 functions */
		public const int FF_MM_3DNOWEXT = 0x0020; /* AMD 3DNowExt */
		public const int FF_MM_IWMMXT = 0x0100; /* XScale IWMMXT */
		public const int FF_PRED_LEFT = 0;
		public const int FF_PRED_PLANE = 1;
		public const int FF_PRED_MEDIAN = 2;
		public const int FF_DEBUG_PICT_INFO = 1;
		public const int FF_DEBUG_RC = 2;
		public const int FF_DEBUG_BITSTREAM = 4;
		public const int FF_DEBUG_MB_TYPE = 8;
		public const int FF_DEBUG_QP = 16;
		public const int FF_DEBUG_MV = 32;
		public const int FF_DEBUG_DCT_COEFF = 0x00000040;
		public const int FF_DEBUG_SKIP = 0x00000080;
		public const int FF_DEBUG_STARTCODE = 0x00000100;
		public const int FF_DEBUG_PTS = 0x00000200;
		public const int FF_DEBUG_ER = 0x00000400;
		public const int FF_DEBUG_MMCO = 0x00000800;
		public const int FF_DEBUG_BUGS = 0x00001000;
		public const int FF_DEBUG_VIS_QP = 0x00002000;
		public const int FF_DEBUG_VIS_MB_TYPE = 0x00004000;
		public const int FF_DEBUG_VIS_MV_P_FOR = 0x00000001; //visualize forward predicted MVs of P frames
		public const int FF_DEBUG_VIS_MV_B_FOR = 0x00000002; //visualize forward predicted MVs of B frames
		public const int FF_DEBUG_VIS_MV_B_BACK = 0x00000004; //visualize backward predicted MVs of B frames
		public const int FF_CMP_SAD = 0;
		public const int FF_CMP_SSE = 1;
		public const int FF_CMP_SATD = 2;
		public const int FF_CMP_DCT = 3;
		public const int FF_CMP_PSNR = 4;
		public const int FF_CMP_BIT = 5;
		public const int FF_CMP_RD = 6;
		public const int FF_CMP_ZERO = 7;
		public const int FF_CMP_VSAD = 8;
		public const int FF_CMP_VSSE = 9;
		public const int FF_CMP_NSSE = 10;
		public const int FF_CMP_W53 = 11;
		public const int FF_CMP_W97 = 12;
		public const int FF_CMP_DCTMAX = 13;
		public const int FF_CMP_DCT264 = 14;
		public const int FF_CMP_CHROMA = 256;
		public const int FF_DTG_AFD_SAME = 8;
		public const int FF_DTG_AFD_4_3 = 9;
		public const int FF_DTG_AFD_16_9 = 10;
		public const int FF_DTG_AFD_14_9 = 11;
		public const int FF_DTG_AFD_4_3_SP_14_9 = 13;
		public const int FF_DTG_AFD_16_9_SP_14_9 = 14;
		public const int FF_DTG_AFD_SP_4_3 = 15;
		public const int FF_DEFAULT_QUANT_BIAS = 999999;
		public const int FF_LAMBDA_SHIFT = 7;
		public const int FF_LAMBDA_SCALE = (1 << FF_LAMBDA_SHIFT);
		public const int FF_QP2LAMBDA = 118; // factor to convert from H.263 QP to lambda
		public const int FF_LAMBDA_MAX = (256 * 128 - 1);
		public const int FF_CODER_TYPE_VLC = 0;
		public const int FF_CODER_TYPE_AC = 1;
		public const int SLICE_FLAG_CODED_ORDER = 0x0001; // draw_horiz_band() is called in coded order instead of display
		public const int SLICE_FLAG_ALLOW_FIELD = 0x0002; // allow draw_horiz_band() with field slices (MPEG2 field pics)
		public const int SLICE_FLAG_ALLOW_PLANE = 0x0004; // allow draw_horiz_band() with 1 component at a time (SVQ1)
		public const int FF_MB_DECISION_SIMPLE = 0; // uses mb_cmp
		public const int FF_MB_DECISION_BITS = 1; // chooses the one which needs the fewest bits
		public const int FF_MB_DECISION_RD = 2; // rate distoration
		public const int FF_AA_AUTO = 0;
		public const int FF_AA_FASTINT = 1; //not implemented yet
		public const int FF_AA_INT = 2;
		public const int FF_AA_FLOAT = 3;
		public const int FF_PROFILE_UNKNOWN = -99;
		public const int FF_LEVEL_UNKNOWN = -99;
		public const int X264_PART_I4X4 = 0x001; /* Analyse i4x4 */
		public const int X264_PART_I8X8 = 0x002; /* Analyse i8x8 (requires 8x8 transform) */
		public const int X264_PART_P8X8 = 0x010; /* Analyse p16x8, p8x16 and p8x8 */
		public const int X264_PART_P4X4 = 0x020; /* Analyse p8x4, p4x8, p4x4 */
		public const int X264_PART_B8X8 = 0x100; /* Analyse b16x8, b8x16 and b8x8 */
		public const int FF_COMPRESSION_DEFAULT = -1;
		public const int AVPALETTE_SIZE = 1024;
		public const int AVPALETTE_COUNT = 256;
		public const int FF_LOSS_RESOLUTION = 0x0001; /* loss due to resolution change */
		public const int FF_LOSS_DEPTH = 0x0002; /* loss due to color depth change */
		public const int FF_LOSS_COLORSPACE = 0x0004; /* loss due to color space conversion */
		public const int FF_LOSS_ALPHA = 0x0008; /* loss of alpha bits */
		public const int FF_LOSS_COLORQUANT = 0x0010; /* loss due to color quantization */
		public const int FF_LOSS_CHROMA = 0x0020; /* loss of chroma (e.g. rgb to gray conversion) */
		public const int FF_ALPHA_TRANSP = 0x0001; // image has some totally transparent pixels
		public const int FF_ALPHA_SEMI_TRANSP = 0x0002; // image has some transparent pixels
		public const int AV_PARSER_PTS_NB = 4;
		public const int PARSER_FLAG_COMPLETE_FRAMES = 0x0001;

		public delegate int FuncCallback (IntPtr pAVCodecContext, IntPtr parg);

		public delegate int ExecuteCallback (IntPtr pAVCodecContext,
		                                    [MarshalAs (UnmanagedType.FunctionPtr)] FuncCallback func,
		                                    [MarshalAs (UnmanagedType.LPArray)] IntPtr[] arg2, ref int ret, int count);

		public delegate int InitCallback (IntPtr pAVCodecContext);

		public delegate int EncodeCallback (IntPtr pAVCodecContext, IntPtr buf, int buf_size, IntPtr data);

		public delegate int CloseCallback (IntPtr pAVCodecContext);

		public delegate int DecodeCallback (IntPtr pAVCodecContext, IntPtr outdata, ref int outdata_size,
		                                   IntPtr buf, int buf_size);

		public delegate int FlushCallback(IntPtr pAVCodecContext);

		public delegate int ParaerInitCallback(IntPtr pAVCodecParserContext);

		public delegate int ParserParseCallback(IntPtr pAVCodecParserContext,
		                                        IntPtr pAVCodecContext,
		                                        [MarshalAs (UnmanagedType.LPArray)] IntPtr[] poutbuf,
		                                        ref int poutbuf_size,
		                                        IntPtr buf, int buf_size);

		public delegate void ParserCloseCallback(IntPtr pAVcodecParserContext);

		public delegate int SplitCallback(IntPtr pAVCodecContext, IntPtr buf, int buf_size);

		public delegate int FilterCallback (IntPtr pAVBitStreamFilterContext,
		                                   IntPtr pAVCodecContext,
		                                   [MarshalAs (UnmanagedType.LPStr)] string args,
		                                   [MarshalAs (UnmanagedType.LPArray)] IntPtr[] poutbuf, ref int poutbuf_size,
		                                   IntPtr buf, int buf_size, int keyframe);
	}

	public enum AVDiscard
	{
		//we leave some space between them for extensions (drop some keyframes for intra only or drop just some bidir frames)
		AVDISCARD_NONE = -16, //< discard nothing
		AVDISCARD_DEFAULT = 0, //< discard useless packets like 0 size packets in avi
		AVDISCARD_NONREF = 8, //< discard all non reference
		AVDISCARD_BIDIR = 16, //< discard all bidirectional frames
		AVDISCARD_NONKEY = 32, //< discard all frames except keyframes
		AVDISCARD_ALL = 48, //< discard all
	}

	public enum Motion_Est_ID
	{
		ME_ZERO = 1,
		ME_FULL,
		ME_LOG,
		ME_PHODS,
		ME_EPZS,
		ME_X1,
		ME_HEX,
		ME_UMH,
		ME_ITER,
	}

	[StructLayout (LayoutKind.Sequential)]
	public unsafe struct AVCodec
	{
		public byte* name;

		public CodecType type;
		public CodecID id;
		public int priv_data_size;
		
		//public FFmpeg.InitCallback init;
		public IntPtr init;
		
		//public FFmpeg.EncodeCallback encode;
		public IntPtr encode;
		
		//public FFmpeg.CloseCallback close;
		public IntPtr close;
		
		//public FFmpeg.DecodeCallback decode;
		public IntPtr decode;

		public int capabilities;

		public IntPtr next; // AVCodec *next

		//public FFmpeg.FlushCallback flush;
		public IntPtr flush;

		public IntPtr supported_framerates;
		public PixelFormat* pix_fmts; // enum PixelFormat *pix_fmts
	}
}