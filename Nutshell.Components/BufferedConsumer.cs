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

using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Collections;
using Nutshell.Components.Models;
using Nutshell.Data.Models;

namespace Nutshell.Components
{
        /// <summary>
        ///         带有缓存的消费者
        /// </summary>
        public abstract class BufferedConsumer<T> : Consumer<T> where T : class
        {
                protected BufferedConsumer(IdentityObject parent, string id)
                        : base(parent, id)
                {
                        Looper = new Looper(this, Id + "消费循环", Dequeue);
                }

                protected IBuffer<T> Buffer { get; set; }

                private Looper Looper { get; set; }

                public override void Load([AssignableFrom(typeof(IBufferedModel))]IDataModel model)
                {
                        base.Load(model);

                        var bufferedModel = (IBufferedModel) model;
                        //LooperModel looperModel = bufferedModel.DequeueLooperModel;

                        //Trace.Assert(looperModel != null);
                        //Looper.Load(looperModel);
                }

                protected override bool StartCore()
                {
                        return Looper.Start();
                }

                protected override bool StopCore()
                {
                        return Looper.Stop();
                }

                public override void Acquire(T t)
                {
                        base.Acquire(t);
                        Buffer.Enqueue(t);
                }

                private void Dequeue()
                {
                        T t = Buffer.Dequeue();
                        if (t == null)
                        {
                                return;
                        }

                        Consume(t);
                }
        }
}