using System.Diagnostics;
using System.IO.Ports;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Communication;
using Nutshell.Components;
using Nutshell.Serializing;
using Nutshell.Serializing.Xml;
using Nutshell.SerialPorts.Messaging.Models;
using Nutshell.SerialPorts.Models;
using Nutshell.Storaging;

namespace Nutshell.SerialPorts
{
        public abstract class SerialPortActor<T> : Worker, IStorable<SerialPortActorModel>, IActor<T>
                where T : SerialPortMessageModel
        {
                protected SerialPortActor(string id = "")
                        : base(id)
                {
                }

                #region 属性

                public ISerializer<T> Serializer { get; } = XmlSerializer<T>.Instance;

                [MustNotEqualNull]
                protected SerialPort SerialPort { get; private set; }

                #endregion

                public void Load([MustNotEqualNull] SerialPortActorModel model)
                {
                        base.Load(model);
                }

                public void Save([MustNotEqualNull] SerialPortActorModel model)
                {
                        base.Save(model);
                }


                public IActor<T> BindBus([MustNotEqualNull] Bus bus)
                {
                        Trace.Assert(SerialPort == null);

                        var serialBus = bus as SerialPortBus;
                        Trace.Assert(serialBus != null);
                        Trace.Assert(serialBus.SerialPort != null);

                        SerialPort = serialBus.SerialPort;
                        return this;
                }
        }
}
