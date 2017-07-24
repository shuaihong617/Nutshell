using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Nutshell.Hikvision.DigitalVideo.SDK
{
        public struct NET_DVR_STREAM_INFO
        {
                public uint dwSize;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = OfficalAPI.STREAM_ID_LEN, ArraySubType = UnmanagedType.I1)]
                public byte[] byID;      //ID数据
                public uint dwChannel;                //关联设备通道，等于0xffffffff时，表示不关联
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
                public byte[] byRes;                //保留
                public void init()
                {
                        byID = new byte[OfficalAPI.STREAM_ID_LEN];
                        byRes = new byte[32];
                }
        }
}
