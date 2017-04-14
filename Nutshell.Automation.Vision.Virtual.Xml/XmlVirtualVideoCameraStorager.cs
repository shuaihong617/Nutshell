using Nutshell.Automation.Vision.Virtual;
using Nutshell.Automation.Vision.Virtual.Models;
using Nutshell.Automation.Vision.Virtual.Xml.Models;
using Nutshell.IO.Aspects.Locations.Contracts;
using Nutshell.Serializing.Xml;
using Nutshell.Storaging.Xml;
using NutshellAutomation.Vision.Xml;

namespace NutshellAutomation.Vision.Virtual.Xml
{
        public class XmlVirtualVideoCameraStorager : XmlCameraStorager
        {
                protected XmlVirtualVideoCameraStorager()
                {
                }

                #region 单例

                /// <summary>
                ///         单例
                /// </summary>
                public static readonly XmlVirtualVideoCameraStorager Instance = new XmlVirtualVideoCameraStorager();

                #endregion 单例

                public VirtualVideoCamera Load(string fileName)
                {
                        var bytes = XmlStorager.Instance.Load(fileName);
                        var model = XmlSerializer<XmlVirtualVideoCameraModel>.Instance.Deserialize(bytes);

                        var camera = new VirtualVideoCamera();

                        camera.Load(model);
                        Load(camera, model);

                        return camera;
                }
        }
}