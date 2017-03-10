using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Automation.Opc.Xml;
using Nutshell.Data;
using Nutshell.Data.Xml;
using Nutshell.Logging;
using Nutshell.Logging.UserLogging;

namespace Nutshell.Automation.Opc.WPFUI
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
                public string ConfigDirectory { get; }

                [NotifyPropertyValueChanged]
                public Application Application { get; private set; }

                public LogCollecter LogCollecter { get; }

                [NotifyPropertyValueChanged]
                public OpcRuntime Runtime { get; private set; }

                [NotifyPropertyValueChanged]
                public OpcServer Server { get; private set; }


                public void LoadApplication()
                {
                        Application = new Application();
                        XmlApplicationStorager.Instance.Load(Application, ConfigDirectory + "Application.config");
                }

                public void Start()
                {
                        Runtime = OpcRuntime.Instance;
                        Runtime.Parent = Application;
                        Runtime.Start();

                        Server = new OpcServer();
                        Server.Parent = Runtime;
                        XmlOpcServerStorager.Instance.Load(Server, ConfigDirectory + "OpcServer.config");
                }


                public void Stop()
                {
                        //Runtime.Stop();
                }
        }
}