using System.Linq;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Components;
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

                        Runtime = MicrosoftSynthesisRuntime.Instance;
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

                [NotifyPropertyValueChanged]
                public MicrosoftSynthesisRuntime Runtime { get; }

                [NotifyPropertyValueChanged]
                public MicrosoftSynthesizer Synthesizer { get; private set; }

                public void LoadApplication()
                {
                        Application = Application.Load(ConfigDirectory + "Application.config");
                }

                public void Start()
                {
                        Runtime.Parent = Application;
                        Runtime.Start();

                        Synthesizer = new MicrosoftSynthesizer();
                        Synthesizer.Parent = Runtime;

                        Synthesizer.SelectVoice(Runtime.ChineseVoices.First().VoiceInfo.Name);
                }

                public void Stop()
                {
                        Runtime.Stop();
                }
        }
}