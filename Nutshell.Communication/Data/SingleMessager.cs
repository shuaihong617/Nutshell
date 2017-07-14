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
        public class SingleMessager<T> : ObservableNullableValue<T> where T : struct
        {
                /// <summary>
                ///         初始化<see cref="Messager{T}" />的新实例.
                /// </summary>
                public SingleMessager()
                {
                }

                /// <summary>
                ///         初始化<see cref="Messager{T}" />的新实例.
                /// </summary>
                /// <param name="data">The value.</param>
                public SingleMessager(T data)
                        : base(data)
                {
                }

                #region 字段

                /// <summary>
                ///         获取状态发送器，状态接收器负责将新状态发送到控制设备
                /// </summary>
                [MustNotEqualNull] private ISender<ValueMessage<T>> _targetSender;

                /// <summary>
                ///         获取状态接收器，状态接收器负责从执行接收状态
                /// </summary>
                [MustNotEqualNull] private IReceiver<ValueMessage<T>> _sourceReceiver;

                #endregion


                

                public SingleMessager<T> SetToUpperSender([MustNotEqualNull] ISender<ValueMessage<T>> sender)
                {
                        Trace.Assert(_targetSender == null);

                        _targetSender = sender;

                        return this;
                }

                public SingleMessager<T> SetFromLowerReceiver([MustNotEqualNull] IReceiver<ValueMessage<T>> receiver)
                {
                        Trace.Assert(_sourceReceiver == null);

                        _sourceReceiver = receiver;
                        receiver.Received += (obj, args) =>
                        {
                                SetData(args.Value.Value);
                                if (_targetSender == null)
                                {
                                        return;
                                }

                                _targetSender.Send(null);
                        };
                        return this;
                }

                #region 事件

                #endregion 事件
        }
}