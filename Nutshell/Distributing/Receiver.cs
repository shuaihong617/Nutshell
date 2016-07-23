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
using Nutshell.Components.Models;
using Nutshell.Data.Models;
using Nutshell.Distributing.Models;

namespace Nutshell.Distributing
{
        /// <summary>
        ///         总线消息发送者
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract class Receiver<T> : DirectProducer<T>, ISender where T : class
        {
                /// <summary>
                ///         初始化<see cref="Receiver{T}" />的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">标识</param>
                protected Receiver(IdentityObject parent, string id = "接收器")
                        : base(parent, id)
                {
                        ReceiveLooper = new Looper(this, "接收循环", Enqueue);
                }

                /// <summary>
                ///         是否为订阅模式
                /// </summary>
                /// <remarks>
                ///         处于订阅模式时, 连接远程端口接收消息
                ///         处于非订阅模式时, 绑定本地端口接收信息
                ///         默认为非订阅模式
                /// </remarks>
                public bool IsSubscribeMode { get; private set; }

                public Looper ReceiveLooper { get; private set; }

                public override void Load(IStorableModel model)
                {
                        Trace.Assert(model is ReceiverModel);


                        base.Load(model);

                        var receiverModel = (ReceiverModel) model;

                        IsSubscribeMode = receiverModel.IsSubscribeMode;

                        LooperModel receiveLooperModel = receiverModel.ReceiveLooperModel;
                        Trace.Assert(receiveLooperModel != null);

                        ReceiveLooper.Load(receiveLooperModel);
                }

                protected override bool StartCore()
                {
                        return ReceiveLooper.Start();
                }

                protected override bool StopCore()
                {
                        return ReceiveLooper.Stop();
                }

                private void Enqueue()
                {
                        T t = Receive();

                        Product(t);
                }

                protected abstract T Receive();

                #region 事件

                #endregion
        }
}
