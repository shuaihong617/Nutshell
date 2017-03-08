using System;
using Nutshell.Communication;
using Nutshell.Communication.Models;
using Nutshell.Components;
using RabbitMQ.Client;

namespace Nutshell.RabbitMQ
{
	public abstract class RabbitMQActor : Worker, IActor
	{
		protected RabbitMQActor(string id = "")
			: base( id)
		{
		}

		private ConnectionFactory _factory;

		private IConnection _connection;

		protected IModel Channel { get; private set; }

		public void Load(IActorModel model)
		{
			throw new System.NotImplementedException();
		}

		public void Save(IActorModel model)
		{
			throw new System.NotImplementedException();
		}

		protected override Result StartCore(ContextBase contextBase)
		{
			//_factory = new ConnectionFactory
			//{
			//	HostName = "127.0.0.1",
			//	Port = 15536,
			//	UserName = "guest",
			//	Password = "guest"
			//};

			//_connection = _factory.CreateConnection();

			//Channel = _connection.CreateModel();

			////设置消息持久化
			//IBasicProperties properties = Channel.CreateBasicProperties();
			//properties.DeliveryMode = 2;

			//Channel.ExchangeDeclare(exchange: "ExchangeName",
			//			type: "Topic",
			//			durable: true,
			//			autoDelete: false);

			//return true;

                        throw new NotImplementedException();
		}

		protected override Result StopCore(ContextBase contextBase)
		{
			//Channel.Close();
			//Channel.Dispose();
			//Channel = null;

			//_connection.Close();
			//_connection.Dispose();
			//_connection = null;

			//_factory = null;

			//return true;

                        throw new NotImplementedException();
                }

		
	}
}
