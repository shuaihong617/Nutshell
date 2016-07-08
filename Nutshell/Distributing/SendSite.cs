using System;
using Nutshell.Data;
using Nutshell.Data.Serializing;
using Nutshell.Messaging;

namespace Nutshell.Distributing
{
        public class SendSite<TC> : Site<TC, byte[]>, ISendSite where TC : Message
        {
                public SendSite(IdentityObject parent, string id = "发送站点", Serializer serializer = null)
                        : base(parent,id)
                {
                        //默认采用Protobuf序列化器
                        if (serializer == null)
                        {
                                serializer = MSSerializers.GetMSSerializer(typeof (TC));
                        }
                        _serializer = serializer;
                }

                /// <summary>
                ///         消息序列化器
                /// </summary>
                private readonly Serializer _serializer;

                public Sender<byte[]> Sender { get; protected set; }

                protected override bool StartCore()
                {
                        return Sender.Start();
                }

                protected override bool StopCore()
                {
                        return Sender == null || Sender.Stop();
                }

                public void Send(TC c)
                {
                        Acquire(c);
                }

                protected override byte[] Consume(TC tc)
                {
                        return _serializer.Serialize(tc);
                }

                protected override void OnDispatched(ValueEventArgs<byte[]> e)
                {
                        base.OnDispatched(e);
                        Sender.Acquire(e.Data);
                }
        }
}
