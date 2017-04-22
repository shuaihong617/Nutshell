// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-05-19
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-05-20
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data;
using Nutshell.Messaging.Models;

namespace Nutshell.Communication.Data
{
        /// <summary>
        ///         跟踪可空值更新前后变化的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Messager<T> : ObservableNullable<T> where T : struct
        {
                /// <summary>
                ///         初始化<see cref="Messager{T}" />的新实例.
                /// </summary>
                public Messager()
                {
                }

                /// <summary>
                ///         初始化<see cref="Messager{T}" />的新实例.
                /// </summary>
                /// <param name="data">The value.</param>
                public Messager(T data)
                        : base(data)
                {
                }

                /// <summary>
                ///         获取状态发送器，状态接收器负责将新状态发送到控制设备
                /// </summary>
                /// <value>状态发送器</value>
                [MustNotEqualNull]
                public ISender<ValueMessageModel<T>> ToUpperSender { get; private set; }

                /// <summary>
                ///         获取状态接收器，状态接收器负责从执行接收状态
                /// </summary>
                /// <value>状态接收器</value>
                [MustNotEqualNull]
                public IReceiver<ValueMessageModel<T>> FromLowerReceiver { get; private set; }

                /// <summary>
		/// 获取命令发送器，命令发送器负责将控制命令发送到可以执行的设备
		/// </summary>
		/// <value>命令发送器</value>
		[MustNotEqualNull]
                public ISender<ValueMessageModel<T>> ToLowerSender { get; private set; }

                /// <summary>
                /// 获取命令接收器，命令接收器负责从控制设备接收控制命令
                /// </summary>
                /// <value>命令接收器</value>
                [MustNotEqualNull]
                public IReceiver<ValueMessageModel<T>> FromUpperReceiver { get; private set; }

                public Messager<T> SetToUpperSender([MustNotEqualNull] ISender<ValueMessageModel<T>> sender)
                {
                        Trace.Assert(ToUpperSender == null);

                        ToUpperSender = sender;

                        return this;
                }

                public Messager<T> SetFromLowerReceiver([MustNotEqualNull] IReceiver<ValueMessageModel<T>> receiver)
                {
                        Trace.Assert(FromLowerReceiver == null);

                        FromLowerReceiver = receiver;
                        receiver.ReceiveSuccessed += (obj, args) =>
                        {
                                SetData(args.Value.Value);
                                if (ToUpperSender == null)
                                {
                                        return;
                                }

                                ToUpperSender.Send(null);
                        };
                        return this;
                }

                public Messager<T> SetToLowerSender([MustNotEqualNull] ISender<ValueMessageModel<T>> sender)
                {
                        Trace.Assert(ToLowerSender == null);

                        ToLowerSender = sender;

                        return this;
                }

                public Messager<T> SetFromUpperReceiver([MustNotEqualNull] IReceiver<ValueMessageModel<T>> receiver)
                {
                        Trace.Assert(FromUpperReceiver == null);

                        FromUpperReceiver = receiver;
                        receiver.ReceiveSuccessed += (obj, args) =>
                        {
                                SetData(args.Value.Value);
                                if (ToUpperSender == null)
                                {
                                        return;
                                }

                                ToUpperSender.Send(null);
                        };
                        return this;
                }


                #region 事件

                #endregion 事件
        }
}