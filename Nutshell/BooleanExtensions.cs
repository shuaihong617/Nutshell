// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-12-15
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-12-12
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
        ///         布尔类型扩展方法
        /// </summary>
        public static class BooleanExtensions
        {
                /// <summary>
                ///         值必须为真
                /// </summary>
                /// <param name="value">待判定的值</param>
                public static void MustTrue(this bool value)
                {
                        if (!value)
                        {
                                throw new ArgumentException("值必须为真");
                        }
                }


                /// <summary>
                ///         值必须为假
                /// </summary>
                /// <param name="value">待判定的值</param>
                public static void MustFalse(this bool value)
                {
                        if (value)
                        {
                                throw new ArgumentException("值必须为假");
                        }
                }

                /// <summary>
                ///         返回当前变量与条件变量与运算的结果
                /// </summary>
                /// <param name="value">当前变量</param>
                /// <param name="condition">进行与运算的条件变量</param>
                /// <returns>与运算的结果</returns>
                public static bool And(this bool value, bool condition)
                {
                        return value && condition;
                }

                /// <summary>
                ///         返回当前变量与条件变量或运算的结果
                /// </summary>
                /// <param name="value">当前变量</param>
                /// <param name="condition">进行或运算的条件变量</param>
                /// <returns>或运算的结果</returns>
                public static bool Or(this bool value, bool condition)
                {
                        return value || condition;
                }

                /// <summary>
                ///         返回变量的中文形式字符串
                /// </summary>
                /// <param name="value">if set to <c>true</c> [b].</param>
                /// <returns>中文形式字符串</returns>
                public static String ToChineseString(this bool value)
                {
                        return value ? "是" : "否";
                }
        }
}