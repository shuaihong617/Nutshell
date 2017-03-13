using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Vision;
using NutshellAutomation.Vision.Xml.Models;

namespace NutshellAutomation.Vision.Xml
{
        public class XmlNetworkCameraStorager : XmlCameraStorager
        {
                protected XmlNetworkCameraStorager()
                {
                }

                public void Load([MustNotEqualNull] NetworkCamera camera,
                        [MustNotEqualNull] XmlNetworkCameraModel model)
                {
                        base.Load(camera, model);
                }
        }
}