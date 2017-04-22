using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Components;
using Nutshell.Logging;
using Nutshell.Logging.UserLogging;
using Nutshell.Messaging.Models;

namespace Nutshell.RabbitMQ.WPFUI
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

                public RabbitMQBus Bus { get; private set; }

                public RabbitMQSender<MultiStringKeyValuePairsMessageModel> Sender { get; private set; }

                public RabbitMQReceiver<MultiStringKeyValuePairsMessageModel> Receiver { get; private set; }

                public void LoadApplication()
                {
                        Application = Application.Load(ConfigDirectory + "Application.config");
                }

                public void Start()
                {
                        Bus = RabbitMQBus.Load(ConfigDirectory + "Bus.config");
                        Bus.Start();

                        Sender = RabbitMQSender<MultiStringKeyValuePairsMessageModel>.Load(ConfigDirectory + "Sender.config");
                        Sender.SetBus(Bus);
                        Sender.Start();

                        Receiver = RabbitMQReceiver<MultiStringKeyValuePairsMessageModel>.Load(ConfigDirectory + "Receiver.config");
                        Receiver.SetBus(Bus);
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