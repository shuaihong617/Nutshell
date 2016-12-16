using System.Runtime.Remoting.Channels;
using RabbitMQ.Client;

namespace Nutshell.MessageQueue.RabbitMQ
{
        public class Receiver
        {
                public ConnectionFactory ConnectionFactory { get; private set; }

                public IConnection Connection { get; private set; }

                public IChannel Channel { get; private set; }

                public IModel Model { get; private set; }

                public void Send()
                {
                        
                }
        }
}
