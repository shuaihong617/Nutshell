using System.Windows.Forms;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Logging;
using Nutshell.Logging.UserLogging;
using Application = Nutshell.Components.Application;

namespace Nutshell.Hikvision.MachineVision.WPFUI
{
        public class GlobalManager : NotifyPropertyChangedObject
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
                public Application Application { get; private set; }

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
                public MachineVisionCamera Camera { get; private set; }

                #endregion 摄像机

                public void LoadApplication()
                {
                        Application = Application.Load(ConfigDirectory + "Application.config");
                }

                public void Start()
                {
                        Runtime = MachineVisionRuntime.Instance;
                        Runtime.Parent = Application;
                        Runtime.Start();

                        Camera = MachineVisionCamera.Load(ConfigDirectory + "Camera.config");
                        Camera.Parent = Application;

                        Camera.StartConnect();
                        Camera.StartDispatch();
                        Camera.StartCaptureLoop();
                }

                public void Stop()
                {
                        Camera.StopCaptureLoop();
                        Camera.StopDispatch();
                        Camera.StopConnect();

                        Runtime.Stop();
                }
        }
}