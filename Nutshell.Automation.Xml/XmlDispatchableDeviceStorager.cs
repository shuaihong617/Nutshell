using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Xml.Models;
using Nutshell.Components.Xml;

namespace Nutshell.Automation.Xml
{
        public class XmlDispatchableDeviceStorager:XmlConnectableDeviceStorager
	{               
                public void Load([MustNotEqualNull] DispatchableDevice device,
                        [MustNotEqualNull] XmlDispatchableDeviceModel model)
                {
			base.Load(device,model);
		}
        }
}