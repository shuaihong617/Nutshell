using System.Runtime.InteropServices;

namespace Nutshell.Hikvision.SmartVision.Sdk
{
        public struct MatchInfoNetDetect
        {
                public long ReviceDataSize;    // 已接收数据大小  [统计StartGrabbing和StopGrabbing之间的数据量]
                public long LostPacketCount;   // 丢失的包数量
                public uint nLostFrameCount;    // 丢帧数量


                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
                public uint[] Reserved;          // 保留 
        }
}