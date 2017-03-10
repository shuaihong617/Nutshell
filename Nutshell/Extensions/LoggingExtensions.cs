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
using Nutshell.Logging;
using System.Runtime.CompilerServices;
using Nutshell.Aspects.Locations.Contracts;

namespace Nutshell.Extensions
{
        /// <summary>
        ///         Class NLogDebuger.
        /// </summary>
        public static class LoggingExtensions
        {
                public static void Debug(this IIdentifiable identifiable, string message)
                {
                        LogProvider.Instance.Debug(identifiable.GlobalId + message);
                }

                
                public static void Info(this IIdentifiable identifiable, [MustNotEqualNullOrEmpty]string message)
                {
                        LogProvider.Instance.Info($"{ identifiable.GlobalId}:{message}");
                }

                public static void InfoEvent(this IIdentifiable identifiable, object eventName, object args = null)
                {
                        //if (args == null)
                        //{
                        //        Info(identifiable, "引发", eventName, "事件.");
                        //}
                        //else
                        //{
                        //        Info(identifiable, "引发", eventName, "事件.", args);
                        //}
                }

                public static void InfoSuccess(this IIdentifiable identifiable, [CallerMemberName]string operation = "")
                {
                        Info(identifiable, $"{operation}成功");
                }

                public static void InfoSuccessWithDescription(this IIdentifiable identifiable, string operation,
                        object description)
                {
                        Info(identifiable, $"{operation}成功,{description}");
                }

                

                public static void Warn(this IIdentifiable identifiable, string message)
                {
                        LogProvider.Instance.Warn($"{ identifiable.GlobalId}:{message}");
                }

                public static void WarnFail(this IIdentifiable identifiable, [CallerMemberName]string operation = "")
                {
                        Warn(identifiable, $"{operation}失败.");
                }


                /// <summary>
                ///         Warns the specified key.
                /// </summary>
                /// <param name="identifiable">The identity object.</param>
                /// <param name="operation">The operation.</param>
                /// <param name="reason">The reason.</param>
                public static void WarnFailWithReason(this IIdentifiable identifiable,object reason = null,[CallerMemberName]string operation="")
                {
                        Warn(identifiable, $"{operation}失败, 错误原因:{reason}");
                }

                public static void Error(this IIdentifiable identifiable, string message)
                {
                        LogProvider.Instance.Error(identifiable.GlobalId + message);
                }

                public static void ErrorFail(this IIdentifiable identifiable, [CallerMemberName]string operation = "")
                {
                        Error(identifiable, $"{operation}失败.");
                }

                public static void ErrorFailWithReason(this IIdentifiable identifiable, object reason = null,[CallerMemberName]string operation = "")
                {
                        Error(identifiable, $"{operation}失败, 错误原因:{reason}");
                }

                public static void Fatal(this IIdentifiable identifiable, Exception exception)
                {
                        LogProvider.Instance.Fatal(exception);
                }
        }
}