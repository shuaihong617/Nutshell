// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-10-16
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-10-16
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
        /// </summary>
        public class ValueEventArgs<T> : EventArgs
        {
                /// <summary>
                ///         初始化<see cref="ValueEventArgs{T}" />的新实例.
                /// </summary>
                /// <param name="data">The result.</param>
                public ValueEventArgs(T data)
                {
                        Data = data;
                }

                /// <summary>
                ///         返回值
                /// </summary>
                public T Data { get; private set; }
        }
}