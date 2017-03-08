using System.Windows.Forms;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Automation.Vision;
using Nutshell.Components;
using Nutshell.Data.Xml;
using Nutshell.Drawing.Imaging;
using Nutshell.Hikvision.MachineVision.Xml;
using Nutshell.Logging;
using Nutshell.Logging.UserLogging;
using Application = Nutshell.Data.Application;

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

		#region 界面

		public Control CameraPictureControl { get; set; }

	        [NotifyPropertyValueChanged]
		public int Step { get; set; } = 1;

		#endregion

		#region 摄像机

		[NotifyPropertyValueChanged]
		public MachineVisionRuntime Runtime { get; private set; }

		[NotifyPropertyValueChanged]
		public MachineVisionCamera Camera { get; private set; }


		

		#endregion

		public void LoadApplication()
                {
                        Application = new Application();
                        XmlApplicationStorager.Instance.Load(Application, ConfigDirectory + "Application.config");
                }

                public void Start()
                {
			Runtime = MachineVisionRuntime.Instance;
			Runtime.Parent = Application;
                        Runtime.Start();

			Camera = XmlMachineVisionCameraStorager.Instance.Load(ConfigDirectory + "Camera.config");
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