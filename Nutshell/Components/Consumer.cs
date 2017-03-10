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

using System;
using Nutshell.Extensions;

namespace Nutshell.Components
{
        /// <summary>
        ///         消费者
        /// </summary>
        public abstract class Consumer<T> : IConsumer<T> where T : class
        {
                /// <summary>
                ///         获得产品
                /// </summary>
                /// <param name="t">产品</param>
                public virtual void Acquire(T t)
                {
                        OnAcquired(new ValueEventArgs<T>(t));
                }

                protected virtual void Consume(T t)
                {
                        OnConsumed(new ValueEventArgs<T>(t));
                }

                #region 事件

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                public event EventHandler<ValueEventArgs<T>> Acquired;

                /// <summary>
                ///         Raises the <see cref="E:Opened" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnAcquired(ValueEventArgs<T> e)
                {
                        e.Raise(this, ref Acquired);
                }

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                protected event EventHandler<ValueEventArgs<T>> Consumed;

                /// <summary>
                ///         Raises the <see cref="E:Opened" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnConsumed(ValueEventArgs<T> e)
                {
                        e.Raise(this, ref Consumed);
                }

                #endregion
        }
}