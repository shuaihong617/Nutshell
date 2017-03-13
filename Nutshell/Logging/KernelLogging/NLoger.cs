// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-01-19
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-01-19
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using NLog;
using System.Diagnostics;

namespace Nutshell.Logging.KernelLogging
{
        /// <summary>
        /// Class NLogDebuger.
        /// </summary>
        public class NLoger : LogConsumer
        {
                #region 单例

                /// <summary>
                /// 单例
                /// </summary>
                public static readonly NLoger Instance = new NLoger();

                #endregion 单例

                /// <summary>
                /// The _logger
                /// </summary>
                private readonly Logger _logger = LogManager.GetLogger("NLoger");

                /// <summary>
                /// Consumes the specified t.
                /// </summary>
                /// <param name="t">The t.</param>
                protected override void Consume(LogRecord t)
                {
                        base.Consume(t);

                        Trace.Assert(_logger != null);

                        switch (t.LogLevel)
                        {
                                case LogLevel.调试:
                                        if (_logger.IsDebugEnabled)
                                        {
                                                _logger.Debug(t);
                                        }
                                        break;

                                case LogLevel.信息:
                                        if (_logger.IsInfoEnabled)
                                        {
                                                _logger.Info(t);
                                        }
                                        break;

                                case LogLevel.警告:
                                        if (_logger.IsWarnEnabled)
                                        {
                                                _logger.Warn(t);
                                        }
                                        break;

                                case LogLevel.错误:
                                        if (_logger.IsErrorEnabled)
                                        {
                                                _logger.Error(t);
                                        }
                                        break;

                                case LogLevel.致命:
                                        if (_logger.IsFatalEnabled)
                                        {
                                                _logger.Fatal(t);
                                        }
                                        break;
                        }
                }

                /// <summary>
                /// Informations the star.
                /// </summary>
                public void Separate()
                {
                        if (_logger != null && _logger.IsInfoEnabled)
                        {
                                _logger.Info("***************************************************");
                        }
                }
        }
}