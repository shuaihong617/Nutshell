using System;
using System.Threading.Tasks;
using Nutshell.Communication;
using Nutshell.Extensions;
using Nutshell.SerialPorts.Messaging.Models;
using Nutshell.SerialPorts.Models;
using Nutshell.Storaging;

namespace Nutshell.SerialPorts
{
        public class SerialPortReceiver<T> : SerialPortActor<T>, IReceiver<T>
                where T : SerialPortMessage
        {
                public SerialPortReceiver(string id = "")
                        : base(id)
                {
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
                protected override bool StartCore()
                {
                        if (!base.StartCore())
                        {
                                return false;
                        }

                        Task.Run(() =>
                        {
                                if (SerialPort.BytesToRead != 0)
                                {
                                        SerialPort.ReadExisting();
                                }
                        });


                        return true;
                }

                protected override bool StopCore()
                {
                        return base.StopCore();
                }

                #region 事件

                public event EventHandler<ValueEventArgs<T>> ReceiveSuccessed;

                /// <summary>
                ///         引发启动事件。
                /// </summary>
                /// <param name="e">包含事件数据的实例<see cref="EventArgs" />
                protected virtual void OnReceived(ValueEventArgs<T> e) => e.Raise(this, ref ReceiveSuccessed);

                #endregion
        }
}
