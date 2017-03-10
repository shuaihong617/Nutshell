using System.Drawing;
using System.Windows.Media;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Data;
using Nutshell.Data.Xml;
using Nutshell.Logging;
using Nutshell.Logging.UserLogging;
using System;

namespace Nutshell.Drawing.Imaging.WPFUI
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

                #region 界面

                [NotifyPropertyValueChanged]
                public int Step { get; set; } = 1;

                #endregion 图像

                [NotifyPropertyValueChanged]
                public Bitmap SourceBitmap { get; set; }


                #region Canny边缘检测

                [NotifyPropertyValueChanged]
                public double LowThreshold { get; set; } = 50;

                [NotifyPropertyValueChanged]
                public double HighThreshold { get; set; } = 100;

                [NotifyPropertyValueChanged]
                public Bitmap CannyBitmap { get; set; }

                #endregion

                #region 摄像机

                public void LoadApplication()
                {
                        Application = new Application();
                        XmlApplicationStorager.Instance.Load(Application, ConfigDirectory + "Application.config");
                }

                #endregion
        }
}