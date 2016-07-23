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

namespace Nutshell
{
        /// <summary>
        ///         标识对象接口
        /// </summary>
        public interface IIdentityObject
        {
                /// <summary>
                ///         标识
                /// </summary>
                String Id { get; }

                /// <summary>
                ///         全局标识
                /// </summary>
                String GlobalId { get;}
        }
}