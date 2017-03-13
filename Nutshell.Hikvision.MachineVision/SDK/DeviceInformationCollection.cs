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
using System.Runtime.InteropServices;

namespace Nutshell.Hikvision.MachineVision.SDK
{
        /// <summary>
        /// 设备信息列表
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct DeviceInformationCollection
        {
                /// <summary>
                /// 设备数量
                /// </summary>
                public uint Count;

                /// <summary>
                /// 设备信息数组
                /// </summary>
                /// <remark>
                /// 最多支持256台设备
                /// </remark>
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
                public IntPtr[] DeviceInfoPtrs;
        }
}