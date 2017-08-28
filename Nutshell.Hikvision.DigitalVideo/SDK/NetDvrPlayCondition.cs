using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Nutshell.Hikvision.DigitalVideo.SDK
{
        [StructLayout(LayoutKind.Sequential)]
        public struct NetDvrPlayCondition
        {
                public uint Channel;
                public NetDvrTime StartTime;
                public NetDvrTime StopTime;
                public byte byDrawFrame;  //0:不抽帧，1：抽帧
                [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 63, ArraySubType = UnmanagedType.I1)]
                public byte[] byRes;    //保留
        }
}
