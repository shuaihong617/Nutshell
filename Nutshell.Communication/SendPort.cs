using System;
using System.ComponentModel;
using Nutshell.Aspects.Events;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Components;
using Nutshell.Messaging;
using Nutshell.Serializing;

namespace Nutshell.Communication
{
        /// <summary>
        ///         发送端口
        /// </summary>
        /// <seealso cref="IPort" />
        public class SendPort : Port, ISendPort
        {
                public SendPort(IdentityObject parent, string id = null, ISerializer serializer = null, [MustNotEqualNull]ISender sender = null) 
                        : base(parent, id, serializer)
                {
                        Sender = sender;
                }

                public ISender Sender { get; private set; }

                protected override bool StartCore()
                {
                        throw new NotImplementedException();
                }

                protected override bool StopCore()
                {
                        throw new NotImplementedException();
                }

                /// <summary>
                /// 发送消息
                /// </summary>
                /// <param name="message">待发送的消息</param>
                public void Send(IMessage message)
                {
                        var bytes = Serializer.Serialize(message);
                        Sender.Send(bytes);
                }

                #region 事件

                /// <summary>
                ///         当数据发送成功时发生。
                /// </summary>
                [Description("发送成功事件")]
                [LogEventInvokeHandler]
                public event EventHandler<EventArgs> SendSuccessed;

                /// <summary>
                ///         Raises the <see cref="E:Opened" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
                public virtual void OnSendSuccessed(EventArgs e)
                {
                        e.Raise(this, ref SendSuccessed);
                }
                #endregion

                
        }
}
