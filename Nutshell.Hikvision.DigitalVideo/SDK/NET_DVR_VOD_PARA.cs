using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Nutshell.Hikvision.DigitalVideo.SDK
{
        public struct NET_DVR_VOD_PARA
        {
                public uint dwSize; //结构体大小
                public NET_DVR_STREAM_INFO struIDInfo; //流ID信息
                public NET_DVR_TIME struBeginTime;//回放开始时间
                public NET_DVR_TIME struEndTime;//回放结束时间
                public IntPtr hWnd;//回放窗口
                public byte byDrawFrame;//是否抽帧：0- 不抽帧，1- 抽帧
                public byte byVolumeType;//0-普通录像卷，1-存档卷，适用于CVR设备，普通卷用于通道录像，存档卷用于备份录像
                public byte byVolumeNum;//存档卷号 
                public byte byRes1;//保留
                public uint dwFileIndex;//存档卷上的录像文件索引，搜索存档卷录像时返回的值
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
                public byte[] byRes2;    //保留
        }
}
