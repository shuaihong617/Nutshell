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
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data.Xml.Models;

namespace Nutshell.Messaging.Xml
{
        /// <summary>
        /// Xml格式的消息
        /// </summary>
        [XmlType]
        public class XmlMessage : XmlDataModel,IMessage
        {
                /// <summary>
                /// 初始化<see cref="XmlMessage"/>的新实例.
                /// </summary>
                public XmlMessage(string id = "", [MustNotEqualNullOrEmpty]string categroy= "")
                {
                        Id = id.IsNullOrEmpty() ? Guid.NewGuid().ToString() : id;
                        Category = categroy;
                        CreateTimeStamp = DateTime.Now;
                }

                /// <summary>
                /// 获取消息的类型
                /// </summary>
                /// <value>消息类型</value>
                [XmlAttribute]
                public string Category { get; set; }

                /// <summary>
                /// 获取消息的创建时间戳
                /// </summary>
                /// <value>创建时间戳</value>
                [XmlAttribute]
                public DateTime CreateTimeStamp { get; set; }                
        }
}