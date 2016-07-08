using System.Runtime.InteropServices;

namespace Nutshell.Hardware.Vision.Mvsion.SDK
{
        [StructLayout(LayoutKind.Explicit)]
        public struct SpecialInfo
        {
                [FieldOffset(0)] 
                public GigeDeviceInfo GigeDeviceInfo;

                [FieldOffset(0)]
                public Usb3DeviceInfo Usb3DeviceInfo;
        }
}
