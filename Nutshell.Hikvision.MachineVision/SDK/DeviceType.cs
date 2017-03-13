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

namespace Nutshell.Hikvision.MachineVision.SDK
{
        /// <summary>
        /// 设备类型枚举
        /// </summary>
        [Flags]
        public enum DeviceType
        {
                /// <summary>
                /// 未知设备类型，保留意义
                /// </summary>
                UnknowDevice = 0x00000000,

                /// <summary>
                /// 千兆以太网设备
                /// </summary>
                GigeDevice = 0x00000001,

                /// <summary>
                /// 1394-a/b 设备
                /// </summary>
                FirewareDevice = 0x00000002,

                /// <summary>
                /// USB3.0 设备
                /// </summary>
                UsbDevice = 0x00000004,

                /// <summary>
                /// CameraLink设备
                /// </summary>
                CameraLinkDevice = 0x00000008
        }
}