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

namespace Nutshell.Messaging.XMLMessages
{
        /// <summary>
        ///         消息
        /// </summary>
        [XmlType]
        public class Message : IMessage
        {
                /// <summary>
                ///         Initializes a new Itance of the <see cref="Message" /> class.
                /// </summary>
                public Message()
                {
                        Time = DateTime.Now;
                }

                [XmlAttribute]
                public DateTime Time { get; set; }
        }
}