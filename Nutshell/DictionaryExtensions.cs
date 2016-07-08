// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-04-14
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-03-11
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Collections.Generic;

namespace Nutshell
{
        /// <summary>
        ///         集合接口扩展方法
        /// </summary>
        public static class DictionaryExtensions
        {
                /// <summary>
                ///         Automatics the observable collection.
                /// </summary>
                /// <typeparam name="TKey">The type of the t key.</typeparam>
                /// <typeparam name="TValue">The type of the t value.</typeparam>
                /// <param name="dist">The dictionary.</param>
                /// <param name="key">The key.</param>
                /// <returns>Dictionary&lt;TKey, TValue&gt;.</returns>
                /// <exception cref="System.InvalidOperationException">必须包含指定的键</exception>
                public static IDictionary<TKey, TValue> MustContainsKey<TKey, TValue>(
                        this IDictionary<TKey, TValue> dist, TKey key)
                {
                        if (!dist.ContainsKey(key))
                        {
                                throw new InvalidOperationException("必须包含指定的键");
                        }

                        return dist;
                }


                /// <summary>
                ///         Musts the not contains key.
                /// </summary>
                /// <typeparam name="TKey">The type of the t key.</typeparam>
                /// <typeparam name="TValue">The type of the t value.</typeparam>
                /// <param name="dictionary">The dictionary.</param>
                /// <param name="key">The key.</param>
                /// <returns>IDictionary&lt;TKey, TValue&gt;.</returns>
                /// <exception cref="System.InvalidOperationException">不能包含指定的键</exception>
                public static  void MustNotContainsKey<TKey, TValue>(
                        this IDictionary<TKey, TValue> dictionary, TKey key)
                {
                        if (dictionary.ContainsKey(key))
                        {
                                throw new InvalidOperationException("不能包含指定的键");
                        }
                }
        }
}