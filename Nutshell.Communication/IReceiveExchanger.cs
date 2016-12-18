using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Nutshell.Aspects.Events;
using Nutshell.Messaging;

namespace Nutshell.Communication
{
        public interface IReceiveExchanger:IExchanger
        {
                /// <summary>
                /// 获取接收端口集合
                /// </summary>
                /// <value>接收端口集合</value>
                ReadOnlyCollection<IReceivePort> ReceivePorts { get; }

                #region 事件

                /// <summary>
                ///         当消息接收成功时发生。
                /// </summary>
                [Description("消息接收成功事件")]
                [LogEventInvokeHandler]
                event EventHandler<ValueEventArgs<IMessage>> ReceiveSuccessed;

                #endregion
        }
}
