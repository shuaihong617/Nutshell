using System;
using Nutshell.Data;
using Nutshell.MessageQueue;
using Nutshell.MessageQueue.RabbitMQ.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Nutshell.RabbitMQ
{
        public class RabbitMQReceiver:RabbitMQActor,IMessageQueueReceiver,IStorable<IRabbitMQReceiverModel>
        {

                public RabbitMQReceiver(IdentityObject parent, string id = null) 
			: base(parent, id)
                {
                }


	        private EventingBasicConsumer _consumer;

		public void Load(IRabbitMQReceiverModel model)
		{
			throw new System.NotImplementedException();
		}

		public void Save(IRabbitMQReceiverModel model)
		{
			throw new System.NotImplementedException();
		}

		//protected override bool Start()
  //              {
  //                      _consumer = new EventingBasicConsumer(Channel);
		//	//Channel.BasicConsume("queueName", false, _consumer);

		//	var consumer = new EventingBasicConsumer(Channel);
		//	consumer.Received += (model, ea) =>
		//	{
		//		//var body = ea.Body;
		//		//var message = Encoding.UTF8.GetString(body);
		//		//Console.WriteLine(" [x] Received {0}", message);
		//	};
		//	Channel.BasicConsume(queue: "hello",
		//			     noAck: true,
		//			     consumer: consumer);

		//	return true;
  //              }

                

                public byte[] Receive()
                {
                        throw new System.NotImplementedException();
                }

	        public event EventHandler<ValueEventArgs<byte[]>> ReceiveSuccessed;
	        public event EventHandler<ValueEventArgs<Exception>> ReceiveFailed;
        }
}
