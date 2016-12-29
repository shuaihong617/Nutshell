using Nutshell.Automation.Models;
using Nutshell.Components;
using Nutshell.Data;

namespace Nutshell.Automation
{
        public interface IControlableDevice : IConnectableDevice, IStorable<IConnectableDeviceModel>
        {
                IDispatcher ControlDispatcher { get; }
        }
}
