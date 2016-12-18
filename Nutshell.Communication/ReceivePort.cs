using System;
using System.ComponentModel;
using Nutshell.Aspects.Events;
using Nutshell.Components;
using Nutshell.Messaging;
using Nutshell.Serializing;

namespace Nutshell.Communication
{
        /// <summary>
        ///         接收端口
        /// </summary>
        /// <seealso cref="IPort" />
        public class ReceivePort :Port, IReceivePort
        {
                public ReceivePort(IdentityObject parent, string id = null, ISerializer serializer = null) 
                        : base(parent, id, serializer)
                {
                }

                protected override bool StartCore()
                {
                        throw new NotImplementedException();
                }

                protected override bool StopCore()
                {
                        throw new NotImplementedException();
                }

                #region 事件

                /// <summary>
                /// 当消息接收成功时发生。
                /// </summary>
                public event EventHandler<ValueEventArgs<IMessage>> ReceiveSuccessed;

                /// <summary>
                ///         Raises the <see cref="E:Opened" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
                protected virtual void OnReceiveSuccessed(ValueEventArgs<IMessage> e)
                {
                        e.Raise(this, ref ReceiveSuccessed);
                }
                #endregion

                
        }
}
