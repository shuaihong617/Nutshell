// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-09-23
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-09-23
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************
using System.Runtime.InteropServices;

namespace Nutshell.Windows.SDK.APIs
{
        /// <summary>
        /// 内存信息结构体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MemoryInformation
        {
                /// <summary>
                /// The length
                /// </summary>
                public uint Length;
                /// <summary>
                /// 内存使用率
                /// </summary>
                public uint MemoryLoad;
                /// <summary>
                /// 总物理内存
                /// </summary>
                public uint TotalPhys;
                /// <summary>
                /// 可用物理内存
                /// </summary>
                public uint AvailPhys;
                /// <summary>
                /// 总交换文件大小
                /// </summary>
                public uint TotalPageFile;
                /// <summary>
                /// 可用交换文件大小
                /// </summary>
                public uint AvailPageFile;
                /// <summary>
                /// 总共虚拟内存大小
                /// </summary>
                public uint TotalVirtual;
                /// <summary>
                /// 可用虚拟内存大小
                /// </summary>
                public uint AvailVirtual;
        }
}
