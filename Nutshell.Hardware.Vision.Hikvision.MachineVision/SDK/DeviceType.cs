using System;

namespace Nutshell.Hardware.Vision.Hikvision.MachineVision.SDK
{
        [Flags]
        public enum DeviceType
        {
                UnknowDevice = 0x00000000, // 未知设备类型，保留意义
                GigeDevice = 0x00000001, // GigE设备
                FirewareDevice = 0x00000002, // 1394-a/b 设备
                UsbDevice = 0x00000004, // USB3.0 设备
                CameraLinkDevice = 0x00000008 // CameraLink设备
        }
}
