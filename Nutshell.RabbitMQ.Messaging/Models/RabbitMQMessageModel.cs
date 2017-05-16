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
using Nutshell.Messaging.Models;

namespace Nutshell.RabbitMQ.Messaging.Models
{
	/// <summary>
	///         消息
	/// </summary>
	[XmlType]
	public class RabbitMQMessageModel : MessageModel
	{
	        public RabbitMQMessageModel()
	        {
	                Id = Guid.NewGuid().ToString();
	        }

	        public RabbitMQMessageModel(string routingKey)
	        {
	                RoutingKey = routingKey;
	        }

                /// <summary>
                ///         获取路由键
                /// </summary>
                /// <value>路由键</value>
                [XmlAttribute]
		[MustNotEqualNull]
		public string RoutingKey { get; set; }
	}
}