using System;
using System.ComponentModel;
using Nutshell.Aspects.Events;
using Nutshell.Messaging;

namespace Nutshell.Communication
{
        /// <summary>
        ///         接收端口
        /// </summary>
        /// <seealso cref="IPort" />
        public interface IReceivePort : IPort
        {

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
