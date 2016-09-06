// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-09-04
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-09-04
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************
using System;
using System.Runtime.InteropServices;

namespace Nutshell.Windows.Win32API
{
        /// <summary>
        /// 内存操作API.
        /// </summary>
        public static class MemoryAPIs
        {
                /// <summary>
                /// Copies the memory.
                /// </summary>
                /// <param name="dest">The dest.</param>
                /// <param name="src">The source.</param>
                /// <param name="count">The count.</param>
                [DllImport("kernel32.dll")]
                public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);
        }
}
