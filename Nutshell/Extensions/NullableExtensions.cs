// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-01-18
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-01-18
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

namespace Nutshell.Extensions
{
        /// <summary>
        ///         可空短整形扩展方法
        /// </summary>
        public static class NullableShortExtensions
        {
                /// <summary>
                ///         Determines whether the specified value is between.
                /// </summary>
                /// <param name="s">The s.</param>
                /// <param name="max">The maximum.</param>
                /// <param name="min">The minimum.</param>
                /// <param name="name">The name.</param>
                /// <returns><c>true</c> if the specified value is between; otherwise, <c>false</c>.</returns>
                public static bool IsBetween(this short? s, int max, int min = 0, string name = "")
                {
                        if (!s.HasValue)
                        {
                                //GlobalLoger.Debug(name + "当前值不存在, 不合格");
                                return false;
                        }

                        max.MustGreaterThanOrEqual(min);

                        bool result;

                        if (max > s.Value && s.Value > min)
                        {
                                result = true;
                        }
                        else
                        {
                                result = false;
                        }

                        //GlobalLoger.Debug(name + "当前值" + s + " 合格区间 (" + min + ", " + max + ") " + (result ? "合格" : "不合格"));

                        return result;
                }

                /// <summary>
                ///         Determines whether [is half between] [the specified value].
                /// </summary>
                /// <param name="s">The s.</param>
                /// <param name="max">The maximum.</param>
                /// <param name="name">The name.</param>
                /// <returns><c>true</c> if [is half between] [the specified value]; otherwise, <c>false</c>.</returns>
                public static bool IsDoubleDirectionBetween(this short? s, int max, string name = "")
                {
                        max.MustGreaterThanOrEqual(0);

                        if (!s.HasValue)
                        {
                                //GlobalLoger.Debug(name + "当前值不存在, 不合格");
                                return false;
                        }

                        return IsBetween(s, max, (short)(max * -1), name);
                }
        }
}