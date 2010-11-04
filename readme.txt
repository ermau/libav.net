libav.net is a library containing two wrappers for FFmpeg (specifically libavcodec, libavformat, libavutil and libavswscale).
libav.net does not include a redistribution for these libraries, you will have to obtain them yourself.

The primary wrapper is a cleaned up wrapper exposing no unsafeness or pointers to the developer. The idea is to make FFmpeg
sane to use under .NET.

The second wrapper is a low level direct that primarily exists to support the cleaned up wrapper, but is exposed for direct
access if necessary. It's a heavily modified version of the now defunct Tao Framework's wrapper. It's been modified to no
longer require copies (heavy Marshal.PtrToStructure use).