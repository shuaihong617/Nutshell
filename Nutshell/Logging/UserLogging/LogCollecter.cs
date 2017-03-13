using System.Collections.ObjectModel;

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

                public ObservableCollection<LogRecord> LogRecords { get; }

                protected override void Consume(LogRecord t)
                {
                        base.Consume(t);

                        //Application.Current.Dispatcher.BeginInvoke(new Action(() => LogMessages.Add(message)));
                        LogRecords.Add(t);
                }
        }
}