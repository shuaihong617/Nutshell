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

namespace Nutshell.Extensions
{
        /// <summary>
        ///         类型扩展方法
        /// </summary>
        public static class TypeExtensions
        {
                /// <summary>
                /// 判断当前类型是否为简单类型（值类型或字符串）
                /// </summary>
                /// <param name="t">类型.</param>
                /// <returns>值类型或字符串类型返回True, 否则返回False</returns>
                /// <exception cref="NotImplementedException"></exception>
                public static bool IsSimpleType(this Type t)
                {
                        //if (t.IsValueType)
                        //{
                        //        return true;
                        //}

                        //if (t == typeof (string))
                        //{
                        //        return true;
                        //}

                        //return false;

                        throw new NotImplementedException();
                }
        }
}