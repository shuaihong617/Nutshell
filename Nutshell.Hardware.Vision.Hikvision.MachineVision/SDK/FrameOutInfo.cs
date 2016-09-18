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
using System.Runtime.InteropServices;

namespace Nutshell.Hardware.Vision.Hikvision.MachineVision.SDK
{
        /// <summary>
        /// 输出帧信息
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct FrameOutInfo
        {
                /// <summary>
                /// 图像宽度
                /// </summary>
                public ushort Width;

                /// <summary>
                /// 图像高度
                /// </summary>
                public ushort Height; 

                /// <summary>
                /// 像素格式
                /// </summary>
                public PixelType PixelType; 

                /*以下字段暂不支持*/

                /// <summary>
                /// 帧编号
                /// </summary>
                public uint FrameNum; 

                /// <summary>
                /// 时间戳高32位
                /// </summary>
                public uint DevTimeStampHigh;

                /// <summary>
                /// 时间戳低32位
                /// </summary>
                public uint DevTimeStampLow;

                /// <summary>
                /// 保留
                /// </summary>
                public uint Reserved0; 

                /// <summary>
                /// 主机生成的时间戳
                /// </summary>
                public long HostTimeStamp;

                /// <summary>
                /// // 保留
                /// </summary>
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] 
                public uint[] Reserved; 
        }
}
