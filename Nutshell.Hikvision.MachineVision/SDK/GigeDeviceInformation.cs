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

namespace Nutshell.Hikvision.MachineVision.SDK
{
        /// <summary>
        /// 千兆以太网摄像机设备信息
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct GigeDeviceInformation
        {
                /// <summary>
                /// IP配置选项
                /// </summary>
                public uint IpCfgOption;

                /// <summary>
                /// 当前IP配置选项
                /// </summary>
                /// <remark>
                /// bit31-static bit30-dhcp bit29-lla 
                /// </remark>
                public uint IpCfgCurrent; 

                /// <summary>
                /// 当前IP地址（整型形式）
                /// </summary>
                public uint CurrentIPAddress; 

                /// <summary>
                /// 当前子网掩码（整型形式）
                /// </summary>
                public uint CurrentSubNetMask;    

                /// <summary>
                /// 当前默认网关掩码（整型形式）
                /// </summary>
                public uint DefultGateWay;

                /// <summary>
                /// 制造商名称
                /// </summary>
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] 
                public string ManufacturerName;

                /// <summary>
                /// 型号名称
                /// </summary>
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
                public string ModelName;

                /// <summary>
                /// 设备版本
                /// </summary>
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
                public string DeviceVersion;

                /// <summary>
                /// 制造批次等信息
                /// </summary>
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
                public string ManufacturerSpecificInfo;

                /// <summary>
                /// 序列号
                /// </summary>
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
                public string SerialNumber;

                /// <summary>
                /// 自定义名称
                /// </summary>
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
                public string UserDefinedName;

                /// <summary>
                /// 网口IP地址  什么东西？不明白.
                /// </summary>
                public uint NetExport; // 

                /// <summary>
                /// 保留
                /// </summary>
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] 
                public uint[] Reserved;

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
