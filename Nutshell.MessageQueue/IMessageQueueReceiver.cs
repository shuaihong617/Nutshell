using Nutshell.Communication;
using Nutshell.Messaging;
using Nutshell.Messaging.Models;

namespace Nutshell.MessageQueue
{
        public interface IMessageQueueReceiver<T> : IReceiver<T> where T : IMessageModel
	{
                
        }
}
