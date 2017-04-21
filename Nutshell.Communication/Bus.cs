﻿// ***********************************************************************
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
using Nutshell.Communication.Models;
using Nutshell.Components;
using Nutshell.Extensions;
using Nutshell.Messaging.Models;
using Nutshell.Serializing;
using Nutshell.Storaging;

namespace Nutshell.Communication
{
        /// <summary>
        ///         总线
        /// </summary>
        public abstract class Bus : Worker, IStorable<XmlBusModel>
        {
                protected Bus(string id = "")
                        : base(id)
                {
                }

                private readonly Dictionary<string, object> _serializers = new Dictionary<string, object>();

                //private ISite _site;

                public void Load(XmlBusModel model)
                {
                        throw new NotImplementedException();
                }

                public void Save(XmlBusModel model)
                {
                        throw new NotImplementedException();
                }

                /// <summary>
                ///         注册消息类型所用的序列化器
                /// </summary>
                /// <typeparam name="T">消息泛型</typeparam>
                /// <param name="category">消息类型</param>
                /// <param name="serializer">序列化器</param>
                public void RegisterSerializer<T>(string category, ISerializer<T> serializer) where T : IMessageModel
                {
                        _serializers[category] = serializer;
                }

                /// <summary>
                ///         发送消息
                /// </summary>
                /// <param name="messageModel">待发送的消息</param>
                public void Send(IMessageModel messageModel)
                {
                        dynamic serializer = _serializers[messageModel.Category];
                        var btyes = serializer.Serialize(messageModel);
                        //_site.Send(btyes);
                }

                #region 事件

                /// <summary>
                ///         当消息接收成功时发生。
                /// </summary>
                [Description("消息接收成功事件")]
                [LogEventInvokeHandler]
                public event EventHandler<ValueEventArgs<IMessageModel>> ReceiveSuccessed;

                /// <summary>
                ///         当消息成功接收时发生
                /// </summary>
                /// <param name="e">包含消息的事件参数</param>
                protected virtual void OnReceiveSuccessed(ValueEventArgs<IMessageModel> e)
                {
                        e.Raise(this, ref ReceiveSuccessed);
                }

                #endregion
        }
}
