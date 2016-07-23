using System;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;

namespace Nutshell.Hardware.Vision.Hikvision.MachineVision.SDK
{
        [StructLayout(LayoutKind.Sequential)]
        public struct GigeDeviceInfo
        {
                public uint nIpCfgOption;
                public uint nIpCfgCurrent; //IP configuration:bit31-static bit30-dhcp bit29-lla          
                public uint CurrentIPAddress; //curtent ip          
                public uint nCurrentSubNetMask; //curtent subnet mask             
                public uint nDefultGateWay; //current gateway

                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] 
                public string ManufacturerName;

                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
                public string chModelName;

                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
                public string chDeviceVersion;

                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
                public string chManufacturerSpecificInfo;

                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
                public string chSerialNumber;

                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
                public string chUserDefinedName;

                public uint nNetExport; // 网口IP地址

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] 
                public uint[] nReserved;

                /// <summary>
                /// 获取设备当前IP地址
                /// </summary>
                /// <returns>设备当前IP地址</returns>
                public IPAddress GetCurrentIpAddress()
                {
                        var bytes = BitConverter.GetBytes(CurrentIPAddress).Reverse().ToArray();
                        return new IPAddress(bytes);
                }
        }
}
