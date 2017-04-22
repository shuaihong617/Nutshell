﻿// ***********************************************************************
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
using Nutshell.Extensions;
using Nutshell.Messaging;
using Nutshell.Messaging.Models;
using Nutshell.RabbitMQ.Models;
using Nutshell.Serializing.Xml;
using Nutshell.Storaging;
using Nutshell.Storaging.Xml;
using RabbitMQ.Client;

namespace Nutshell.RabbitMQ
{
	/// <summary>
	/// RabbitMQ发送者
	/// </summary>
	public class RabbitMQSender<T> : RabbitMQActor<T>, IStorable<RabbitMQSenderModel>, ISender<T> where T : MessageModel
	{
		/// <summary>
		/// 初始化<see cref="RabbitMQSender{T}"/>的新实例.
		/// </summary>
		/// <param name="id">The identifier.</param>
		public RabbitMQSender(string id = "")
			: base( id)
		{
		}

                public static RabbitMQSender<T> Load([MustNotEqualNullOrEmpty]string fileName)
                {
                        var bytes = XmlStorager.Instance.Load(fileName);
                        var model = XmlSerializer<RabbitMQSenderModel>.Instance.Deserialize(bytes);

                        var sender = new RabbitMQSender<T>();
                        sender.Load(model);

                        return sender;
                }

                public void Load(RabbitMQSenderModel model)
                {
                        base.Load(model);
                }

                public void Save(RabbitMQSenderModel model)
                {
                        base.Save(model);
                }

                /// <summary>
                ///         发送字节数组数据
                /// </summary>
                /// <param name="messageModel">待发送消息数据</param>
                public void Send(T messageModel)
		{
			var data = Serializer.Serialize(messageModel);

			Trace.WriteLine(DateTime.Now.ToChineseLongMillisecondString() + messageModel.Id);

			Channel.BasicPublish(Exchange.Name,
				messageModel.Category,
				false,
				null,
				data);
		}

		/// <summary>
		/// Occurs when [send successed].
		/// </summary>
		public event EventHandler<ValueEventArgs<T>> SendSuccessed;

		/// <summary>
		/// Occurs when [send failed].
		/// </summary>
		public event EventHandler<ValueEventArgs<Exception>> SendFailed;

	        
	}
}
