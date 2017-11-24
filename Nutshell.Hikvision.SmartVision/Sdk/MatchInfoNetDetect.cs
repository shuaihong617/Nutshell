// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-11-22
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-11-23
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
        ///         Struct MatchInfoNetDetect
        /// </summary>
        public struct MatchInfoNetDetect
        {
                /// <summary>
                ///         已接收数据大小  [统计StartGrabbing和StopGrabbing之间的数据量]
                /// </summary>
                public long ReceiveDataSize;

                /// <summary>
                ///         丢失的包数量
                /// </summary>
                public long LostPacketsCount;

                /// <summary>
                ///         丢帧数量
                /// </summary>
                public uint LostFramesCount;

                /// <summary>
                ///         保留
                /// </summary>
                [MarshalAs(UnmanagedType.U4, SizeConst = 5)] public uint[] Reserved;
        }
}