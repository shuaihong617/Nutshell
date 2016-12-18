using System;
using RabbitMQ.Client;

namespace Nutshell.MessageQueue.RabbitMQ
{
        public class RabbitSender:RabbitTransferor,IMessageQueueSender
        {
                public RabbitSender(IdentityObject parent, string id = null) 
                        : base(parent, id)
                {
                }

                protected override bool StartCore()
                {
                        throw new System.NotImplementedException();
                }

                protected override bool StopCore()
                {
                        throw new System.NotImplementedException();
                }

                

                public void Send(byte[] data)
                {
                        //Channel.BasicPublish();
                }

	        public event EventHandler<EventArgs> SendSuccessed;

	        public event EventHandler<EventArgs> SendFailed;
        }
}
