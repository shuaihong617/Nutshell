// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-07-17
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-07-17
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************
using Nutshell.Extensions;
using System;

namespace Nutshell.Collections
{
        /// <summary>
        /// Class Buffer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract class Buffer<T> : IdentityObject, IBuffer<T>
        {
                /// <summary>
                /// 初始化<see cref="IdentityObject" />的新实例.
                /// </summary>
                /// <param name="id">标识</param>
                protected Buffer(string id)
                        : base(id)
                {
                }

                public abstract int Length { get; }

                /// <summary>
                /// 将对象添加到缓冲区中。
                /// </summary>
                /// <param name="t">要添加的对象，该对象不可为null。</param>
                public abstract void Enqueue(T t);

                /// <summary>
                /// 从缓冲区中移除并返回对象。
                /// </summary>
                /// <returns>移除并返回的对象</returns>
                public abstract T Dequeue();

                /// <summary>
                /// 清空缓冲区。
                /// </summary>
                public abstract void Clear();

                #region 事件

                /// <summary>
                /// Occurs when [opened].
                /// </summary>
                protected event EventHandler<ValueEventArgs<T>> Enqueued;

                /// <summary>
                /// 引发 <see cref="E:Enqueued" /> 事件.
                /// </summary>
                /// <param name="e">The <see cref="ValueEventArgs{T}" /> Itance containing the event data.</param>
                protected virtual void OnEnqueued(ValueEventArgs<T> e)
                {
                        e.Raise(this, ref Enqueued);
                }

                /// <summary>
                /// Occurs when [opened].
                /// </summary>
                protected event EventHandler<ValueEventArgs<T>> Dequeued;

                /// <summary>
                /// 引发 <see cref="E:Dequeued" /> 事件.
                /// </summary>
                /// <param name="e">The <see cref="ValueEventArgs{T}" /> Itance containing the event data.</param>
                protected virtual void OnDequeued(ValueEventArgs<T> e)
                {
                        e.Raise(this, ref Dequeued);
                }

                /// <summary>
                /// Occurs when [opened].
                /// </summary>
                protected event EventHandler<EventArgs> Cleared;

                /// <summary>
                /// 引发<see cref="E:Opened" />事件
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
                protected virtual void OnCleared(EventArgs e)
                {
                        e.Raise(this, ref Cleared);
                }

                #endregion 事件
        }
}