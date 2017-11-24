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
        ///         条码识别结果结构体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct CodeRecognitionResultCollection
        {
                /// <summary>
                ///         已识别条码数量
                /// </summary>
                public uint RecognisedCodesCount;

                /// <summary>
                ///         条码识别结果数组
                /// </summary>
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 200)] public CodeRecognitionResult[]
                        CodeRecognitionResults;

                /// <summary>
                /// 保留
                /// </summary>
                [MarshalAs(UnmanagedType.U4, SizeConst = 4)] public uint[] Reserved;
        }
}