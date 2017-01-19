
namespace Nutshell.Logging
{
        public class LogRecord
        {
                public LogRecord(LogLevel logLevel, string message)
                {
                        TimeStampChain = new TimeStampChain();
                        LogLevel = logLevel;
                        Message = message;
                }

                public TimeStampChain TimeStampChain { get; private set; }

                public LogLevel LogLevel { get; private set; }

                public string Message { get; private set; }


                public override string ToString()
                {
                        return $"{TimeStampChain.CreateTime.ToChineseLongMillisecondString()}        {LogLevel}        {Message}";
                }
        }
}
