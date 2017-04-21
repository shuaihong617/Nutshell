// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-11-08
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-11-08
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************


using System;

namespace Nutshell.Messaging.Models
{
        /// <summary>
        ///         键-值对数据模型接口
        /// </summary>
        public interface IKeyValuePairModel<TK, TV>
        {
                TK Key { get; set; }

                TV Value { get; set; }
        }
}