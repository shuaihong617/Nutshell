// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-09-05
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-09-05
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Data;

namespace Nutshell.Components
{
        /// <summary>
        ///         消费者接口
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public interface IConsumer<in T>
        {
                /// <summary>
                ///         获得
                /// </summary>
                /// <param name="t">生产结果</param>
                void Acquire(T t);
        }
}