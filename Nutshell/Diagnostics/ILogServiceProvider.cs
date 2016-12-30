// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-10-15
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-10-15
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using Nutshell.Aspects.Locations.Contracts;

namespace Nutshell.Diagnostics
{
        /// <summary>
        ///         标识对象接口
        /// </summary>
        public interface ILogServiceProvider
        {
                /// <summary>
                ///         标识
                /// </summary>
                [MustNotEqualNullOrEmpty]
                String Id { get; }

                /// <summary>
                ///         全局标识
                /// </summary>
                [MustNotEqualNullOrEmpty]
                String GlobalId { get;}
        }
}