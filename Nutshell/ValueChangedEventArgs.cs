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
        /// 值变更事件参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class ValueChangedEventArgs<T> : EventArgs
        {
                /// <summary>
                ///         初始化<see cref="ValueChangedEventArgs{T}" />实例
                /// </summary>
                /// <param name="newValue">The new value.</param>
                /// <param name="oldValue">The old value.</param>
                public ValueChangedEventArgs(T newValue, T oldValue = default (T))
                {
                        NewValue = newValue;
                        OldValue = oldValue;
                }

                /// <summary>
                ///         新值
                /// </summary>
                public T NewValue { get; private set; }

                /// <summary>
                ///         旧值
                /// </summary>
                public T OldValue { get; private set; }
        }
}