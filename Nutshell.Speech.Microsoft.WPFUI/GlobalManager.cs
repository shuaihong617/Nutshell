using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Data;
using Nutshell.Data.Xml;

namespace Nutshell.Speech.Microsoft.WPFUI
{
        public class GlobalManager : NotifyPropertyChangedObject
        {
                #region 构造函数

                private GlobalManager()
                {
                        ConfigDirectory = @"配置/";
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
                public string ConfigDirectory { get; set; }

                [WillNotifyPropertyChanged]
                public IApplication Application { get; private set; }

                [WillNotifyPropertyChanged]
                public MicrosoftSynthesisRuntime Runtime { get; private set; }

                [WillNotifyPropertyChanged]
                public MicrosoftSynthesizer Synthesizer { get; private set; }


                public void LoadApplication()
                {
                        Application = new Application();
                        XmlApplicationStorager.Instance.Load(Application, ConfigDirectory + "Application.config");
                }

                public void Start()
                {
                        //Runtime = MicrosoftSynthesizeRuntime.Instance;
                        //Runtime.Start();

                        //Synthesizer = new MicrosoftSynthesizer(Application);
                        ////XmlOpcServerStorager.Instance.Load(OpcServer, ConfigDirectory + "OpcServer.config");

                        //Synthesizer.Connect();
                        //Synthesizer.Establish();
                }


                public void Stop()
                {
                        //Synthesizer.Terminate();
                        //Synthesizer.Disconnect();

                        //Runtime.Stop();
                }
        }
}