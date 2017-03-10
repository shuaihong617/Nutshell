// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-01-18
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-01-16
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************


using System;

namespace Nutshell.Extensions
{
        /// <summary>
        ///         32位整数扩展方法
        /// </summary>
        public static class Int32Extensions
        {
                /// <summary>
                ///         Convert datetime struct to byte array.
                /// </summary>
                /// <param name="value">The value.</param>
                /// <returns>Int16.</returns>
                public static Byte ToByte(this int value)
                {
                        int t = value%256;
                        if (t < 0)
                        {
                                t += 256;
                        }
                        return Convert.ToByte(t);
                }


                /// <summary>
                ///         Requires the not null.
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="minValue">The min value.</param>
                /// <param name="maxValue">The max value.</param>
                /// <returns>System.Object.</returns>
                /// <exception cref="System.ArgumentException">The value can't be null or empty</exception>
                public static int MustBetween(this int value, int minValue, int maxValue)
                {
                        if (value > maxValue || value < minValue)
                        {
                                throw new ArgumentException("必须大于" + minValue + "并小于" + maxValue);
                        }
                        return value;
                }

                /// <summary>
                ///         Musts the equal.
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="compare">The compare.</param>
                /// <returns>T.</returns>
                /// <exception cref="System.ArgumentException">必须与给定值相等！</exception>
                public static int MustEqual(this int value, int compare)
                {
                        if (value != compare)
                        {
                                throw new ArgumentException("必须与给定值相等！");
                        }
                        return value;
                }

                /// <summary>
                ///         Requires the not null.
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="minValue">The min value.</param>
                /// <returns>System.Object.</returns>
                public static int WillGreaterThanOrEqual(this int value, int minValue)
                {
                        if (value < minValue)
                        {
                                return minValue;
                        }
                        return value;
                }


                /// <summary>
                ///         Requires the not null.
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="maxValue">The min value.</param>
                /// <returns>System.Object.</returns>
                public static int WillLessThanOrEqual(this int value, int maxValue)
                {
                        if (value > maxValue)
                        {
                                return maxValue;
                        }
                        return value;
                }


                /// <summary>
                ///         Requires the not null.
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="minValue">The min value.</param>
                /// <returns>System.Object.</returns>
                public static int MustGreaterThan(this int value, int minValue)
                {
                        if (value > minValue)
                        {
                                return value;
                        }
                        throw new ArgumentOutOfRangeException("必须大于" + minValue);
                }

                /// <summary>
                ///         Requires the not null.
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="minValue">The min value.</param>
                /// <returns>System.Object.</returns>
                public static int MustGreaterThanOrEqual(this int value, int minValue)
                {
                        if (value < minValue)
                        {
                                throw new ArgumentOutOfRangeException("必须大于或等于" + minValue);
                        }
                        return value;
                }

                /// <summary>
                ///         Determines whether [is greater than] [the specified value].
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="min">The minimum.</param>
                /// <param name="name">The name.</param>
                /// <returns><c>true</c> if [is greater than] [the specified value]; otherwise, <c>false</c>.</returns>
                public static bool IsGreaterThan(this int value, int min = 0, string name = "")
                {
                        bool result = value > min;

                        //NLogDebuger.Debug(name + "当前值" + value + " 合格区间 (" + min + ", 正无穷) " + result.ToChineseString());

                        return result;
                }

                /// <summary>
                ///         Wills the between.
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="minValue">The minimum value.</param>
                /// <param name="maxValue">The maximum value.</param>
                /// <returns>System.Int32.</returns>
                public static int WillBetween(this int value, int minValue, int maxValue)
                {
                        if (value > maxValue)
                        {
                                return maxValue;
                        }

                        if (value < minValue)
                        {
                                return minValue;
                        }

                        return value;
                }

                /// <summary>
                ///         Determines whether the specified value is between.
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="max">The maximum.</param>
                /// <param name="min">The minimum.</param>
                /// <param name="name">The name.</param>
                /// <returns><c>true</c> if the specified value is between; otherwise, <c>false</c>.</returns>
                public static bool IsBetween(this int value, int max, int min = 0, string name = "")
                {
                        max.MustGreaterThanOrEqual(min);

                        bool result;

                        if (max > value && value > min)
                        {
                                result = true;
                        }
                        else
                        {
                                result = false;
                        }

                        //NLogDebuger.Debug(name + "当前值" + value + " 合格区间 (" + min + ", " + max + ") " + result.ToChineseString());

                        return result;
                }

                /// <summary>
                ///         Determines whether [is half between] [the specified value].
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="max">The maximum.</param>
                /// <param name="name">The name.</param>
                /// <returns><c>true</c> if [is half between] [the specified value]; otherwise, <c>false</c>.</returns>
                public static bool IsDoubleDirectionBetween(this int value, int max, string name = "")
                {
                        max.MustGreaterThanOrEqual(0);
                        return IsBetween(value, max, max*-1, name);
                }

                /// <summary>
                ///         Wills the increase from seed.
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="seed">The seed.</param>
                /// <param name="maxValue">The maximum value.</param>
                /// <returns>System.Int32.</returns>
                public static int WillIncreaseFromSeed(this int value, int seed, int maxValue)
                {
                        value++;

                        if (value < seed)
                        {
                                return seed;
                        }

                        if (value > maxValue)
                        {
                                return seed;
                        }

                        return value;
                }

                /// <summary>
                ///         限定当前数字必须为偶数
                /// </summary>
                /// <param name="value">The value.</param>
                /// <returns>System.Object.</returns>
                public static int MustEvenNumber(this int value)
                {
                        if (value%2 != 0)
                        {
                                throw new ArgumentOutOfRangeException();
                        }
                        return value;
                }

                /// <summary>
                ///         限定当前数字必须为奇数
                /// </summary>
                /// <param name="value">The value.</param>
                /// <returns>System.Object.</returns>
                public static int MustOddNumber(this int value)
                {
                        if (value%2 == 0)
                        {
                                throw new ArgumentOutOfRangeException();
                        }
                        return value;
                }
        }
}