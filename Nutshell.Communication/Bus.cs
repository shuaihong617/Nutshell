// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-12-17
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-12-17
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Nutshell.Aspects.Events;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Communication.Models;
using Nutshell.Components;
using Nutshell.Extensions;
using Nutshell.Messaging;
using Nutshell.Messaging.Models;
using Nutshell.Serializing;
using Nutshell.Storaging;

namespace Nutshell.Communication
{
        /// <summary>
        ///         总线
        /// </summary>
        public abstract class Bus : Worker,IBus
        {
                protected Bus(string id = "")
                        : base(id)
                {
                }

                protected Dictionary<string, object> Receivers { get; private set; }  = new Dictionary<string, object>();


                public virtual Bus RegisterSender<T>(ISender<T> sender) where T : Message
                {
                        sender.Parent = this;
                        return this;
                }

                public virtual Bus RegisterReceiver<T>([MustNotEqualNull]IReceiver<T> receiver) where T : Message
                {
                        receiver.Parent = this;

                        var messageType = typeof (T).Name;
                        Receivers.Add(messageType, receiver);

                        return this;
                }


                #region 事件

                /// <summary>
                ///         当消息接收成功时发生。
                /// </summary>
                [Description("消息接收成功事件")]
                [LogEventInvokeHandler]
                public event EventHandler<ValueEventArgs<Message>> ReceiveSuccessed;

                /// <summary>
                ///         当消息成功接收时发生
                /// </summary>
                /// <param name="e">包含消息的事件参数</param>
                protected virtual void OnReceiveSuccessed(ValueEventArgs<Message> e)
                {
                        e.Raise(this, ref ReceiveSuccessed);
                }

                #endregion
        }
}
