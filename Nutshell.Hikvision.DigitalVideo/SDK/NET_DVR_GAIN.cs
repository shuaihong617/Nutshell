using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Nutshell.Hikvision.DigitalVideo.SDK
{
        //增益配置
        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_GAIN
        {
                public byte byGainLevel; /*增益：0-100*/
                public byte byGainUserSet; /*用户自定义增益；0-100，对于抓拍机，是CCD模式下的抓拍增益*/
                [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
                public byte[] byRes;
                public uint dwMaxGainValue;/*最大增益值，单位dB*/
        }
}
