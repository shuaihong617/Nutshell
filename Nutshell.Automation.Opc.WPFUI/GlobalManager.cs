﻿using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Components;
using Nutshell.Logging;
using Nutshell.Logging.UserLogging;

namespace Nutshell.Automation.Opc.WPFUI
{
        public class GlobalManager : NotifyPropertyValueChangedObject
        {
                #region 构造函数

                private GlobalManager()
                {
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
                public string ConfigDirectory { get; } = @"配置/";

                [NotifyPropertyValueChanged]
                public AppInstance AppInstance { get; private set; }

                public LogCollecter LogCollecter { get; }

                [NotifyPropertyValueChanged]
                public OpcRuntime Runtime { get; private set; }

                [NotifyPropertyValueChanged]
                public OpcServer Server { get; private set; }

                public void LoadApplication()
                {
                        AppInstance = AppInstance.Load(ConfigDirectory + "Application.config");
                }

                public void Start()
                {
                        Runtime = OpcRuntime.Instance;
                        Runtime.Parent = AppInstance;
                        Runtime.Start();

                        Server = OpcServer.Load(ConfigDirectory + "OpcServer.config");
                        Server.Parent = AppInstance;

                        Server.StartConnect();
                        Server.StartDispatch();
                }

                public void Stop()
                {
                        Server.StopDispatch();
                        Server.StopConnect();

                        Runtime.Stop();
                }
        }
}