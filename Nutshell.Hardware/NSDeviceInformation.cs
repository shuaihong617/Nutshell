﻿// ***********************************************************************
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

namespace Nutshell.Hardware
{
        /// <summary>
        /// 设备信息结构体
        /// </summary>
        public class NSDeviceInformation
        {
                /// <summary>
                /// 制造商
                /// </summary>
                public string Manufacturer;

                /// <summary>
                /// 型号
                /// </summary>
                public string Model;

                /// <summary>
                /// 设备版本
                /// </summary>
                public Version DeviceVersion;

                /// <summary>
                /// 固件版本
                /// </summary>
                public Version FirewareVersion;

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
