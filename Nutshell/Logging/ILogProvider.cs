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

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Components;

namespace Nutshell.Logging
{
        /// <summary>
        ///         日志服务提供者接口
        /// </summary>
        public interface ILogProvider : IProducer<LogRecord>
        {
                /// <summary>
                ///         Debugs the specified message.
                /// </summary>
                /// <param name="message">The message.</param>
                void Debug([MustNotEqualNull] object message);

                /// <summary>
                ///         Fatals the specified message.
                /// </summary>
                /// <param name="message">The message.</param>
                void Info([MustNotEqualNull]object message);

                /// <summary>
                ///         Fatals the specified message.
                /// </summary>
                /// <param name="message">The message.</param>
                void Warn([MustNotEqualNull]object message);

                /// <summary>
                ///         Fatals the specified message.
                /// </summary>
                /// <param name="message">The message.</param>
                void Error([MustNotEqualNull]object message);

                /// <summary>
                ///         Fatals the specified message.
                /// </summary>
                /// <param name="message">The message.</param>
                void Fatal([MustNotEqualNull]object message);
        }
}