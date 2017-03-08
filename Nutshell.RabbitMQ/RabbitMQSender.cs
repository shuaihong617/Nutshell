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
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.MessageQueue;
using RabbitMQ.Client;

namespace Nutshell.RabbitMQ
{
	/// <summary>
	/// RabbitMQ发送者
	/// </summary>
	public class RabbitMQSender : RabbitMQActor, IMessageQueueSender
	{
		/// <summary>
		/// 初始化<see cref="RabbitMQSender"/>的新实例.
		/// </summary>
		/// <param name="parent">The parent.</param>
		/// <param name="id">The identifier.</param>
		public RabbitMQSender(string id = "")
			: base( id)
		{
		}

		/// <summary>
		/// Starts the core.
		/// </summary>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		//protected override bool Start()
		//{
		//	base.Start();

		//	Channel.ExchangeDeclare("ExchangeName",
		//		"Topic",
		//		true,
		//		false);

		//	return true;
		//}




		/// <summary>
		/// Sends the specified data.
		/// </summary>
		/// <param name="data">The data.</param>
		public void Send([MustNotEqualNull] byte[] data)
		{
			Channel.BasicPublish("ExchangName",
				"key",
				false,
				null,
				data);
		}

		/// <summary>
		/// Occurs when [send successed].
		/// </summary>
		public event EventHandler<ValueEventArgs<Exception>> SendSuccessed;

		/// <summary>
		/// Occurs when [send failed].
		/// </summary>
		public event EventHandler<ValueEventArgs<Exception>> SendFailed;
	}
}
