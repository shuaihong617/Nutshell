// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-11-22
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-11-22
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Runtime.InteropServices;

namespace Nutshell.Hikvision.SmartVision.Sdk
{
        /// <summary>
        /// 设备信息结构体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct DeviceInfomation
        {
                /// <summary>
                /// 设备IP地址
                /// </summary>
                public uint DeviceIpAddress;

                /// <summary>
                /// 设备对应的网卡的IP地址
                /// </summary>
                public uint AdapterIpAddress;  

                /// <summary>
                /// 用户名称，需要用户填写
                /// </summary>
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)] public string UserName;

                /// <summary>
                /// 用户密码，需要用户填写
                /// </summary>
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] public string Password;

                /// <summary>
                /// 需要用户填写
                /// </summary>
                public uint ForceConnect;

                /// <summary>
                /// 设备Mac地址高2字节
                /// </summary>
                public ushort MacAddressHighBytes;

                /// <summary>
                /// 设备Mac地址低4字节
                /// </summary>
                public uint MacAddressLowByes;

                /// <summary>
                /// 设备Ip配置选项
                /// </summary>
                public uint IpCfgOption;

                /// <summary>
                /// 设备Ip配置:bit31-static bit30-dhcp bit29-lla 代表三种Ip配置选项
                /// </summary>
                public uint IpCfgCurrent;

                /// <summary>
                /// 当前子网掩码
                /// </summary>
                public uint CurrentSubNetMask;

                /// <summary>
                /// 默认网关
                /// </summary>
                public uint DefultGateWay;

                /// <summary>
                /// 制造商名称
                /// </summary>
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] public string ManufacturerName;

                /// <summary>
                /// 型号
                /// </summary>
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] public string ModelName;


                /// <summary>
                /// 设备版本
                /// </summary>
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] public string DeviceVersion;


                /// <summary>
                /// 制造商详细信息
                /// </summary>
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)] public string ManufacturerSpecificInfo;

                /// <summary>
                /// 序列号
                /// </summary>
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)] public string SerialNumber;

                /// <summary>
                /// 用户自定义名称
                /// </summary>
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)] public string UserDefinedName;

                /// <summary>
                /// 保留
                /// </summary>
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)] public uint[] Reserved;
        }
}