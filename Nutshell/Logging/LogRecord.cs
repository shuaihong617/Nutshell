
using System;
using Nutshell.Extensions;

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

                public DateTime CreateTime { get; }

                public LogLevel LogLevel { get; }

                public string Message { get; }


                public override string ToString()
                {
                        return $"{CreateTime.ToChineseLongMillisecondString()}        {LogLevel}        {Message}";
                }
        }
}
