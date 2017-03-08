using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Xml.Models;
using Nutshell.Components.Xml;

namespace Nutshell.Automation.Xml
{
        public class XmlDeviceStorager
        {               
                public void Load([MustNotEqualNull] Device device,
                        [MustNotEqualNull] XmlDeviceModel model)
                {
			var manufacturingInformation = new ManufacturingInformation();
			manufacturingInformation.Load(model.XmlManufacturingInformationModel);

			device.ManufacturingInformation = manufacturingInformation;
		}
        }
}