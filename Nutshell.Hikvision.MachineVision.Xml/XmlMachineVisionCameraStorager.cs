using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Vision;
using Nutshell.Hikvision.MachineVision.Xml.Models;
using Nutshell.IO.Aspects.Locations.Contracts;
using Nutshell.Serializing.Xml;
using Nutshell.Storaging.Xml;
using NutshellAutomation.Vision.Xml;

namespace Nutshell.Hikvision.MachineVision.Xml
{
        public class XmlMachineVisionCameraStorager : XmlNetworkCameraStorager
        {
                protected XmlMachineVisionCameraStorager()
                {

                }

                #region 单例

                /// <summary>
                ///         单例
                /// </summary>
                public static readonly XmlMachineVisionCameraStorager Instance = new XmlMachineVisionCameraStorager();

                #endregion

                public MachineVisionCamera Load([MustFileExist]string fileName)
                {
                        var bytes = XmlStorager.Instance.Load(fileName);
                        var model= XmlSerializer<XmlMachineVisionCameraModel>.Instance.Deserialize(bytes);

			var camera = new MachineVisionCamera();

			camera.Load(model);
			Load(camera, model);

	                return camera;
                }
        }
}
