using System.Windows.Forms;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Components;
using Nutshell.Components.Models;
using Nutshell.Hikvision.MachineVision.Models;
using Nutshell.Logging;
using Nutshell.Logging.UserLogging;
using Nutshell.Storaging.Xml;

namespace Nutshell.Hikvision.MachineVision.WPFUI
{
        public class GlobalManager : NotifyPropertyValueChangedObject
        {
                #region 构造函数

                private GlobalManager()
                {
                        ConfigDirectory = @"配置/";

                        LogProvider.Initialize();
                        LogCollecter = new LogCollecter();
                        LogProvider.Instance.Register(LogCollecter);
                }

                #endregion 构造函数

                #region 单例

                /// <summary>
                ///         单例
                /// </summary>
                public static readonly GlobalManager Instance = new GlobalManager();

                #endregion 单例

                /// <summary>
                ///         配置文件目录
                /// </summary>
                public string ConfigDirectory { get; }

                [NotifyPropertyValueChanged]
                public AppInstance AppInstance { get; private set; }

                public LogCollecter LogCollecter { get; }

                #region 界面

                public Control CameraPictureControl { get; set; }

                [NotifyPropertyValueChanged]
                public int Step { get; set; } = 1;

                #endregion 界面

                #region 摄像机

                [NotifyPropertyValueChanged]
                public MachineVisionRuntime Runtime { get; private set; }

                [NotifyPropertyValueChanged]
                public MachineVisionCameraDevice CameraDevice { get; private set; }

                #endregion 摄像机

                public void LoadApplication()
                {
                        AppInstance = XmlStorager<AppInstance,AppInstanceModel>.Instance.Load(ConfigDirectory + "Application.config");
                }

                public void Start()
                {
                        Runtime = MachineVisionRuntime.Instance;
                        Runtime.Parent = AppInstance;
                        Runtime.Start();

                        CameraDevice = XmlStorager<MachineVisionCameraDevice, MachineVisionCameraDeviceModel>.Instance.Load(ConfigDirectory + "Camera.config");
                        CameraDevice.Parent = AppInstance;

                        CameraDevice.StartConnect();
                        CameraDevice.StartDispatch();
                        CameraDevice.StartCaptureLoop();
                }

                public void Stop()
                {
                        CameraDevice.StopCaptureLoop();
                        CameraDevice.StopDispatch();
                        CameraDevice.StopConnect();

                        Runtime.Stop();
                }
        }
}