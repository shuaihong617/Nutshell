// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-11-03
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-11-03
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using Nutshell.Extensions;

namespace Nutshell
{
        /// <summary>
        ///         浮点数据类型扩展方法
        /// </summary>
        public static class SingleExtensions
        {
                /// <summary>
                ///         Convert datetime struct to byte array.
                /// </summary>
                /// <param name="value">The value.</param>
                /// <returns>Int16.</returns>
                public static Int16 ToInt16(this Single value)
                {
                        if (Single.IsNaN(value))
                        {
                                return 0;
                        }

                        return Convert.ToInt16(value%32768);
                }

                /// <summary>
                ///         To the int16.
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="max">The maximum.</param>
                /// <returns>Int16.</returns>
                public static Int16 ToInt16(this Single value, short max)
                {
                        max.MustNotNegative();

                        short min = Convert.ToInt16(-1*max);
                        short r = value.ToInt16();


                        if (r > max)
                        {
                                return max;
                        }

                        if (r < min)
                        {
                                return min;
                        }

                        return r;
                }


                /// <summary>
                ///         Convert datetime struct to byte array.
                /// </summary>
                /// <param name="value">The value.</param>
                /// <returns>Int16.</returns>
                public static int ToInt32(this float value)
                {
                        if (float.IsNaN(value))
                        {
                                return 0;
                        }

                        return Convert.ToInt32(value%32768);
                }

                /// <summary>
                ///         To the int16.
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="max">The maximum.</param>
                /// <returns>Int16.</returns>
                public static int ToInt32(this float value, short max)
                {
                        max.MustNotNegative();

                        short min = Convert.ToInt16(-1*max);
                        int r = value.ToInt32();


                        if (r > max)
                        {
                                return max;
                        }

                        if (r < min)
                        {
                                return min;
                        }


                        return r;
                }

                /// <summary>
                /// 检验一个浮点数是否为一个可进行数学运算的浮点数
                /// </summary>
                /// <param name="value">The value.</param>
                /// <returns>System.Single.</returns>
                public static float MustNumber(this float value)
                {
                        Debug.Assert(!Single.IsNaN(value));
                        Debug.Assert(!Single.IsNegativeInfinity(value));
                        Debug.Assert(!Single.IsPositiveInfinity(value));

                        return value;
                }

                /// <summary>
                ///         数字必须大于给定值, 否则引发异常
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="compare">The compare.</param>
                /// <returns>System.Single.</returns>
                /// <exception cref="System.ArgumentException">必须大于 + compare</exception>
                public static float MustGreaterThan(this float value, float compare)
                {
                        value.MustNumber();
                        compare.MustNumber();

                        if (value <= compare)
                        {
                                throw new ArgumentOutOfRangeException("必须大于" + compare);
                        }

                        return value;
                }


                /// <summary>
                ///         将一个浮点数转化为一个可进行数学运算的浮点数
                /// </summary>
                /// <param name="value">给定的浮点数</param>
                /// <param name="nan">当浮点数为非数字时的返回值</param>
                /// <returns>System.Single.</returns>
                public static float WillNumber(this float value, float nan = 0)
                {
                        if (Single.IsNaN(value))
                        {
                                return nan;
                        }

                        if (Single.IsNegativeInfinity(value))
                        {
                                return Single.MinValue;
                        }

                        if (Single.IsPositiveInfinity(value))
                        {
                                return Single.MaxValue;
                        }

                        return value;
                }

                /// <summary>
                ///         数字是否在一定精度下与给定浮点数相等
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="compare">The compare.</param>
                /// <param name="threshold">The threshold.</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                [Pure]
                public static bool IsEqual(this float value, float compare, float threshold = 0.01f)
                {
                        value.MustNumber();
                        compare.MustNumber();
                        threshold.MustGreaterThan(0);

                        if (Math.Abs(value - compare) < threshold)
                        {
                                return true;
                        }


                        return false;
                }

                /// <summary>
                ///         Requires the not null.
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="minValue">The min value.</param>
                /// <param name="maxValue">The max value.</param>
                /// <returns>System.Object.</returns>
                /// <exception cref="System.ArgumentException">The value can't be null or empty</exception>
                public static float RequireInRange(this float value,
                        float minValue, float maxValue)
                {
                        if (value > maxValue || value < minValue)
                        {
                                throw new ArgumentException("必须大于" + minValue + "并小于" + maxValue);
                        }
                        return value;
                }

                /// <summary>
                /// 判断当前数字是否在给定的两个数字区间范围内
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="max">The value1.</param>
                /// <param name="min">The minimum.</param>
                /// <returns><c>true</c> if the specified value is between; otherwise, <c>false</c>.</returns>
                public static bool IsBetween(this float value, float max, float min = 0f)
                {
                        return min < value && value < max;
                }

                /// <summary>
                /// Determines whether [is half between] [the specified value].
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="max">The maximum.</param>
                /// <returns><c>true</c> if [is half between] [the specified value]; otherwise, <c>false</c>.</returns>
                public static bool IsDoubleDirectionBetween(this float value, float max)
                {
                        max = Math.Abs(max);
                        return IsBetween(value, max, (max * -1));
                }
        }
}