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
                ///         Musts the true.
                /// </summary>
                /// <param name="value">if set to <c>true</c> [value].</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                public static void MustTrue(this bool value)
                {
                        if (!value)
                        {
                                throw new ArgumentException("值必须为真");
                        }
                }


                /// <summary>
                ///         Musts the false.
                /// </summary>
                /// <param name="value">if set to <c>true</c> [value].</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                public static void MustFalse(this bool value)
                {
                        if (value)
                        {
                                throw new ArgumentException("值必须为假");
                        }
                }

                /// <summary>
                ///         Musts the false.
                /// </summary>
                /// <param name="value">if set to <c>true</c> [value].</param>
                /// <param name="condition">if set to <c>true</c> [condition].</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                public static bool And(this bool value, bool condition)
                {
                        return value && condition;
                }

                /// <summary>
                ///         Musts the false.
                /// </summary>
                /// <param name="value">if set to <c>true</c> [value].</param>
                /// <param name="condition">if set to <c>true</c> [condition].</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                public static bool Or(this bool value, bool condition)
                {
                        return value || condition;
                }

                /// <summary>
                ///         To the string ex.
                /// </summary>
                /// <param name="value">if set to <c>true</c> [b].</param>
                /// <returns>String.</returns>
                public static String ToChineseString(this bool value)
                {
                        return value ? "是" : "否";
                }
        }
}