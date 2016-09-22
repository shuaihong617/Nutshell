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
using System.Net;
using System.Net.NetworkInformation;

namespace Nutshell.Hardware.Vision.Hikvision.MachineVision
{
        /// <summary>
        /// 设备信息结构体
        /// </summary>
        public class DeviceInformation
        {
                /// <summary>
                /// 固件主版本号
                /// </summary>
                public Version FirewareVersion;

                /// <summary>
                /// MAC地址
                /// </summary>
                public PhysicalAddress MacAddress;

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
                public IPAddress CurrentIPAddress;

                /// <summary>
                /// 当前子网掩码（整型形式）
                /// </summary>
                public uint CurrentSubNetMask;

                /// <summary>
                /// 制造商名称
                /// </summary>
                public string ManufacturerName;

                /// <summary>
                /// 型号名称
                /// </summary>
                public string ModelName;

                /// <summary>
                /// 设备版本
                /// </summary>
                public string DeviceVersion;

                /// <summary>
                /// 制造批次等信息
                /// </summary>
                public string ManufacturerSpecificInfo;

                /// <summary>
                /// 序列号
                /// </summary>
                public string SerialNumber;

                /// <summary>
                /// 自定义名称
                /// </summary>
                public string UserDefinedName;
        }
}
