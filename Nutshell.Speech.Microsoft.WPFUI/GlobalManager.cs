using System.Linq;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Data;
using Nutshell.Data.Xml;
using Nutshell.Logging;
using Nutshell.Logging.UserLogging;

namespace Nutshell.Speech.Microsoft.WPFUI
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

                [WillNotifyPropertyChanged]
                public IApplication Application { get; private set; }

                public LogCollecter LogCollecter { get; private set; }

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
                        Runtime = new MicrosoftSynthesisRuntime(Application);
                        Runtime.Start();

			Synthesizer = new MicrosoftSynthesizer(Application);

	                Synthesizer.SelectVoice(Runtime.ChineseVoices.First().VoiceInfo.Name);
                }


                public void Stop()
                {
			
			//Runtime.Stop();
                }
        }
}