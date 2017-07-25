using System.Runtime.InteropServices;

namespace Nutshell.Hikvision.DigitalVideo.SDK
{
        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_COMPRESSION_INFO_V30
        {
                public byte byStreamType;//码流类型 0-视频流, 1-复合流, 表示事件压缩参数时最高位表示是否启用压缩参数
                public NetDvrResolution NetDvrResolution;//分辨率0-DCIF 1-CIF, 2-QCIF, 3-4CIF, 4-2CIF 5（保留）16-VGA（640*480） 17-UXGA（1600*1200） 18-SVGA （800*600）19-HD720p（1280*720）20-XVGA  21-HD900p
                public byte byBitrateType;//码率类型 0:变码率, 1:定码率
                public byte byPicQuality;//图象质量 0-最好 1-次好 2-较好 3-一般 4-较差 5-差
                public uint dwVideoBitrate;//视频码率 0-保留 1-16K 2-32K 3-48k 4-64K 5-80K 6-96K 7-128K 8-160k 9-192K 10-224K 11-256K 12-320K
                // 13-384K 14-448K 15-512K 16-640K 17-768K 18-896K 19-1024K 20-1280K 21-1536K 22-1792K 23-2048K
                //最高位(31位)置成1表示是自定义码流, 0-30位表示码流值.
                public uint dwVideoFrameRate;//帧率 0-全部; 1-1/16; 2-1/8; 3-1/4; 4-1/2; 5-1; 6-2; 7-4; 8-6; 9-8; 10-10; 11-12; 12-16; 13-20; V2.0版本中新加14-15; 15-18; 16-22;
                public ushort wIntervalFrameI;//I帧间隔
                //2006-08-11 增加单P帧的配置接口, 可以改善实时流延时问题
                public byte byIntervalBPFrame;//0-BBP帧; 1-BP帧; 2-单P帧
                public byte byres1; //保留
                public byte byVideoEncType;//视频编码类型 0 hik264;1标准h264; 2标准mpeg4;
                public byte byAudioEncType; //音频编码类型 0－OggVorbis
                public byte byVideoEncComplexity; //视频编码复杂度, 0-低, 1-中, 2高,0xfe:自动, 和源一致
                public byte byEnableSvc; //0 - 不启用SVC功能；1- 启用SVC功能
                public byte byFormatType; //封装类型, 1-裸流, 2-RTP封装, 3-PS封装, 4-TS封装, 5-私有, 6-FLV, 7-ASF, 8-3GP,9-RTP+PS（国标：GB28181）, 0xff-无效
                public byte byAudioBitRate; //音频码率0-默认, 1-8Kbps, 2- 16Kbps, 3-32Kbps, 4-64Kbps, 5-128Kbps, 6-192Kbps；(IPC5.1.0默认4-64Kbps)
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
                public byte[] byres;//这里保留音频的压缩参数
        }
}
