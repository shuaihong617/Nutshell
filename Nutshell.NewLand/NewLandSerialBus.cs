using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutshell.Aspects.Events;
using Nutshell.Automation.CodeScan;
using Nutshell.Extensions;
using Nutshell.SerialPorts;
using PostSharp.Extensibility;

namespace Nutshell.NewLand
{
        public class NewLandSerialBus:SerialPortBus
        {
                //public SerialPortReceiver<int> BarcodeReceiver;

                public const byte Enter = 0x0D;
                protected override void Resolving()
                {
                        for (;;)
                        {
                                var index = Buffer.IndexOf(Enter);
                                if (index == -1)
                                {
                                        break;
                                }

                                var target = new byte[index];
                                Buffer.CopyTo(0, target, 0, index);
                                var barcode = Encoding.ASCII.GetString(target);

                                this.Info("条码："+ barcode);

                                OnBarcodeReceiveSuccessed(new BarcodeChangedEventArgs(barcode));

                                Buffer.RemoveRange(0, index + 1);
                        }
                        
                }

                #region 事件

                /// <summary>
                ///         当消息接收成功时发生。
                /// </summary>
                [Description("消息接收成功事件")]
                [LogEventInvokeHandler]
                public event EventHandler<BarcodeChangedEventArgs> BarcodeReceiveSuccessed;

                /// <summary>
                ///         当消息成功接收时发生
                /// </summary>
                /// <param name="e">包含消息的事件参数</param>
                protected virtual void OnBarcodeReceiveSuccessed(BarcodeChangedEventArgs e)
                {
                        e.Raise(this, ref BarcodeReceiveSuccessed);
                }

                #endregion
        }
}
