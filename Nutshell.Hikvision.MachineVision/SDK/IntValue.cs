// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-03-08
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-03-09
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Runtime.InteropServices;

namespace Nutshell.Hikvision.MachineVision.SDK
{
        /// <summary>
        /// 整形变量结构体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct IntValue
        {
                /// <summary>
                /// 当前值
                /// </summary>
                public uint Current;

                /// <summary>
                /// 最大值
                /// </summary>
                public uint Maximum;

                /// <summary>
                /// 最小值
                /// </summary>
                public uint Minimum;

                /// <summary>
                /// 增量
                /// </summary>
                public uint Increase;

                /// <summary>
                /// 保留
                /// </summary>
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
                public uint[] Reserved;

                /// <summary>
                ///         返回表示当前对象的字符串。
                /// </summary>
                /// <returns>
                ///         表示当前对象的字符串。
                /// </returns>
                public override string ToString()
                {
                        return $"当前值：{Current}，最大值：{Maximum}，最小值：{Minimum}，增量：{Increase}";
                }
        }
}