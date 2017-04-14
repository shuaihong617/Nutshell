using Nutshell.Aspects.Locations.Contracts;
using Nutshell.IO.Aspects.Locations.Contracts;
using Nutshell.Messaging.Models;
using Nutshell.RabbitMQ.Xml.Models;
using Nutshell.Serializing.Xml;
using Nutshell.Storaging.Xml;

namespace Nutshell.RabbitMQ.Xml
{
	public class XmlRabbitMQBusStorager
	{
		protected XmlRabbitMQBusStorager()
		{
		}

		#region 单例

		/// <summary>
		///         单例
		/// </summary>
		public static readonly XmlRabbitMQBusStorager Instance = new XmlRabbitMQBusStorager();

		#endregion 单例

		public void Load([MustNotEqualNull] RabbitMQBus bus,
			[MustFileExist] string fileName)
		{
			var bytes = XmlStorager.Instance.Load(fileName);
			var model = XmlSerializer<XmlRabbitMQBusModel>.Instance.Deserialize(bytes);

			bus.Load(model);

			var authorization = new RabbitMQAuthorization();
			authorization.Load(model.XmlRabbitMQAuthorizationModel);

			bus.Attach(authorization);
		}

		public void Save([MustNotEqualNull] RabbitMQBus bus, string fileName)
		{
		}
	}
}