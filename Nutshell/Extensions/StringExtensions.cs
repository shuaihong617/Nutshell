// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-01-12
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-01-14
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Diagnostics.Contracts;

namespace Nutshell.Extensions
{
        /// <summary>
        ///         字符串扩展方法
        /// </summary>
        public static class StringExtensions
        {
                /// <summary>
                ///         当前字符串不能为空引用或空字符串
                /// </summary>
                /// <param name="value">判定字符串</param>
                /// <exception cref="System.ArgumentException">The value can't be null or empty</exception>
                public static void MustNotNullOrEmpty(this string value)
                {
                        if (String.IsNullOrEmpty(value))
                        {
                                throw new ArgumentException("不能为空引用或空字符串！");
                        }
                }

                /// <summary>
                ///         Determines whether the specified value is empty.
                /// </summary>
                /// <param name="value">The value.</param>
                /// <returns><c>true</c> if the specified value is empty; otherwise, <c>false</c>.</returns>
                /// <exception cref="System.ArgumentException">不能为空引用！</exception>
                public static bool IsEmpty(this string value)
                {
                        if (value == null)
                        {
                                throw new ArgumentException("不能为空引用！");
                        }
                        return value.Length == 0;
                }

                /// <summary>
                ///         Determines whether the specified value is empty.
                /// </summary>
                /// <param name="value">The value.</param>
                /// <returns><c>true</c> if [is null or empty] [the specified value]; otherwise, <c>false</c>.</returns>
                public static bool IsNullOrEmpty(this string value)
                {
                        return string.IsNullOrEmpty(value);
                }

                /// <summary>
                ///         Determines whether [is not null or empty] [the specified value].
                /// </summary>
                /// <param name="value">The value.</param>
                /// <returns><c>true</c> if [is not null or empty] [the specified value]; otherwise, <c>false</c>.</returns>
                [Pure]
                public static bool IsNotNullOrEmpty(this string value)
                {
                        return !string.IsNullOrEmpty(value);
                }

                /// <summary>
                ///         Requires the not null.
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="end">The end.</param>
                /// <returns>System.Object.</returns>
                /// <exception cref="System.ArgumentException">不能为空引用！</exception>
                public static void MustEndWith(this string value, string end)
                {
                        if (!value.EndsWith(end, StringComparison.CurrentCultureIgnoreCase))
                        {
                                throw new ArgumentException("字符串结尾！");
                        }
                }

                /// <summary>
                ///         中英文混排字符串左对齐
                /// </summary>
                /// <param name="str">源字符串</param>
                /// <param name="totalByteCount">对齐后总长度</param>
                /// <param name="c">填充字符</param>
                /// <returns>对齐后字符串</returns>
                public static string ChinesePadLeft(this string str, int totalByteCount, char c = ' ')
                {
                        //Encoding coding = Encoding.GetEncoding("gb2312");
                        //int dcount = str.Count(ch => coding.GetByteCount(ch.ToString(CultureInfo.InvariantCulture)) == 2);
                        //string w = str.PadRight(totalByteCount - dcount, c);
                        //return w;
                        throw new NotImplementedException();
                }

                /// <summary>
                ///         中英文混排字符串右对齐
                /// </summary>
                /// <param name="str">源字符串</param>
                /// <param name="totalByteCount">对齐后总长度</param>
                /// <param name="c">填充字符</param>
                /// <returns>对齐后字符串</returns>
                public static string ChinesePadRight(this string str, int totalByteCount, char c = ' ')
                {
                        //Encoding coding = Encoding.GetEncoding("gb2312");
                        //int dcount = str.Count(ch => coding.GetByteCount(ch.ToString(CultureInfo.InvariantCulture)) == 2);
                        //string w = str.PadRight(totalByteCount - dcount, c);
                        //return w;
                        throw new NotImplementedException();
                }

                public static T ToEnum<T>(this string source) where T : struct
                {
                        return (T)Enum.Parse(typeof(T), source);
                }

                public static bool ToBool(this string source)
                {
                        return Convert.ToBoolean(source);
                }

                public static bool ToBoolWithDefault(this string source, bool def = false)
                {
                        bool result;
                        return bool.TryParse(source, out result) ? result : def;
                }

                public static Byte ToByte(this string source)
                {
                        return Convert.ToByte(source);
                }

                public static Int16 ToInt16(this string source)
                {
                        return Convert.ToInt16(source);
                }

                public static Int32 ToInt32(this string source)
                {
                        return Convert.ToInt32(source);
                }

                public static Single ToSingle(this string source)
                {
                        return Convert.ToSingle(source);
                }
        }
}