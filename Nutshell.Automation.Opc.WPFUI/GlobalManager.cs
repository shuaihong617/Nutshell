using System;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Automation.Opc.Xml;
using Nutshell.Automation.OPC;
using Nutshell.Data;
using Nutshell.Data.Xml;
using Nutshell.Speech.Microsoft;

namespace Nutshell.Automation.Opc.WPFUI
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
                public MicrosoftSynthesisRuntime MicrosoftSynthesisRuntime { get; private set; }

                [WillNotifyPropertyChanged]
                public MicrosoftSynthesizer MicrosoftSynthesizer { get; private set; }


                public void LoadApplication()
                {
                        Application = new Application();
                        XmlApplicationStorager.Instance.Load(Application, ConfigDirectory + "Application.config");
                }

                public void Start()
                {
                        //OpcRuntime = OpcRuntime.Instance;
                        //OpcRuntime.Start();

                        //OpcServer = new OpcServer(Application);
                        //XmlOpcServerStorager.Instance.Load(OpcServer, ConfigDirectory + "OpcServer.config");

                        //OpcServer.Connect();
                        //OpcServer.Establish();
                }


                public void Stop()
                {
                        //OpcServer.Terminate();
                        //OpcServer.Disconnect();

                        //OpcRuntime.Stop();
                }
        }
}