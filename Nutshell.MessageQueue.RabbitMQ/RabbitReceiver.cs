using Nutshell.Communication;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Nutshell.MessageQueue.RabbitMQ
{
        public class RabbitReceiver:RabbitTransferor,IMessageQueueReceiver
        {
                

                

                public RabbitReceiver(IdentityObject parent, string id = null) 
			: base(parent, id)
                {
                }


	        private EventingBasicConsumer _consumer;

                protected override bool StartCore()
                {
                        _consumer = new EventingBasicConsumer(Channel);
	                //Channel.BasicConsume("queueName", false, _consumer);

	                return true;
                }

                protected override bool StopCore()
                {
                        throw new System.NotImplementedException();
                }

                public byte[] Receive()
                {
                        throw new System.NotImplementedException();
                }
        }
}
