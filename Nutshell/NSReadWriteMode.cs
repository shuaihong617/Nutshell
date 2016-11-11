// ***********************************************************************

// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-10-24
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-10-24
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;

namespace Nutshell
{
        /// <summary>
        ///         读写模式枚举
        /// </summary>
        [Flags]
        public enum NSReadWriteMode
        {
                None = 0,

                /// <summary>
                ///         读
                /// </summary>
                Read = 1,

                /// <summary>
                ///         写
                /// </summary>
                Write = 2,

                /// <summary>
                ///         读和写
                /// </summary>
                ReadWrite = Read | Write,
        }
}