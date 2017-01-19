using System.Collections.ObjectModel;
using Nutshell.Aspects.Locations.Propertys;

namespace Nutshell.Logging.UserLogging
{
        /// <summary>
        ///         日志收集者接口
        /// </summary>
        public class LogCollecter : LogConsumer
        {
                public LogCollecter()
                {
                        LogRecords = new ObservableCollection<LogRecord>();
                }

                public ObservableCollection<LogRecord> LogRecords { get; private set; }

                protected override void Consume(LogRecord t)
                {
                        base.Consume(t);

                        //Application.Current.Dispatcher.BeginInvoke(new Action(() => LogMessages.Add(message)));
                        LogRecords.Add(t);
                }
        }
}
