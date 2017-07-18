using System;
using System.Diagnostics;
using Nutshell.Communication;
using Nutshell.Data.Models;
using Nutshell.RabbitMQ.Messaging;
using Nutshell.RabbitMQ.Models;
using RabbitMQ.Client;

namespace Nutshell.RabbitMQ
{
        public class RabbitMQBus : Bus
        {
                #region 字段

                /// <summary>
                ///         连接工厂
                /// </summary>
                private ConnectionFactory _factory;

                #endregion

                #region 属性

                public RabbitMQAuthorization Authorization { get; } = new RabbitMQAuthorization();

                /// <summary>
                ///         获取连接
                /// </summary>
                /// <value>连接</value>
                /// <remarks>
                ///         1 连接可以Dispose，所以必须可为null。
                ///         2 连接比较消耗资源，所以多个发送和接收单元尽量共享连接。（官方文档上说的）
                /// </remarks>
                public IConnection Connection { get; private set; }

                #endregion

                /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">读取数据的源数据模型，该数据模型不能为空引用</param>
                public override void Load(IIdentityModel model)
                {
                        base.Load(model);

                        var subModel = model as RabbitMQBusModel;
                        Trace.Assert(subModel != null);

                        Authorization.Load(subModel.RabbitMQAuthorizationModel);
                }


                protected override bool StartCore()
                {
                        if (!base.StartCore())
                        {
                                return false;
                        }

                        _factory = new ConnectionFactory
                        {
                                HostName = Authorization.HostName,
                                Port = Authorization.PortNumber,
                                UserName = Authorization.UserName,
                                Password = Authorization.Password
                        };

                        Connection = _factory.CreateConnection();

                        return true;
                }

                /// <summary>
                ///         执行退出过程的具体步骤.
                /// </summary>
                /// <returns>成功返回True, 否则返回False.</returns>
                /// <remarks>
                ///         若退出过程有多个步骤,执行尽可能多的步骤, 以保证尽量清理现场.
                /// </remarks>
                protected override bool StopCore()
                {
                        base.StopCore();

                        Connection.Close();
                        Connection.Dispose();
                        Connection = null;

                        _factory = null;

                        return true;
                }

                public virtual RabbitMQBus RegisterSender<T>(RabbitMQSender<T> sender) where T : RabbitMQMessage
                {
                        base.RegisterSender(sender);
                        sender.BindToBus(this);
                        return this;
                }

                public virtual RabbitMQBus RegisterReceiver<T>(RabbitMQReceiver<T> receiver) where T : RabbitMQMessage
                {
                        base.RegisterReceiver(receiver);
                        receiver.BindToBus(this);
                        return this;
                }
        }
}
