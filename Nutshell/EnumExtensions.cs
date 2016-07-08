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
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Nutshell
{
        /// <summary>
        ///         枚举扩展方法
        /// </summary>
        public static class EnumExtensions
        {
                /// <summary>
                ///         将该枚举所有成员转换为列表
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <returns>List&lt;T&gt;.</returns>
                public static List<T> CreateList<T>() where T : struct
                {
                        Type t = typeof (T);
                        List<string> names = Enum.GetNames(t).ToList();
                        var result = new List<T>();

                        names.ForEach(i => result.Add((T) Enum.Parse(t, i)));

                        return result;
                }

                public static string GetDescription(this Enum value)
                {
                        string output = null;
                        Type type = value.GetType();

                        FieldInfo fi = type.GetField(value.ToString());
                        var attars = fi.GetCustomAttributes(typeof (DescriptionAttribute),
                                false) as DescriptionAttribute[];
                        if (attars != null && attars.Length > 0)
                        {
                                output = attars[0].Description;
                        }

                        return output;
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