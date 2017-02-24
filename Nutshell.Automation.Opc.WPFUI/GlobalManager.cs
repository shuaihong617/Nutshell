using System;
using System.Linq;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Automation.Opc.Xml;
using Nutshell.Automation.Opc;
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
                public string ConfigDirectory { get;private set; }

                [NotifyPropertyValueChanged]
                public IApplication Application { get; private set; }

                public LogCollecter LogCollecter { get; private set; }

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
                        Runtime = new OpcRuntime(Application);
                        Runtime.Start();

			Server = new OpcServer();
	                Server.Parent = Application;
			XmlOpcServerStorager.Instance.Load(Server, ConfigDirectory + "OpcServer.config");
		}


                public void Stop()
                {
			
			//Runtime.Stop();
                }
        }
}