﻿// ***********************************************************************
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
using System.Xml.Serialization;

namespace Nutshell.RabbitMQ.Messaging.Models
{
        /// <summary>
        ///         自动装包开始消息数据模型
        /// </summary>
        
        public class RabbitMQStringKeyValueMessage : RabbitMQMessage
        {
                public RabbitMQStringKeyValueMessage()
                {
                        Id = Guid.NewGuid().ToString();
                }

                public RabbitMQStringKeyValueMessage(string routingKey)
                {
                        RoutingKey = routingKey;
                }

		
		public string Key { get; set; }

		
		public string Value { get; set; }
	}
}