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

namespace Nutshell.Data
{
        /// <summary>
        ///         主键接口
        /// </summary>
        public interface IIdentityObject
        {
                /// <summary>
                ///         标识
                /// </summary>
                /// <value>The key.</value>
                String Id { get; }

                String GlobalId { get;}
        }
}