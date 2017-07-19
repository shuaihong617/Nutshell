using System.Runtime.InteropServices;

namespace Nutshell.Hikvision.DigitalVideo.SDK
{
        //背光补偿配置
        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_BACKLIGHT
        {
                public byte byBacklightMode; /*背光补偿:0 off 1 UP、2 DOWN、3 LEFT、4 RIGHT、5MIDDLE、6自定义*/
                public byte byBacklightLevel; /*0x0-0xF*/
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
                public byte[] byRes1;
                public uint dwPositionX1; //（X坐标1）
                public uint dwPositionY1; //（Y坐标1）
                public uint dwPositionX2; //（X坐标2）
                public uint dwPositionY2; //（Y坐标2）
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
                public byte[] byRes2;
        }

}
