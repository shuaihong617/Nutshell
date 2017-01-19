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
        ///         短整形扩展方法
        /// </summary>
        public static class Int16Extensions
        {
                /// <summary>
                ///         Requires the not null.
                /// </summary>
                /// <param name="value">The value.</param>
                /// <returns>System.Object.</returns>
                /// <exception cref="System.ArgumentException">The value can't be null or empty</exception>
                public static short MustNotNegative(this short value)
                {
                        if (value < 0)
                        {
                                throw new ArgumentException("不能为负数！");
                        }
                        return value;
                }

                /// <summary>
                ///         Requires the not null.
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="minValue">The min value.</param>
                /// <returns>System.Object.</returns>
                public static short MustGreaterThanOrEqual(this short value, short minValue)
                {
                        if (value < minValue)
                        {
                                throw new ArgumentOutOfRangeException("必须大于或等于" + minValue);
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
                public static bool IsBetween(this short value, short max, short min = 0, string name = "")
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

                        //NLogDebuger.Debug(name +"当前值" + value + " 合格区间 (" + min + ", " + max + ") " + (result?"合格":"不合格"));

                        return result;
                }

                /// <summary>
                ///         Determines whether [is half between] [the specified value].
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="max">The maximum.</param>
                /// <param name="name">The name.</param>
                /// <returns><c>true</c> if [is half between] [the specified value]; otherwise, <c>false</c>.</returns>
                public static bool IsDoubleDirectionBetween(this short value, short max, string name = "")
                {
                        max.MustGreaterThanOrEqual(0);
                        return IsBetween(value, max, (short) (max*-1), name);
                }
        }
}