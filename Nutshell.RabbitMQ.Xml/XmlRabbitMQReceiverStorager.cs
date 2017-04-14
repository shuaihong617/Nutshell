using Nutshell.Aspects.Locations.Contracts;
using Nutshell.IO.Aspects.Locations.Contracts;
using Nutshell.Messaging.Models;
using Nutshell.RabbitMQ.Xml.Models;
using Nutshell.Serializing.Xml;
using Nutshell.Storaging.Xml;

namespace Nutshell.RabbitMQ.Xml
{
	public class XmlRabbitMQReceiverStorager<T> where T : IMessageModel
	{
		protected XmlRabbitMQReceiverStorager()
		{
		}

		#region 单例

		/// <summary>
		///         单例
		/// </summary>
		public static readonly XmlRabbitMQReceiverStorager<T> Instance = new XmlRabbitMQReceiverStorager<T>();

		#endregion 单例

		public void Load([MustNotEqualNull] RabbitMQReceiver<T> receiver,
			[MustFileExist] string fileName)
		{
			var bytes = XmlStorager.Instance.Load(fileName);
			var model = XmlSerializer<XmlRabbitMQReceiverModel>.Instance.Deserialize(bytes);

			receiver.Load(model);

			var exchange = new RabbitMQExchange();
			exchange.Load(model.XmlRabbitMQExchangeModel);
			receiver.SetExchange(exchange);

			var queue = new RabbitMQQueue();
			queue.Load(model.XmlRabbitMQQueueModel);
			receiver.Attach(queue);
		}

		public void Save([MustNotEqualNull] RabbitMQReceiver<T> receiver, string fileName)
		{
		}
	}
}