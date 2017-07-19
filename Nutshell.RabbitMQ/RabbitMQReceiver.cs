using System;
using System.Diagnostics;
using Nutshell.Communication;
using Nutshell.Data.Models;
using Nutshell.Extensions;
using Nutshell.RabbitMQ.Messaging;
using Nutshell.RabbitMQ.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Nutshell.RabbitMQ
{
        public class RabbitMQReceiver<T> : RabbitMQActor<T>, IReceiver<T>
                where T : RabbitMQMessage
        {
                public RabbitMQReceiver(string id = "")
                        : base(id)
                {
                }

                private EventingBasicConsumer _consumer;

                private readonly RabbitMQQueue _queue = new RabbitMQQueue();

                /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">读取数据的源数据模型，该数据模型不能为空引用</param>
                public override void Load(IIdentityModel model)
                {
                        base.Load(model);

                        var subModel = model as RabbitMQReceiverModel;
                        Trace.Assert(subModel != null);

                        _queue.Load(subModel.RabbitMQQueueModel);
                }


                public void Save(RabbitMQReceiverModel model)
                {
                        _queue.Save(model.RabbitMQQueueModel);
                        base.Save(model);
                }

                protected override bool StartCore()
                {
                        base.StartCore();

                        Channel.QueueDeclare(_queue.Name, _queue.IsDurable, _queue.IsExclusive, _queue.IsAutoDelete,
                                null);

                        _consumer = new EventingBasicConsumer(Channel);
                        _consumer.Received += (model, ea) =>
                        {
                                var body = ea.Body;
                                var message = Serializer.Deserialize(body);

                                Trace.WriteLine(DateTime.Now.ToChineseLongMillisecondString() + message.Id);

                                OnReceiveSuccessed(new ValueEventArgs<T>(message));
                        };
                        Channel.BasicConsume(_queue.Name, true, _consumer);

                        return true;
                }

                #region 事件

                public event EventHandler<ValueEventArgs<T>> ReceiveSuccessed;

                /// <summary>
                ///         引发启动事件。
                /// </summary>
                /// <param name="e">包含事件数据的实例<see cref="EventArgs" /></param>
                protected virtual void OnReceiveSuccessed(ValueEventArgs<T> e) => e.Raise(this, ref ReceiveSuccessed);

                #endregion
        }
}
