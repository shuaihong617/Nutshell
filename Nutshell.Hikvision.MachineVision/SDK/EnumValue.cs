// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-07-23
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-07-23
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Nutshell.Hikvision.MachineVision.SDK
{
        /// <summary>
        /// 枚举变量结构体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct EnumValue
        {
                /// <summary>
                /// 当前值
                /// </summary>
                public uint Current;      
                
                /// <summary>
                /// 支持值的个数
                /// </summary>
                public uint SupportCount;

                /// <summary>
                /// 支持值的集合
                /// </summary>
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
                public uint[] SupportValues;

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
                        return $"当前值:{Current}，支持值个数:{SupportCount}";
                }
        }
}
