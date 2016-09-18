// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-07-17
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-07-31
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;

namespace Nutshell.Hardware.Vision.Hikvision.MachineVision.SDK
{
        /// <summary>
        /// Struct GigeDeviceInfo
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct GigeDeviceInfo
        {
                /// <summary>
                /// The n ip CFG option
                /// </summary>
                public uint nIpCfgOption;
                /// <summary>
                /// The n ip CFG current
                /// </summary>
                public uint nIpCfgCurrent; //IP configuration:bit31-static bit30-dhcp bit29-lla          
                /// <summary>
                /// The current ip address
                /// </summary>
                public uint CurrentIPAddress; //curtent ip          
                /// <summary>
                /// The n current sub net mask
                /// </summary>
                public uint nCurrentSubNetMask; //curtent subnet mask             
                /// <summary>
                /// The n defult gate way
                /// </summary>
                public uint nDefultGateWay; //current gateway

                /// <summary>
                /// The manufacturer name
                /// </summary>
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] 
                public string ManufacturerName;

                /// <summary>
                /// The ch model name
                /// </summary>
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
                public string chModelName;

                /// <summary>
                /// The ch device version
                /// </summary>
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
                public string chDeviceVersion;

                /// <summary>
                /// The ch manufacturer specific information
                /// </summary>
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
                public string chManufacturerSpecificInfo;

                /// <summary>
                /// The ch serial number
                /// </summary>
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
                public string chSerialNumber;

                /// <summary>
                /// The ch user defined name
                /// </summary>
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
                public string chUserDefinedName;

                /// <summary>
                /// The n net export
                /// </summary>
                public uint nNetExport; // 网口IP地址

                /// <summary>
                /// The n reserved
                /// </summary>
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
