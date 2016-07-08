// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-12-15
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-12-15
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
        ///         DateTime struce extensions
        /// </summary>
        public static class DateTimeExtensions
        {
                /// <summary>
                ///         The empty date time
                /// </summary>
                public static readonly DateTime Empty = DateTime.MinValue;

                /// <summary>
                ///         To the long string ex.
                /// </summary>
                /// <param name="dt">The dt.</param>
                /// <returns>String.</returns>
                public static DateTime GetThisHourLastSecond(this DateTime dt)
                {
                        return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, 59, 59);
                }

                /// <summary>
                ///         To the long string ex.
                /// </summary>
                /// <param name="dt">The dt.</param>
                /// <returns>String.</returns>
                public static String ToChineseLongString(this DateTime dt)
                {
                        return dt == Empty ? string.Empty : dt.ToString("yyyy年MM月dd日 HH:mm:ss");
                }

                public static String ToChineseLongFileNameWithoutExtension(this DateTime dt)
                {
                        return dt.ToString("yyyy年MM月dd日 HH_mm_ss");
                }


                /// <summary>
                ///         To the long string ex.
                /// </summary>
                /// <param name="dt">The dt.</param>
                /// <returns>String.</returns>
                public static String ToChineseLongMillisecondString(this DateTime dt)
                {
                        return dt == Empty ? string.Empty : dt.ToString("yyyy年MM月dd日 HH:mm:ss:fff");
                }

                /// <summary>
                ///         To the short string ex.
                /// </summary>
                /// <param name="dt">The dt.</param>
                /// <returns>String.</returns>
                public static String ToChineseShortString(this DateTime dt)
                {
                        return dt == Empty ? string.Empty : dt.ToString("yyyy年MM月dd日");
                }

                /// <summary>
                ///         Convert datetime struct to byte array.
                /// </summary>
                /// <param name="dateTime">The date time.</param>
                /// <returns>Byte[].</returns>
                public static Byte[] ToBytes(this DateTime dateTime)
                {
                        return BitConverter.GetBytes(dateTime.ToBinary());
                }

                /// <summary>
                ///         Convert datetime struct from byte array.
                /// </summary>
                /// <param name="bytes">The bytes.</param>
                /// <param name="startIndex">The start index.</param>
                /// <returns>DateTime.</returns>
                public static DateTime ToDateTime(this Byte[] bytes, int startIndex = 0)
                {
                        return DateTime.FromBinary(BitConverter.ToInt64(bytes, startIndex));
                }
        }
}