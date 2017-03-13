using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Xml.Models;

namespace Nutshell.Automation.Xml
{
        public class XmlCapturableDeviceStorager : XmlDispatchableDeviceStorager
        {
                public void Load<T>([MustNotEqualNull] CapturableDevice<T> device, [MustNotEqualNull] XmlCapturableDeviceModel model) where T : IIdentifiable
                {
                        base.Load(device, model);
                        device.CaptureLooper.Load(model.XmlCaptureLooperModel);
                }
        }
}