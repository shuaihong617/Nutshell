using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Nutshell.Hikvision.DigitalVideo.SDK
{
        //宽动态配置
        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_WDR
        {
                public byte byWDREnabled; /*宽动态：0 dsibale  1 enable 2 auto*/
                public byte byWDRLevel1; /*0-F*/
                public byte byWDRLevel2; /*0-F*/
                public byte byWDRContrastLevel; /*0-100*/
                [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
                public byte[] byRes;
        }
}
