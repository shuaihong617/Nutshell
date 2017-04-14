using Nutshell.Communication;
using Nutshell.Messaging;
using Nutshell.Messaging.Models;

namespace Nutshell.MessageQueue
{
        public interface IMessageQueueSender<T> : ISender<T> where T : IMessageModel
	{
                
        }
}
