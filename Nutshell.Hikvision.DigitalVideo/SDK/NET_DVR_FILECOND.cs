using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Nutshell.Hikvision.DigitalVideo.SDK
{
        //录象文件查找条件结构
        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_FILECOND
        {
                public int ChannelIndex;//通道号
                public uint VideoFileType;//录象文件类型0xff－全部，0－定时录像,1-移动侦测 ，2－报警触发，
                                       //3-报警|移动侦测 4-报警&移动侦测 5-命令触发 6-手动录像
                public uint IsLocked;//是否锁定 0-正常文件,1-锁定文件, 0xff表示所有文件
                public uint IsUseCardNo;//是否使用卡号
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
                public byte[] sCardNumber;//卡号
                public NetDvrTime BeginNetDvrTime;//开始时间
                public NetDvrTime EndNetDvrTime;//结束时间
        }
}
