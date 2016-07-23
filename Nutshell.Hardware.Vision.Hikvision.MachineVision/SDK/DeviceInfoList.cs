using System;
using System.Runtime.InteropServices;

namespace Nutshell.Hardware.Vision.Hikvision.MachineVision.SDK
{
        /// <summary>
        /// 设备信息列表
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct DeviceInfoList
        {
                /// <summary>
                /// 设备数量
                /// </summary>
                public uint Count;

                /// <summary>
                /// 设备信息数组
                /// </summary>
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)] 
                public IntPtr[] DeviceInfoPtrs;
        }
}
