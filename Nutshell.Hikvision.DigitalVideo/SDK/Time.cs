using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Nutshell.Hikvision.DigitalVideo.SDK
{
        [StructLayout(LayoutKind.Sequential)]
        public struct Time
        {
                public uint Year;
                public uint Month;
                public uint Day;
                public uint Hour;
                public uint Minute;
                public uint Second;
        }
}
