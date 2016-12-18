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

using System;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data.Models;

namespace Nutshell.Messaging
{
        /// <summary>
        ///         消息接口
        /// </summary>
        public interface IMessage:IDataModel
        {                
                /// <summary>
                /// 获取消息的类型
                /// </summary>
                /// <value>消息类型</value>
                [MustNotEqualNullOrEmpty]
                string Category { get; }

                /// <summary>
                ///         获取消息的创建时间戳
                /// </summary>
                /// <value>创建时间戳</value>
                [MustNotEqualNull]
                DateTime CreateTimeStamp { get; }
        }
}