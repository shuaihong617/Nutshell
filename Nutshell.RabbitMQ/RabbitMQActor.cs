using System;
using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Communication;
using Nutshell.Communication.Models;
using Nutshell.Components;
using Nutshell.Messaging;
using Nutshell.Messaging.Models;
using Nutshell.RabbitMQ.Messaging;
using Nutshell.RabbitMQ.Models;
using Nutshell.Serializing;
using Nutshell.Serializing.Xml;
using Nutshell.Storaging;
using RabbitMQ.Client;

namespace Nutshell.RabbitMQ
{
	public abstract class RabbitMQActor<T> : Worker, IActor<T> where T : RabbitMQMessage
	{
		protected RabbitMQActor(string id = "")
			: base(id)
		{
		}

		#region 字段

		[MustNotEqualNull] private IConnection _connection;

		#endregion


		#region 属性

		public ISerializer<T> Serializer { get; } = XmlSerializer<T>.Instance;

		/// <summary>
		/// 获取通道
		/// </summary>
		/// <value>通道</value>
		/// <remarks>
		/// 1 通道可以Dispose，所以必须可为null。
		/// 2 多个发送和接收单元尽量不要共享通道。
		/// </remarks>
		protected IModel Channel { get; private set; }

		#endregion

		

		protected override bool StartCore()
		{
			Channel = _connection.CreateModel();

			//设置消息持久化
			var properties = Channel.CreateBasicProperties();
			properties.DeliveryMode = 2;

			return true;
		}

		protected override bool StopCore()
		{
			Channel.Close();
			Channel.Dispose();
			Channel = null;

			return true;
		}

                public virtual IActor<T> BindToBus([MustNotEqualNull]IBus bus)
                {
			Trace.Assert(_connection == null);
			

                        var rabbitBus = bus as RabbitMQBus;
                        Trace.Assert(rabbitBus!= null);
                        Trace.Assert(rabbitBus.Connection != null);

                        _connection = rabbitBus.Connection;
                        return this;
                }
	}
}
