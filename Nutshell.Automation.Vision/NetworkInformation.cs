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

namespace Nutshell.Hardware.Vision
{
        /// <summary>
        /// 设备信息结构体
        /// </summary>
        public class NetworkInformation
        {
                /// <summary>
                /// MAC地址
                /// </summary>
                public PhysicalAddress MacAddress;

                /// <summary>
                /// IP地址
                /// </summary>
                public IPAddress IPAddress;

                /// <summary>
                /// 子网掩码
                /// </summary>
                public IPAddress SubNetMask;
        }
}
