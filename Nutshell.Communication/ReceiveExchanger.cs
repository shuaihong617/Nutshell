using System;
using System.Collections.ObjectModel;
using Nutshell.Messaging;

namespace Nutshell.Communication
{
        public class ReceiveExchanger : Exchanger, IReceiveExchanger
        {
                public ReceiveExchanger(IdentityObject parent, string id = null) 
                        : base(parent, id)
                {
                }

                /// <summary>
                /// 获取接收端口集合
                /// </summary>
                /// <value>接收端口集合</value>
                public ReadOnlyCollection<IReceivePort> ReceivePorts { get; private set; }

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
                /// 当消息成功接收时发生
                /// </summary>
                /// <param name="e">包含消息的事件参数</param>
                /// <exception cref="System.NotImplementedException"></exception>
                protected virtual void OnReceiveSuccessed(ValueEventArgs<IMessage> e)
                {
                        e.Raise(this, ref ReceiveSuccessed);
                }

                #endregion

                
        }
}
