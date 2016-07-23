// ***********************************************************************
// 程序集         : FutureTech
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-01-16
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-01-16
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using NLog;

namespace Nutshell.Log
{
        /// <summary>
        ///         Class NLogDebuger.
        /// </summary>
        public static class NLoger
        {
                /// <summary>
                ///         The _logger
                /// </summary>
                private static readonly Logger Logger = LogManager.GetLogger("NLoger");

                private const string Formater = "{0,-32}{1,-4}{2}";

                /// <summary>
                ///         Informations the star.
                /// </summary>
                public static void Separate()
                {
                        if (Logger != null && Logger.IsInfoEnabled)
                        {
                                Logger.Info(
                                        "***********************************************************************************");
                        }
                }

                /// <summary>
                ///         Debugs the specified message.
                /// </summary>
                /// <param name="message">The message.</param>
                public static void Debug(string message)
                {
                        if (Logger != null && Logger.IsDebugEnabled)
                        {
                                Logger.Debug(Formater, DateTime.Now.ToChineseLongMillisecondString(), "调试", message);
                        }
                }

                public static void Debug(this IIdentityObject identityObject, string message)
                {
                        Debug(identityObject.GlobalId + message);
                }

                /// <summary>
                ///         Fatals the specified message.
                /// </summary>
                /// <param name="message">The message.</param>
                private static void Info(object message)
                {
                        if (Logger != null && Logger.IsInfoEnabled)
                        {
                                Logger.Info(DateTime.Now.ToChineseLongMillisecondString() + "    信息    " + message);
                        }
                }

                public static void Info(this IIdentityObject identityObject, params object[] args)
                {
                        Info(identityObject.GlobalId + ":" + string.Concat(args));
                }

                public static void InfoFormat(this IIdentityObject identityObject, string format, params object[] args)
                {
                        Info(string.Format(format, args));
                }

                public static void InfoEvent(this IIdentityObject identityObject, object eventName, object args = null)
                {
                        if (args == null)
                        {
                                Info(identityObject, "引发", eventName, "事件.");
                        }
                        else
                        {
                                Info(identityObject, "引发", eventName, "事件.", args);
                        }
                }

                public static void InfoSuccess(this IIdentityObject identityObject, object operation)
                {
                        Info(identityObject, operation, "成功");
                }

                public static void InfoSuccessWithDescription(this IIdentityObject identityObject, string operation,
                        object description)
                {
                        Info(identityObject, operation, "成功,", description);
                }

                /// <summary>
                ///         Fatals the specified message.
                /// </summary>
                /// <param name="message">The message.</param>
                private static void Warn(string message)
                {
                        if (Logger != null && Logger.IsWarnEnabled)
                        {
                                Logger.Warn(Formater, DateTime.Now.ToChineseLongMillisecondString(), "警告", message);
                        }
                }

                public static void Warn(this IIdentityObject identityObject, string message)
                {
                        Warn(identityObject.GlobalId + message);
                }

                public static void WarnFormat(this IIdentityObject identityObject, string format, params object[] args)
                {
                        Warn(string.Format(format, args));
                }

                /// <summary>
                ///         Warns the specified key.
                /// </summary>
                /// <param name="identityObject">The identity object.</param>
                /// <param name="operation">The operation.</param>
                /// <param name="reason">The reason.</param>
                public static void WarnFail(this IIdentityObject identityObject, object operation,
                        object reason = null)
                {
                        Warn(identityObject, operation + "失败,错误原因：" + reason ?? "无");
                }

                public static void InfoSuccessOrWarnFailWithReason(this IIdentityObject identityObject, object operation,
                        bool isSuccess,
                        object reason)
                {
                        if (isSuccess)
                        {
                                InfoSuccess(identityObject, operation);
                        }
                        else
                        {
                                WarnFail(identityObject, operation, reason);
                        }
                }

                /// <summary>
                ///         Fatals the specified message.
                /// </summary>
                /// <param name="message">The message.</param>
                private static void Error(string message)
                {
                        if (Logger != null && Logger.IsErrorEnabled)
                        {
                                Logger.Error(Formater, DateTime.Now.ToChineseLongMillisecondString(), "错误", message);
                        }
                }

                public static void Error(this IIdentityObject identityObject, string message)
                {
                        Error(identityObject.GlobalId + message);
                }

                public static void ErrorFormat(this IIdentityObject identityObject, string format, params object[] args)
                {
                        Error(string.Format(format, args));
                }

                public static void ErrorFail(this IIdentityObject identityObject, string operation)
                {
                        ErrorFormat(identityObject, "{0}失败.", operation);
                }

                public static void ErrorFailWithReason(this IIdentityObject identityObject, string operation,
                        object description)
                {
                        ErrorFormat(identityObject, "{0}失败, 错误原因:{1}", operation, description);
                }

                /// <summary>
                ///         Fatals the specified message.
                /// </summary>
                /// <param name="message">The message.</param>
                private static void Fatal(string message)
                {
                        if (Logger != null && Logger.IsFatalEnabled)
                        {
                                Logger.Fatal(Formater, DateTime.Now.ToChineseLongMillisecondString(), "故障", message);
                        }
                }

                /// <summary>
                ///         Fatals the specified message.
                /// </summary>
                /// <param name="exception">The exception.</param>
                public static void Fatal(Exception exception)
                {
                        if (Logger != null && Logger.IsFatalEnabled)
                        {
                                Logger.Fatal(exception.ToString);
                        }
                }

                public static void Fatal(this IIdentityObject identityObject, Exception exception)
                {
                        Fatal(exception);
                }
        }
}