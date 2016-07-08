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
using System.Collections.Generic;
using System.Linq;

namespace Nutshell
{
        /// <summary>
        /// </summary>
        public class EffectiveValuesEventArgs<T> : EventArgs
        {
                /// <summary>
                ///         初始化<see cref="ValueChangedEventArgs{T}" />实例
                /// </summary>
                /// <param name="isEffective">if set to <c>true</c> [is effective].</param>
                private EffectiveValuesEventArgs(bool isEffective)
                {
                        IsEffective = isEffective;
                        Values = new List<T>();
                }

                /// <summary>
                ///         初始化<see cref="ValueChangedEventArgs{T}" />实例
                /// </summary>
                /// <param name="t">The t.</param>
                /// <param name="isEffective">if set to <c>true</c> [is effective].</param>
                public EffectiveValuesEventArgs(T t, bool isEffective)
                        : this(isEffective)
                {
                        Values.Add(t);
                }


                /// <summary>
                ///         初始化<see cref="ValueChangedEventArgs{T}" />实例
                /// </summary>
                /// <param name="t1">The t1.</param>
                /// <param name="t2">The t2.</param>
                /// <param name="isEffective">if set to <c>true</c> [is effective].</param>
                public EffectiveValuesEventArgs(T t1, T t2, bool isEffective)
                        : this(isEffective)
                {
                        Values.Add(t1);
                        Values.Add(t2);
                }

                /// <summary>
                ///         获取事件值
                /// </summary>
                /// <value>
                ///         事件值
                /// </value>
                public List<T> Values { get; private set; }

                /// <summary>
                ///         获取事件值
                /// </summary>
                /// <value>
                ///         事件值
                /// </value>
                public T Value
                {
                        get { return Values.First(); }
                }

                /// <summary>
                ///         获取数据是否有效
                /// </summary>
                /// <value>数据是否有效</value>
                public bool IsEffective { get; private set; }
        }
}