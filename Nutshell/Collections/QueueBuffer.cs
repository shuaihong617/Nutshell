// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-07-17
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-08-01
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Nutshell.Collections
{
        /// <summary>
        /// 队列缓冲区
        /// </summary>
        /// <typeparam name="T">缓冲数据类型</typeparam>
        public class QueueBuffer<T>:Buffer<T> where T:class 
        {

                /// <summary>
                /// 初始化<see cref="QueueBuffer{T}"/>的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">标识</param>
                public QueueBuffer(IdentityObject parent, string id = "")
                        :base(parent, id)
                {
                        
                }

                /// <summary>
                /// The _buffer
                /// </summary>
                private readonly ConcurrentQueue<T> _buffer = new ConcurrentQueue<T>();


                public override int Length
                {
                        get { return _buffer.Count; }
                }

                /// <summary>
                /// 将对象添加到缓冲区中。
                /// </summary>
                /// <param name="t">要添加的对象，该对象不可为null。</param>
                public override void Enqueue(T t)
                {
                        if (t == null)
                        {
                                throw new ArgumentException("要添加的对象不能为null");
                        }
                        _buffer.Enqueue(t);

                        //Trace.WriteLine(DateTime.Now.ToChineseLongMillisecondString() + " : " + GlobalId + "   入队  " + t);
                }


                /// <summary>
                /// Dequeues this instance.
                /// </summary>
                /// <returns>T.</returns>
                public override T Dequeue()
                {
                        T t;
                        if ( _buffer.TryDequeue(out t))
                        {
                                

                                return t;
                        }
                        return null;
                }

                /// <summary>
                /// 清空缓冲区。
                /// </summary>
                /// <exception cref="System.NotSupportedException"></exception>
                public override void Clear()
                {
                        throw new NotSupportedException();
                }

               
        }
}
