// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-11-23
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-11-27
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Diagnostics;
using Nutshell.Components;
using Nutshell.Data;
using Nutshell.Data.Models;
using Nutshell.Distributing.Models;

namespace Nutshell.Distributing
{
        /// <summary>
        ///         总线消息发送者
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract class Sender<T> : DirectConsumer<T>,ISender where T :class
        {
                /// <summary>
                ///         初始化<see cref="Sender{T}" />的新实例.
                /// </summary>
                /// <param name="id">The identifier.</param>
                protected Sender(IdentityObject parent, string id = "发送器")
                        : base(parent, id)
                {
                }

                /// <summary>
                /// 是否为发布模式
                /// </summary>
                /// <remarks>
                /// 处于发布模式时, 绑定本地端口发送信息
                /// 处于非发布模式时, 连接远程端口发送消息
                /// 默认为非发布模式
                /// </remarks>
                public bool IsPublishMode { get;private set; }

                public override void Load(IStorableModel model)
                {
                        Trace.Assert(model is SenderModel);
                        

                        base.Load(model);

                        var senderModel = (SenderModel) model;

                        IsPublishMode = senderModel.IsPublishMode;
                }

                protected override void Consume(T t)
                {
                        Send(t);
                }

                protected abstract void Send(T t);
                
        }
}
