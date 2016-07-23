using Nutshell.Data.Serializing;
using Nutshell.Messaging;

namespace Nutshell.Distributing
{
        public class ReceiveSite<TP> : Site<byte[], TP>, ISendSite where TP : Message
        {
                public ReceiveSite(IdentityObject parent, string id = "接收站点", Serializer serializer = null)
                        : base(parent, id)
                {
                        
                        //默认采用Protobuf序列化器
                        if (serializer == null)
                        {
                                serializer = MSSerializers.GetMSSerializer(typeof (TP));
                        }
                        _serializer = serializer;
                }

                /// <summary>
                ///         消息序列化器
                /// </summary>
                private readonly Serializer _serializer;

                public Receiver<byte[]> Receiver { get; protected set; }

                protected override bool StartCore()
                {
                        Receiver.Dispatched += Receiver_Dispatched;
                        return  Receiver.Start();
                }

                protected override bool StopCore()
                {
                        Receiver.Dispatched -= Receiver_Dispatched;
                        return  Receiver.Stop();
                }

                private void Receiver_Dispatched(object sender, ValueEventArgs<byte[]> e)
                {
                        Acquire(e.Data);
                }

                protected override TP Consume(byte[] tc)
                {
                        var tp = _serializer.Deserialize<TP>(tc);
                        return tp;
                }
        }
}
