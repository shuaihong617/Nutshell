// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-06-28
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-06-28
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Linq;

namespace Nutshell
{
        /// <summary>
        ///         对象扩展方法
        /// </summary>
        public static class ObjectExtensions
        {
                /// <summary>
                ///         Requires the not null.
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="value">The value.</param>
                /// <returns>System.Object.</returns>
                /// <exception cref="System.ArgumentException">不能为空引用！</exception>
                public static void MustNotNull<T>(this T value, string message = "不能为空引用！") where T : class
                {
                        if (value == null)
                        {
                                throw new ArgumentException(message);
                        }
                }

                /// <summary>
                ///         Determines whether the specified value is null.
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="value">The value.</param>
                /// <returns><c>true</c> if the specified value is null; otherwise, <c>false</c>.</returns>
                public static bool IsNull<T>(this T value) where T : class
                {
                        return value == null;
                }


                /// <summary>
                ///         Determines whether the specified value is null.
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="value">The value.</param>
                /// <returns><c>true</c> if the specified value is null; otherwise, <c>false</c>.</returns>
                public static bool IsNotNull<T>(this T value) where T : class
                {
                        return value != null;
                }


                /// <summary>
                ///         Musts the in.
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="value">The t.</param>
                /// <param name="ps">The c.</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                public static void MustIn<T>(this T value, params T[] ps)
                {
                        if (ps.All(i => !i.Equals(value)))
                        {
                                throw new ArgumentException("必须在给定值范围内！");
                        }
                }


                /// <summary>
                ///         Musts the equal.
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="value">The value.</param>
                /// <param name="compare">The compare.</param>
                /// <returns>T.</returns>
                public static void MustEqual<T>(this T value, T compare)
                {
                        if (!value.Equals(compare))
                        {
                                throw new ArgumentException("必须与给定值相等！");
                        }
                }

                /// <summary>
                ///         Musts the not equal.
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="value">The value.</param>
                /// <param name="compare">The compare.</param>
                /// <returns>T.</returns>
                /// <exception cref="System.ArgumentException">不能与给定值相等！</exception>
                public static void MustNotEqual<T>(this T value, T compare)
                {
                        if (value.Equals(compare))
                        {
                                throw new ArgumentException("不能与给定值相等！");
                        }
                }
        }
}