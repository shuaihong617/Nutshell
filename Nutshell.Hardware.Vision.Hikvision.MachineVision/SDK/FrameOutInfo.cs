using System.Runtime.InteropServices;

namespace Nutshell.Hardware.Vision.Hikvision.MachineVision.SDK
{
        [StructLayout(LayoutKind.Sequential)]
        // 输出帧的信息
        public struct FrameOutInfo
        {
                public ushort Width; // 图像宽
                public ushort Height; // 图像高
                public PixelType PixelType; // 像素格式

                /*以下字段暂不支持*/
                public uint FrameNum; // 帧号
                public uint DevTimeStampHigh; // 时间戳高32位
                public uint DevTimeStampLow; // 时间戳低32位
                public uint Reserved0; // 保留，8字节对齐
                public long HostTimeStamp; // 主机生成的时间戳

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] 
                public uint[] Reserved; // 保留
        }
}
