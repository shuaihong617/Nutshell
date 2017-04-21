using System;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Communication;
using Nutshell.RabbitMQ.Models.Xml;
using Nutshell.Serializing.Xml;
using Nutshell.Storaging;
using Nutshell.Storaging.Xml;
using RabbitMQ.Client;

namespace Nutshell.RabbitMQ
{
        public class RabbitMQBus : Bus, IStorable<XmlRabbitMQBusModel>
        {
		/// <summary>
		/// 连接工厂
		/// </summary>
		private ConnectionFactory _factory;

                #region 属性

                public RabbitMQAuthorization Authorization { get; } = new RabbitMQAuthorization();

		/// <summary>
		/// 获取连接
		/// </summary>
		/// <value>连接</value>
		/// <remarks>
		/// 1 连接可以Dispose，所以必须可为null。
		/// 2 连接比较消耗资源，所以多个发送和接收单元尽量共享通道。（官方文档上说的）
		/// </remarks>
                public IConnection Connection { get; private set; }

		public RabbitMQExchange Exchange { get; } = new RabbitMQExchange();

		#endregion

		public static RabbitMQBus Load([MustNotEqualNullOrEmpty]string fileName)
                {
                        var bytes = XmlStorager.Instance.Load(fileName);
                        var model = XmlSerializer<XmlRabbitMQBusModel>.Instance.Deserialize(bytes);

                        var bus = new RabbitMQBus();
                        bus.Load(model);
                        return bus;
                }

                /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">读取数据的源数据模型，该数据模型不能为空引用</param>
                public void Load(XmlRabbitMQBusModel model)
                {
                        base.Load(model);

                        Authorization.Load(model.XmlRabbitMQAuthorizationModel);
			Exchange.Load(model.XmlRabbitMQExchangeModel);
                }


                /// <summary>
                ///         保存数据到数据模型
                /// </summary>
                /// <param name="model">写入数据的目的数据模型，该数据模型不能为空引用</param>
                public void Save(XmlRabbitMQBusModel model)
                {
                        throw new NotImplementedException();
                }

                protected override Result StartCore()
                {
                        var baseResult = base.StartCore();
                        if (!baseResult.IsSuccessed)
                        {
                                return baseResult;
                        }

                        _factory = new ConnectionFactory
                        {
                                HostName = Authorization.HostName,
                                Port = Authorization.PortNumber,
                                UserName = Authorization.UserName,
                                Password = Authorization.Password
                        };

                        Connection = _factory.CreateConnection();

                        return Result.Successed;
                }

                /// <summary>
                ///         执行退出过程的具体步骤.
                /// </summary>
                /// <returns>成功返回True, 否则返回False.</returns>
                /// <remarks>
                ///         若退出过程有多个步骤,执行尽可能多的步骤, 以保证尽量清理现场.
                /// </remarks>
                protected override Result StopCore()
                {
                        base.StopCore();

                        Connection.Close();
                        Connection.Dispose();
                        Connection = null;

                        _factory = null;

                        return Result.Successed;
                }
        }
}
