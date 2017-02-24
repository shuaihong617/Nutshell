using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Data;
using Nutshell.Data.Xml;
using Nutshell.Hardware.Vision.Hikvision.MachineVision;
using Nutshell.Logging;
using Nutshell.Logging.UserLogging;

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

	                Runtime = MachineVisionRuntime.Instance;
                }

                #endregion

                #region 单例

                /// <summary>
                ///         单例
                /// </summary>
                public static readonly GlobalManager Instance = new GlobalManager();

                #endregion

                /// <summary>
                ///         配置文件目录
                /// </summary>
                public string ConfigDirectory { get;private set; }

                [NotifyPropertyValueChanged]
                public Application Application { get; private set; }

                public LogCollecter LogCollecter { get; private set; }

                [NotifyPropertyValueChanged]
                public MachineVisionRuntime  Runtime { get; private set; }

                [NotifyPropertyValueChanged]
                public MachineVisionCamera Camera { get; private set; }


                public void LoadApplication()
                {
                        Application = new Application();
                        XmlApplicationStorager.Instance.Load(Application, ConfigDirectory + "Application.config");
                }

                public void Start()
                {
                        Runtime.Parent = Application;
                        Runtime.Start();

			Camera = new MachineVisionCamera();
                }


                public void Stop()
                {
			Runtime.Stop();
                }
        }
}