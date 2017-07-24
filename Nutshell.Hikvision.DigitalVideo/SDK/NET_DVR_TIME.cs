using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Nutshell.Hikvision.DigitalVideo.SDK
{
        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_TIME
        {
                public uint dwYear;
                public uint dwMonth;
                public uint dwDay;
                public uint dwHour;
                public uint dwMinute;
                public uint dwSecond;
        }
}
