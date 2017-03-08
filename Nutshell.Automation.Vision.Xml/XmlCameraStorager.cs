using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Vision;
using Nutshell.Automation.Xml;
using NutshellAutomation.Vision.Xml.Models;

namespace NutshellAutomation.Vision.Xml
{
	public class XmlCameraStorager : XmlCapturableDeviceStorager
	{
		protected XmlCameraStorager()
		{
		}

		public void Load([MustNotEqualNull] Camera camera,
			[MustNotEqualNull] XmlCameraModel model)
		{
			base.Load(camera,model);
			camera.Region.Load(model.RegionModel);
		}
	}
}
