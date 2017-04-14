using System;
using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Communication;
using Nutshell.Communication.Models;
using Nutshell.Components;
using Nutshell.Messaging.Models;
using Nutshell.Serializing;
using Nutshell.Serializing.Xml;
using RabbitMQ.Client;

namespace Nutshell.RabbitMQ
{
	public abstract class RabbitMQActor<T> : Worker, IActor<T> where T : IMessageModel
	{
		protected RabbitMQActor(string id = "")
			: base(id)
		{
			Serializer = XmlSerializer<T>.Instance;
		}

		#region 字段

		[MustNotEqualNull] private IConnection _connection;

		#endregion


		#region 属性

		[MustNotEqualNull]
		protected RabbitMQExchange Exchange { get; private set; }

		[MustNotEqualNull]
		public ISerializer<T> Serializer { get; private set; }

		

		[MustNotEqualNull]
		protected IModel Channel { get; private set; }

		#endregion







		public void Load([MustNotEqualNull]IActorModel model)
		{
			base.Load(model);
		}

		public void Save([MustNotEqualNull]IActorModel model)
		{
			base.Save(model);
		}

		protected override Result StartCore()
		{
			Channel = _connection.CreateModel();

			//设置消息持久化
			var properties = Channel.CreateBasicProperties();
			properties.DeliveryMode = 2;

			Channel.ExchangeDeclare(Exchange.Name, Exchange.ExchangeType.ToString().ToLower(), Exchange.IsDurable, Exchange.IsAutoDelete);

			return Result.Successed;
		}

		protected override Result StopCore()
		{
			Channel.Close();
			Channel.Dispose();
			Channel = null;

			return Result.Successed;
		}

		public IActor<T> SetBus([MustNotEqualNull]Bus bus)
		{
		        var rabbitBus = bus as RabbitMQBus;
		        Trace.Assert(rabbitBus != null);
		        Trace.Assert(rabbitBus.Connection != null);

			_connection = rabbitBus.Connection;
			return this;
		}


		public void SetExchange([MustNotEqualNull]RabbitMQExchange exchange)
		{
			Exchange = exchange;
		}
	}
}
