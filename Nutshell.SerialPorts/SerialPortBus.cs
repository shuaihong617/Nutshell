using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nutshell.Communication;
using Nutshell.Components;
using Nutshell.Data.Models;
using Nutshell.Extensions;
using Nutshell.SerialPorts.Models;

namespace Nutshell.SerialPorts
{
        public abstract class SerialPortBus : Bus
        {
                protected SerialPortBus()
                {
                        ReadLooper = new ActionLooper(string.Empty, ReadAndResolve);
                        ReadLooper.Parent = this;
                }

                #region 属性

                public SerialPortAuthorization Authorization { get; } = new SerialPortAuthorization();

                /// <summary>
                ///         获取串口
                /// </summary>
                /// <value>串口</value>
                public SerialPort SerialPort { get; private set; } = new SerialPort();

                protected List<byte> Buffer { get; } = new List<byte>(1024);

                public Looper ReadLooper { get; }

                #endregion

                /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">读取数据的源数据模型，该数据模型不能为空引用</param>
                public override void Load(IIdentityModel model)
                {
                        base.Load(model);

                        var subModel = model as SerialPortBusModel;
                        Trace.Assert(subModel != null);

                        Authorization.Load(subModel.SerialPortAuthorizationModel);
                        ReadLooper.Load(subModel.ReadLooperModel);
                }


                protected override bool StartCore()
                {
                        if (!base.StartCore())
                        {
                                return false;
                        }

                        SerialPort = new SerialPort
                        {
                                PortName = Authorization.PortName,
                                BaudRate = Authorization.BaudRate
                        };

                        if (!SerialPort.IsOpen)
                        {
                                SerialPort.Open();
                        }

                        ReadLooper.Start();

                        return true;
                }

                /// <summary>
                ///         执行退出过程的具体步骤.
                /// </summary>
                /// <returns>成功返回True, 否则返回False.</returns>
                /// <remarks>
                ///         若退出过程有多个步骤,执行尽可能多的步骤, 以保证尽量清理现场.
                /// </remarks>
                protected override bool StopCore()
                {
                        base.StopCore();

                        ReadLooper.Stop();

                        if (SerialPort.IsOpen)
                        {
                                SerialPort.Close();
                        }
                        SerialPort.Close();

                        return true;
                }

                public void SetPortName(SerialPortName serialPortName)
                {
                }

                private void ReadAndResolve()
                {
                        if (SerialPort.BytesToRead == 0)
                        {
                                return;
                        }

                        var readResult = SerialPort.ReadExisting();

                        this.Info("接收：" + readResult);
                        var bytes = Encoding.ASCII.GetBytes(readResult);
                        Buffer.AddRange(bytes);

                        Resolving();
                }

                protected abstract void Resolving();
        }
}
