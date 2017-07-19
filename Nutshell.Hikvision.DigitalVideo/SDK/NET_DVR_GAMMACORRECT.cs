using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Nutshell.Hikvision.DigitalVideo.SDK
{
        //Gamma校正
        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_GAMMACORRECT
        {
                public byte byGammaCorrectionEnabled; /*0 dsibale  1 enable*/
                public byte byGammaCorrectionLevel; /*0-100*/
                [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
                public byte[] byRes;
        }
}
