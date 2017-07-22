// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-12-17
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-12-23
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Communication;
using Nutshell.Data.Models;
using Nutshell.Extensions;
using Nutshell.Messaging.Models;
using Nutshell.RabbitMQ.Messaging;
using Nutshell.RabbitMQ.Messaging.Models;
using Nutshell.RabbitMQ.Models;
using Nutshell.Serializing.Xml;
using Nutshell.Storaging;
using Nutshell.Storaging.Xml;
using RabbitMQ.Client;

namespace Nutshell.RabbitMQ
{
	/// <summary>
	///         RabbitMQ发送者
	/// </summary>
	public class RabbitMQSender<T> : RabbitMQActor<T>, ISender<T> where T : RabbitMQMessage
        {
		/// <summary>
		///         初始化<see cref="RabbitMQSender{T}" />的新实例.
		/// </summary>
		/// <param name="id">The identifier.</param>
		public RabbitMQSender(string id = "")
			: base(id)
		{
		        _exchange.Parent = this;
		}

                private readonly RabbitMQExchange _exchange = new RabbitMQExchange();

	        public override void Load(IIdentityModel model)
	        {
	                base.Load(model);

	                var subModel = model as RabbitMQSenderModel;
                        Trace.Assert(subModel != null);

                        _exchange.Load(subModel.RabbitMQExchangeModel);
	        }


	        protected override bool StartCore()
	        {
	                base.StartCore();

                        Channel.ExchangeDeclare(_exchange.Name, _exchange.ExchangeType.ToString().ToLower(), _exchange.IsDurable, _exchange.IsAutoDelete);

	                return true;
	        }

	        /// <summary>
                ///         发送字节数组数据
                /// </summary>
                /// <param name="message">待发送消息数据</param>
                public void Send(T message)
		{
			var data = Serializer.Serialize(message);

                        this.Info("发送:" + message);

			Channel.BasicPublish(_exchange.Name,
				message.RoutingKey,
				false,
				null,
				data);

                        OnSendSuccessed(new ValueEventArgs<T>(message));
		}

		/// <summary>
		///         Occurs when [send successed].
		/// </summary>
		public event EventHandler<ValueEventArgs<T>> SendSuccessed;

                /// <summary>
                ///         引发启动事件。
                /// </summary>
                /// <param name="e">包含事件数据的实例<see cref="EventArgs" /></param>
                protected virtual void OnSendSuccessed(ValueEventArgs<T> e) => e.Raise(this, ref SendSuccessed);
        }
}
