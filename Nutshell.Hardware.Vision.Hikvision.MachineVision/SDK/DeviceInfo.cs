using System.Runtime.InteropServices;

namespace Nutshell.Hardware.Vision.Hikvision.MachineVision.SDK
{
        /// <summary>
        /// 设备信息结构体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct DeviceInfo
        {
                /// <summary>
                /// 主版本号
                /// </summary>
                public ushort MajorVer;

                /// <summary>
                /// 次版本号
                /// </summary>
                public ushort MinorVer;

                /// <summary>
                /// MAC地址高32位
                /// </summary>
                public uint MacAddrHigh;

                /// <summary>
                /// MAC地址低32位
                /// </summary>
                public uint MacAddrLow;

                /// <summary>
                /// 设备类型(通过传输层协议区分)
                /// </summary>
                public DeviceType DeviceType;

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] 
                public uint[] Reserved;

                public GigeDeviceInfo GigeDeviceInfo;
               
        }
}
