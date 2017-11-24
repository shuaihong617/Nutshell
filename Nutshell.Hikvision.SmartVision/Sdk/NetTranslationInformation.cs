// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-11-24
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-11-24
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
        /// Struct _MVSC_NETTRANS_INFO_
        /// </summary>
        public struct NetTranslationInformation
        {
                /// <summary>
                /// GVSP通道接收的数据大小
                /// </summary>
                public long GvspReceiveDataSize; 
                /// <summary>
                /// GVSP通道抛出的帧数
                /// </summary>
                public int GvspThrowFrameCount;
                /// <summary>
                /// GVMP通道接收的数据大小
                /// </summary>
                public long GvmpReceiveDataSize;
                /// <summary>
                /// GVMP通道抛出的帧数
                /// </summary>
                public int GvmpThrowFrameCount;
                /// <summary>
                /// 保留
                /// </summary>
                [MarshalAs(UnmanagedType.U4, SizeConst = 24)]
                public uint[] Reserved;  
        }
}