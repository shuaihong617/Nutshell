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

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Nutshell.Extensions
{
        /// <summary>
        ///         列表扩展方法
        /// </summary>
        public static class ListExtensions
        {
                /// <summary>
                ///         将当前列表转换为只读集合
                /// </summary>
                /// <typeparam name="T">列表数据类型</typeparam>
                /// <param name="list">列表</param>
                /// <returns>转换后的只读集合</returns>
                public static ReadOnlyCollection<T> ToReadOnlyCollection<T>(this List<T> list)
                {
                        return new ReadOnlyCollection<T>(list);
                }
        }
}