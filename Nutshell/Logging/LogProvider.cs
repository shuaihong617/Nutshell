// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-10-15
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-10-15
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Components;
using Nutshell.Logging.KernelLogging;

namespace Nutshell.Logging
{
        /// <summary>
        ///         日志服务提供者接口
        /// </summary>
        public class LogProvider: DirectProducer<LogRecord>,ILogProvider 
        {
                protected LogProvider()
                {
                }

                #region 单例

                /// <summary>
                ///         单例
                /// </summary>
                public static readonly LogProvider Instance = new LogProvider();

                #endregion

                public static void Initialize()
                {
                        Instance.Register(NLoger.Instance);
                }


                /// <summary>
                ///         Debugs the specified message.
                /// </summary>
                /// <param name="message">The message.</param>
                public void Debug([MustNotEqualNull] object message)
                {
                        Product(new LogRecord(LogLevel.调试, message.ToString()));
                }

                /// <summary>
                ///         Fatals the specified message.
                /// </summary>
                /// <param name="message">The message.</param>
                public void Info([MustNotEqualNull] object message)
                {
                        Product(new LogRecord(LogLevel.信息, message.ToString()));
                }

                /// <summary>
                ///         Fatals the specified message.
                /// </summary>
                /// <param name="message">The message.</param>
                public void Warn([MustNotEqualNull] object message)
                {
                        Product(new LogRecord(LogLevel.警告, message.ToString()));
                }

                /// <summary>
                ///         Fatals the specified message.
                /// </summary>
                /// <param name="message">The message.</param>
                public void Error([MustNotEqualNull] object message)
                {
                        Product(new LogRecord(LogLevel.错误, message.ToString()));
                }

                /// <summary>
                ///         Fatals the specified message.
                /// </summary>
                /// <param name="message">The message.</param>
                public void Fatal([MustNotEqualNull] object message)
                {
                        Product(new LogRecord(LogLevel.致命, message.ToString()));
                }
        }
}