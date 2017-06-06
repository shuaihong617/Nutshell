// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-10-16
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-10-17
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;
using Nutshell.Storaging.Models;

namespace Nutshell.Messaging.Models
{
        /// <summary>
        ///         消息
        /// </summary>
        [XmlType]
        public class MessageModel : DataModel
        {
                public MessageModel()
                {
                        Id = Guid.NewGuid().ToString();
                }
        }
}