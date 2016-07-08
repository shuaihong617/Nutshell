// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-12-10
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-12-10
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

namespace Nutshell.Data.Converting
{
        /// <summary>
        /// 值转换接口
        /// </summary>
        /// <typeparam name="TSource">输入数据类型</typeparam>
        /// <typeparam name="TTarget">输出数据类型</typeparam>
        public interface IConverter<in TSource, out TTarget>
        {
                TTarget Convert(TSource tSource);
        }
}
