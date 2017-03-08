using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Xml.Models;
using Nutshell.Components.Xml;

namespace Nutshell.Automation.Xml
{
        public class XmlConnectableDeviceStorager:XmlDeviceStorager
	{               
                public void Load([MustNotEqualNull] ConnectableDevice device,
                        [MustNotEqualNull] XmlConnectableDeviceModel model)
                {
	                base.Load(device, model);
                }
        }
}