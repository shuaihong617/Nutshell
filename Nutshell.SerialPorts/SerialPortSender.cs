// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-12-17
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-12-23
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Communication;
using Nutshell.Extensions;
using Nutshell.Serializing.Xml;
using Nutshell.SerialPorts.Messaging.Models;
using Nutshell.SerialPorts.Models;
using Nutshell.Storaging;
using Nutshell.Storaging.Xml;

namespace Nutshell.SerialPorts
{
        /// <summary>
        ///         SerialPort发送者
        /// </summary>
        public class SerialPortSender<T> : SerialPortActor<T>, ISender<T>
                where T : SerialPortMessage
        {
                /// <summary>
                ///         初始化<see cref="SerialPortSender{T}" />的新实例.
                /// </summary>
                /// <param name="id">The identifier.</param>
                public SerialPortSender(string id = "")
                        : base(id)
                {
                }

                
                /// <summary>
                ///         发送字节数组数据
                /// </summary>
                /// <param name="message">待发送消息数据</param>
                public void Send(T message)
                {
                        var data = Serializer.Serialize(message);

                        Debug.WriteLine(
                                $"{DateTime.Now.ToChineseLongMillisecondString()}  {message.Id}  {message}");

                        SerialPort.Write(data, 0, data.Length);
                }

                /// <summary>
                ///         Occurs when [send successed].
                /// </summary>
                public event EventHandler<ValueEventArgs<T>> SendSuccessed;
        }
}
