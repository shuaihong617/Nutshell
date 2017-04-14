using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Data;
using Nutshell.Data.Xml;
using Nutshell.Logging;
using Nutshell.Logging.UserLogging;
using Nutshell.Messaging.Xml.Models;
using Nutshell.RabbitMQ.Xml;
using Nutshell.Storaging;

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

                        //Runtime = MicrosoftSynthesisRuntime.Instance;
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

		public RabbitMQSender<XmlSingleValueMessageModel> Sender { get;private set; }

	        public RabbitMQReceiver<XmlSingleValueMessageModel> Receiver { get; private set; }
                
                public void LoadApplication()
                {
                        Application = new Application();
                        XmlApplicationStorager.Instance.Load(Application, ConfigDirectory + "Application.config");
                }

                public void Start()
                {
			Bus = new RabbitMQBus();
			XmlRabbitMQBusStorager.Instance.Load(Bus, ConfigDirectory + "Bus.config");
	                Bus.Start();

			Sender = new RabbitMQSender<XmlSingleValueMessageModel>("Sender");
			XmlRabbitMQSenderStorager<XmlSingleValueMessageModel>.Instance.Load(Sender, ConfigDirectory + "Sender.config");
			Sender.SetExchange(Bus);
			Sender.Start();

			Receiver = new RabbitMQReceiver<XmlSingleValueMessageModel>("Receiver");
			XmlRabbitMQReceiverStorager<XmlSingleValueMessageModel>.Instance.Load(Receiver, ConfigDirectory + "Receiver.config");
			Receiver.Attach(Bus);
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