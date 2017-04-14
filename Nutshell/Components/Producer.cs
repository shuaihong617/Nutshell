// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-08-29
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-08-29
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Extensions;
using System;
using System.Collections.Generic;

namespace Nutshell.Components
{
        /// <summary>
        ///         生产者
        /// </summary>
        public abstract class Producer<T> : IProducer<T> where T : class
        {
                private readonly List<IConsumer<T>> _consumers = new List<IConsumer<T>>();

                public bool Register(IConsumer<T> consumer)
                {
                        _consumers.Add(consumer);
                        return true;
                }

                public bool Unregister(IConsumer<T> consumer)
                {
                        _consumers.Remove(consumer);
                        return true;
                }

                protected virtual void Product(T t)
                {
                        OnProducted(new ValueEventArgs<T>(t));
                }

                protected void Dispatch(T t)
                {
                        foreach (var consumer in _consumers)
                        {
                                consumer.Acquire(t);
                        }
                        OnDispatched(new ValueEventArgs<T>(t));
                }

                #region 事件

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                protected event EventHandler<ValueEventArgs<T>> Producted;

                /// <summary>
                ///         引发<see cref="E:Opened" />事件
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnProducted(ValueEventArgs<T> e)
                {
                        e.Raise(this, ref Producted);
                }

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                public event EventHandler<ValueEventArgs<T>> Dispatched;

                /// <summary>
                ///         引发<see cref="E:Opened" />事件
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnDispatched(ValueEventArgs<T> e)
                {
                        e.Raise(this, ref Dispatched);
                }

                #endregion 事件
        }
}