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

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nutshell
{
        /// <summary>
        ///         枚举扩展方法
        /// </summary>
        public static class EnumExtensions
        {
                /// <summary>
                ///         为该枚举所有成员创建一个列表
                /// </summary>
                /// <typeparam name="T">枚举类型</typeparam>
                /// <returns>包含该枚举类型所有成员的列表</returns>
                public static List<T> CreateList<T>() where T : struct
                {
                        Type t = typeof (T);
                        List<string> names = Enum.GetNames(t).ToList();

                        return names.Select(name => (T) Enum.Parse(t, name)).ToList();
                }

                /// <summary>
                ///         将枚举值转换为对应的Int32值
                /// </summary>
                /// <param name="value">枚举值</param>
                /// <returns>枚举值对应的Int32值</returns>
                public static int ToInt32(this Enum value)
                {
                        return Convert.ToInt32(value);
                }
        }
}