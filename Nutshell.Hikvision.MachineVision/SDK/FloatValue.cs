// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-07-17
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-07-17
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
        /// 设备信息结构体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct FloatValue
        {
                /// <summary>
                /// 当前值
                /// </summary>
                public float Current;

                /// <summary>
                /// 最大值
                /// </summary>
                public float Maximum;

                /// <summary>
                /// 最小值
                /// </summary>
                public float Minimum;

                
                

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] 
                public uint[] Reserved;

                
        }
}
