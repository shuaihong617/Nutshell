using System;
using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Communication;
using Nutshell.Communication.Models;
using Nutshell.Components;
using Nutshell.Messaging.Models;
using Nutshell.RabbitMQ.Models;
using Nutshell.Serializing;
using Nutshell.Serializing.Xml;
using Nutshell.Storaging;
using RabbitMQ.Client;

namespace Nutshell.RabbitMQ
{
	public abstract class RabbitMQActor<T> : Worker,IStorable<RabbitMQActorModel>, IActor<T> where T : MessageModel
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

		[MustNotEqualNull]
		protected RabbitMQExchange Exchange { get; private set; }

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

		public void Load([MustNotEqualNull]RabbitMQActorModel model)
		{
			base.Load(model);
		}

		public void Save([MustNotEqualNull]RabbitMQActorModel model)
		{
			base.Save(model);
		}

		protected override bool StartCore()
		{
			Channel = _connection.CreateModel();

			//设置消息持久化
			var properties = Channel.CreateBasicProperties();
			properties.DeliveryMode = 2;

			Channel.ExchangeDeclare(Exchange.Name, Exchange.ExchangeType.ToString().ToLower(), Exchange.IsDurable, Exchange.IsAutoDelete);

			return true;
		}

		protected override bool StopCore()
		{
			Channel.Close();
			Channel.Dispose();
			Channel = null;

			return true;
		}

		public IActor<T> BindToBus([MustNotEqualNull]Bus bus)
		{
			Trace.Assert(_connection == null);

		        var rabbitBus = bus as RabbitMQBus;
		        Trace.Assert(rabbitBus != null);
		        Trace.Assert(rabbitBus.Connection != null);

			_connection = rabbitBus.Connection;
			Exchange = rabbitBus.Exchange;
			return this;
		}
	}
}
