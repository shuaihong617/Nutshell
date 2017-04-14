using Nutshell.Aspects.Locations.Contracts;
using Nutshell.IO.Aspects.Locations.Contracts;
using Nutshell.Messaging.Models;
using Nutshell.RabbitMQ.Xml.Models;
using Nutshell.Serializing.Xml;
using Nutshell.Storaging.Xml;

namespace Nutshell.RabbitMQ.Xml
{
	public class XmlRabbitMQSenderStorager<T> where T : IMessageModel
	{
		protected XmlRabbitMQSenderStorager()
		{
		}

		#region 单例

		/// <summary>
		///         单例
		/// </summary>
		public static readonly XmlRabbitMQSenderStorager<T> Instance = new XmlRabbitMQSenderStorager<T>();

		#endregion 单例

		public void Load([MustNotEqualNull] RabbitMQSender<T> rabbitMQSender,
			[MustFileExist] string fileName)
		{
			var bytes = XmlStorager.Instance.Load(fileName);
			var model = XmlSerializer<XmlRabbitMQSenderModel>.Instance.Deserialize(bytes);

			rabbitMQSender.Load(model);

			var exchange = new RabbitMQExchange();
			exchange.Load(model.XmlRabbitMQExchangeModel);

			rabbitMQSender.SetExchange(exchange);
		}

		public void Save([MustNotEqualNull] RabbitMQSender<T> rabbitMQSender, string fileName)
		{
		}
	}
}