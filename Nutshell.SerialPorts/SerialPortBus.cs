using System;
using System.IO.Ports;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Communication;
using Nutshell.Serializing.Xml;
using Nutshell.SerialPorts.Models;
using Nutshell.Storaging;
using Nutshell.Storaging.Xml;

namespace Nutshell.SerialPorts
{
        public class SerialPortBus : Bus, IStorable<SerialPortBusModel>
        {

                #region 属性

                public SerialPortAuthorization Authorization { get; } = new SerialPortAuthorization();

		/// <summary>
		/// 获取连接
		/// </summary>
		/// <value>连接</value>
		/// <remarks>
		/// 1 连接可以Dispose，所以必须可为null。
		/// 2 连接比较消耗资源，所以多个发送和接收单元尽量共享通道。（官方文档上说的）
		/// </remarks>
                public SerialPort SerialPort { get; private set; } = new SerialPort();

		#endregion

		public static SerialPortBus Load([MustNotEqualNullOrEmpty]string fileName)
                {
                        var bytes = XmlStorager.Instance.Load(fileName);
                        var model = XmlSerializer<SerialPortBusModel>.Instance.Deserialize(bytes);

                        var bus = new SerialPortBus();
                        bus.Load(model);
                        return bus;
                }

                /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">读取数据的源数据模型，该数据模型不能为空引用</param>
                public void Load(SerialPortBusModel model)
                {
                        base.Load(model);

                        Authorization.Load(model.SerialPortAuthorizationModel);
                }


                /// <summary>
                ///         保存数据到数据模型
                /// </summary>
                /// <param name="model">写入数据的目的数据模型，该数据模型不能为空引用</param>
                public void Save(SerialPortBusModel model)
                {
                        throw new NotImplementedException();
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
        }
}
