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
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Extensions;
using Nutshell.Messaging;

namespace Nutshell.RabbitMQ.Messaging
{
	/// <summary>
	///         消息
	/// </summary>
	
	public class RabbitMQMessage : Message
	{
	        public RabbitMQMessage()
	        {
	        }

	        public RabbitMQMessage(string routingKey)
	        {
	                RoutingKey = routingKey;
	        }

                /// <summary>
                ///         获取或设置路由键
                /// </summary>
                /// <value>路由键</value>
                [MustNotEqualNull]

                public string RoutingKey { get; set; }

                public override string ToString()
                {
                        return $"{base.ToString()}  {RoutingKey}";
                }
        }
}