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
using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Collections;
using Nutshell.Components.Models;
using Nutshell.Data.Models;

namespace Nutshell.Components
{
        /// <summary>
        ///         同步缓存订阅者, 顺序缓存订阅结果后依次处理
        /// </summary>
        public abstract class BufferedProducer<T> : Producer<T> where T : class
        {
                protected BufferedProducer(IdentityObject parent, string id)
                        : base(parent, id)
                {
                        //DequeueLooper = new Looper(this, "出队工作循环", Dequeue);
                }

                protected IBuffer<T> Buffer { get; set; }

                private Looper DequeueLooper { get; set; }

                public override void Load([MustAssignableFrom(typeof(IBufferedModel))]IDataModel model)
                {
                        base.Load(model);

                        var bufferedModel = (IBufferedModel) model;
                        //LooperModel dequeueLooperModel = bufferedModel.DequeueLooperModel;
                        //Trace.Assert(dequeueLooperModel != null);

                        //DequeueLooper.Load(dequeueLooperModel);
                }

                protected override IResult Starup(IWorkContext context)
                {
			throw new NotImplementedException();
			//return DequeueLooper.Start();
		}

                protected override IResult Clean(IWorkContext context)
                {
			throw new NotImplementedException();
			//return DequeueLooper.Stop();
		}

		protected override void Product(T t)
                {
                        base.Product(t);
                        Buffer.Enqueue(t);
                }

                private void Dequeue()
                {
                        T t = Buffer.Dequeue();
                        if (t == null)
                        {
                                return;
                        }

                        Dispatch(t);
                }
        }
}