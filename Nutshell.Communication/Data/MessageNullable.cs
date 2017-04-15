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
        public class NullableMessager<T> : ObservableNullable<T> where T : struct
        {
                /// <summary>
                ///         初始化<see cref="NullableMessager{T}" />的新实例.
                /// </summary>
                public NullableMessager()
                {
                }

                /// <summary>
                ///         初始化<see cref="NullableMessager{T}" />的新实例.
                /// </summary>
                /// <param name="data">The value.</param>
                public NullableMessager(T data)
                        : base(data)
                {
                }

                /// <summary>
                ///         获取状态发送器，状态接收器负责将新状态发送到控制设备
                /// </summary>
                /// <value>状态发送器</value>
                [MustNotEqualNull]
                public ISender<IValueMessageModel<T>> DataSender { get; private set; }

                /// <summary>
                ///         获取状态接收器，状态接收器负责从执行接收状态
                /// </summary>
                /// <value>状态接收器</value>
                [MustNotEqualNull]
                public IReceiver<IValueMessageModel<T>> DataReceiver { get; private set; }

                public NullableMessager<T> SetDataSender([MustNotEqualNull] ISender<IValueMessageModel<T>> sender)
                {
                        Trace.Assert(DataSender == null);

                        DataSender = sender;

                        return this;
                }

                public NullableMessager<T> SetDataReceiver([MustNotEqualNull] IReceiver<IValueMessageModel<T>> receiver)
                {
                        Trace.Assert(DataReceiver == null);

                        DataReceiver = receiver;
                        receiver.ReceiveSuccessed += (obj, args) =>
                        {
                                SetData(args.Value.Value);
                                if (DataSender == null)
                                {
                                        return;
                                }

                                DataSender.Send(null);
                        };
                        return this;
                }

                #region 事件

                #endregion 事件
        }
}