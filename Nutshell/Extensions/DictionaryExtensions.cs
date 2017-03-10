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
using System.Collections.ObjectModel;
using Nutshell.Aspects.Locations.Contracts;

namespace Nutshell.Extensions
{
        /// <summary>
        ///         字典接口扩展方法
        /// </summary>
        public static class DictionaryExtensions
        {
                /// <summary>
                ///         当前字典必须包含指定的键
                /// </summary>
                /// <typeparam name="TKey">键类型</typeparam>
                /// <typeparam name="TValue">值类型</typeparam>
                /// <param name="dist">字典</param>
                /// <param name="key">键</param>
                /// <exception cref="System.InvalidOperationException">必须包含指定的键</exception>
                public static void MustContainsKey<TKey, TValue>(
                        [MustNotEqualNull]this IDictionary<TKey, TValue> dist,
			TKey key)
                {
                        if (!dist.ContainsKey(key))
                        {
                                throw new InvalidOperationException("必须包含指定的键");
                        }
                }


                /// <summary>
                /// 当前字典必须不包含指定的键
                /// </summary>
                /// <typeparam name="TKey">键类型</typeparam>
                /// <typeparam name="TValue">值类型</typeparam>
                /// <param name="dictionary">字典</param>
                /// <param name="key">键</param>
                /// <exception cref="System.InvalidOperationException">不能包含指定的键</exception>
                public static  void MustNotContainsKey<TKey, TValue>(
                        [MustNotEqualNull]this IDictionary<TKey, TValue> dictionary,
			TKey key)
                {
                        if (dictionary.ContainsKey(key))
                        {
                                throw new InvalidOperationException("不能包含指定的键");
                        }
                }

		/// <summary>
		/// 返回字典的只读形式
		/// </summary>
		/// <typeparam name="TKey">键类型</typeparam>
		/// <typeparam name="TValue">值类型</typeparam>
		/// <param name="dictionary">字典</param>
		/// <returns>字典的只读形式</returns>
		public static ReadOnlyDictionary<TKey,TValue> ToReadOnlyDictionary<TKey, TValue>(
			[MustNotEqualNull]this IDictionary<TKey, TValue> dictionary)
		{
			return new ReadOnlyDictionary<TKey,TValue>(dictionary);
		}
	}
}