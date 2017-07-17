using System.Diagnostics;
using System.IO.Ports;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Communication;
using Nutshell.Components;
using Nutshell.Data.Models;
using Nutshell.Serializing;
using Nutshell.Serializing.Xml;
using Nutshell.SerialPorts.Messaging.Models;
using Nutshell.SerialPorts.Models;
using Nutshell.Storaging;

namespace Nutshell.SerialPorts
{
        public abstract class SerialPortActor<T> : Worker, IActor<T>
                where T : SerialPortMessage
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

                
                public override void Load(IIdentityModel model)
                {
                        base.Load(model);

                        var subModel = model as SerialPortActorModel;
                        Trace.Assert(subModel != null);
                }


                
                public IActor<T> BindToBus([MustNotEqualNull] Bus bus)
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
