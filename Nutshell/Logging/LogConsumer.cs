using Nutshell.Components;

namespace Nutshell.Logging
{
        /// <summary>
        /// 日志处理者接口
        /// </summary>
        public abstract class LogConsumer : DirectConsumer<LogRecord>
        {
        }
}