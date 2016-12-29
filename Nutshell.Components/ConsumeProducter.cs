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

namespace Nutshell.Components
{
        /// <summary>
        ///         消费-生产者
        /// </summary>
        public abstract class ConsumeProducter<TC, TP> : Dispatcher, IConsumeProducter<TC, TP> where TC : class
                where TP : class
        {
                protected ConsumeProducter(IdentityObject parent, string id)
                        : base(parent, id)
                {
                }

                /// <summary>
                ///         获得产品
                /// </summary>
                /// <param name="c">产品</param>
                protected void Acquire(TC c)
                {
                        OnAcquired(new ValueEventArgs<TC>(c));
                        TP p = Consume(c);
                        Dispatch(p);
                }


                protected abstract TP Consume(TC tc);

                private void Dispatch(TP p)
                {
                        OnDispatched(new ValueEventArgs<TP>(p));
                }

                #region 事件

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                public event EventHandler<ValueEventArgs<TC>> Acquired;

                /// <summary>
                ///         Raises the <see cref="E:Opened" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
                protected virtual void OnAcquired(ValueEventArgs<TC> e)
                {
                        //this.Info("获得:" + e.Value);
                        e.Raise(this, ref Acquired);
                }

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                public event EventHandler<ValueEventArgs<TP>> Dispatched;

                /// <summary>
                ///         Raises the <see cref="E:Opened" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
                protected virtual void OnDispatched(ValueEventArgs<TP> e)
                {
                        //this.Info("分配:" + e.Value);
                        e.Raise(this, ref Dispatched);
                }

                #endregion
        }
}