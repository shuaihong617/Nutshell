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
        ///         Struct FrameOutInformation
        /// </summary>
        public struct FrameOutInformation
        {
                /// <summary>
                ///         图像宽
                /// </summary>
                public ushort Width;

                /// <summary>
                ///         图像高
                /// </summary>
                public ushort Height;

                /// <summary>
                ///         像素或图片格式
                /// </summary>
                public ImageType ImageType;

                /// <summary>
                ///         触发序号（仅在电平触发时有效）
                /// </summary>
                public uint TriggerIndex;

                /// <summary>
                ///         帧号
                /// </summary>
                public uint FrameNumber;

                /// <summary>
                ///         当前帧数据大小
                /// </summary>
                public uint FrameSize;

                /// <summary>
                ///         时间戳高32位
                /// </summary>
                public uint TimeStampHigh32Bits;

                /// <summary>
                ///         时间戳低32位
                /// </summary>
                public uint TimeStampLow32Bits;

                /// <summary>
                ///         输出的消息类型
                /// </summary>
                public uint ResultType;

                /// <summary>
                ///         根据消息类型对应不同的结构体
                /// </summary>
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024*64)] public string Result;

                /// <summary>
                ///         抠面单后的图片数据大小
                /// </summary>
                public uint FrameSizeForCutout;

                /// <summary>
                ///         是否误触发
                /// </summary>
                public uint FlaseTrigger;


                /// <summary>
                ///         聚焦得分
                /// </summary>
                public uint FocusScore;

                /// <summary>
                ///         保留
                /// </summary>
                [MarshalAs(UnmanagedType.U4, SizeConst = 5)] public uint[] Reserved;
        }
}