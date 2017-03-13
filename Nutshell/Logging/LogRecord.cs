using Nutshell.Extensions;
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

                public DateTime CreateTime { get; }

                public LogLevel LogLevel { get; }

                public string Message { get; }

                /// <summary>
                ///         返回表示当前对象的字符串。
                /// </summary>
                /// <returns>
                ///         表示当前对象的字符串。
                /// </returns>
                public override string ToString()
                {
                        return $"{CreateTime.ToChineseLongMillisecondString()}        {LogLevel}        {Message}";
                }
        }
}