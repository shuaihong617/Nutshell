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
        /// 带值的事件参数
        /// </summary>
        public class ValueEventArgs<T> : EventArgs
        {
                /// <summary>
                ///         初始化<see cref="ValueEventArgs{T}" />的新实例.
                /// </summary>
                /// <param name="value">The result.</param>
                public ValueEventArgs(T value)
                {
                        Value = value;
                }

                /// <summary>
                ///         事件值
                /// </summary>
                public T Value { get; private set; }
        }
}