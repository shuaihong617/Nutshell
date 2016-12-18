using System.Runtime.Remoting.Channels;
using Nutshell.Communication;
using Nutshell.Components;
using Nutshell.Serializing;
using RabbitMQ.Client;
using RabbitMQ.Client.Framing;

namespace Nutshell.MessageQueue.RabbitMQ
{
        public abstract class RabbitTransferor: Transferor,IMessageQueueTransferor
        {
                protected RabbitTransferor(IdentityObject parent, string id = null) 
                        : base(parent, id)
                {
                }

	        private ConnectionFactory _factory;

	        private IConnection _connection;

                protected IModel Channel { get; private set; }

	        protected override bool StartCore()
	        {
		        _factory = new ConnectionFactory()
		        {
			        HostName = "localhost",
			        Port = 15536,
			        UserName = "guest",
			        Password = "guest"
		        };

		        _connection = _factory.CreateConnection();

		        Channel = _connection.CreateModel();

		        return true;
	        }

	        protected override bool StopCore()
                {
			Channel.Close();
			Channel.Dispose();
		        Channel = null;

			_connection.Close();
			_connection.Dispose();
		        _connection = null;

		        _factory = null;

                        throw new System.NotImplementedException();
                }
        }
}
