using System;
using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Communication;
using Nutshell.Extensions;
using Nutshell.IO.Aspects.Locations.Contracts;
using Nutshell.Messaging.Models;
using Nutshell.RabbitMQ.Models;
using Nutshell.Serializing.Xml;
using Nutshell.Storaging;
using Nutshell.Storaging.Xml;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Nutshell.RabbitMQ
{
        public class RabbitMQReceiver<T> : RabbitMQActor<T>, IReceiver<T>, IStorable<RabbitMQReceiverModel>
                where T : MessageModel
        {
                public RabbitMQReceiver(string id = "")
                        : base(id)
                {
                }


                private EventingBasicConsumer _consumer;

                private readonly RabbitMQQueue _queue = new RabbitMQQueue();

                public static RabbitMQReceiver<T> Load([MustFileExist] string fileName)
                {
                        var bytes = XmlStorager.Instance.Load(fileName);
                        var model = XmlSerializer<RabbitMQReceiverModel>.Instance.Deserialize(bytes);

                        var receiver = new RabbitMQReceiver<T>();
                        receiver.Load(model);
                        return receiver;
                }

                public void Load(RabbitMQReceiverModel model)
                {
                        base.Load(model);
                        _queue.Load(model.RabbitMQQueueModel);
                }

                public void Save(RabbitMQReceiverModel model)
                {
                        _queue.Save(model.RabbitMQQueueModel);
                        base.Save(model);
                }

                /// <summary>
                ///         执行启动过程的具体步骤.
                /// </summary>
                /// <returns>
                ///         成功返回True, 否则返回False.
                /// </returns>
                /// <remarks>
                ///         若启动过程有多个步骤, 遇到返回错误的步骤立即停止向下执行.
                /// </remarks>
                protected override Result StartCore()
                {
                        var baseResult = base.StartCore();
                        if (!baseResult.IsSuccessed)
                        {
                                return baseResult;
                        }

                        Channel.QueueDeclare(_queue.Name, _queue.IsDurable, _queue.IsExclusive, _queue.IsAutoDelete,
                                null);

                        _consumer = new EventingBasicConsumer(Channel);
                        _consumer.Received += (model, ea) =>
                        {
                                var body = ea.Body;
                                var messageModel = Serializer.Deserialize(body);

                                Trace.WriteLine(DateTime.Now.ToChineseLongMillisecondString() + messageModel.Id);

                                OnReceiveSuccessed(new ValueEventArgs<T>(messageModel));
                        };
                        Channel.BasicConsume(_queue.Name, true, _consumer);

                        return Result.Successed;
                }


                public event EventHandler<ValueEventArgs<T>> ReceiveSuccessed;

                /// <summary>
                ///         引发启动事件。
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
                protected virtual void OnReceiveSuccessed(ValueEventArgs<T> e)
                {
                        e.Raise(this, ref ReceiveSuccessed);
                }

                public event EventHandler<ValueEventArgs<Exception>> ReceiveFailed;
        }
}
