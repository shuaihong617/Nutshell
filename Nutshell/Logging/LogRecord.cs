
using System;

namespace Nutshell.Logging
{
        public class LogRecord
        {
                public LogRecord(LogLevel logLevel, string message)
                {
                        CreateTime = DateTime.Now;
                        LogLevel = logLevel;
                        Message = message;
                }

                public DateTime CreateTime { get; private set; }

                public LogLevel LogLevel { get; private set; }

                public string Message { get; private set; }


                public override string ToString()
                {
                        return $"{CreateTime.ToChineseLongMillisecondString()}        {LogLevel}        {Message}";
                }
        }
}
