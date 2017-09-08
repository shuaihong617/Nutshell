using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Components;
using Nutshell.Logging;
using Nutshell.Logging.UserLogging;
using Nutshell.RabbitMQ.Messaging.Models;

namespace Nutshell.RabbitMQ.WPFUI
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

                public RabbitMQBus Bus { get; private set; }

                public RabbitMQSender<RabbitMQMultiStringKeyValuePairsMessageModel> Sender { get; private set; }

                public RabbitMQReceiver<RabbitMQMultiStringKeyValuePairsMessageModel> Receiver { get; private set; }

                public void LoadApplication()
                {
                        AppInstance = AppInstance.Load(ConfigDirectory + "Application.config");
                }

                public void Start()
                {
                        Bus = RabbitMQBus.Load(ConfigDirectory + "Bus.config");
                        Bus.Start();

                        Sender = RabbitMQSender<RabbitMQMultiStringKeyValuePairsMessageModel>.Load(ConfigDirectory + "Sender.config");
                        Sender.BindBus(Bus);
                        Sender.Start();

                        Receiver = RabbitMQReceiver<RabbitMQMultiStringKeyValuePairsMessageModel>.Load(ConfigDirectory + "Receiver.config");
                        Receiver.BindBus(Bus);
                        Receiver.Start();
                }

                public void Stop()
                {
                        Sender.Stop();
                        Receiver.Stop();

                        Bus.Stop();
                }
        }
}