// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-07-09
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-07-09
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Collections.Generic;

namespace Nutshell.Threading
{
        /// <summary>
        ///         缓冲池
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class ReaderWriterQueue<T> : IdentityObject where T : IdentityObject, IReaderWriterObject
        {
                /// <summary>
                ///         初始化<see cref="IdentityObject" />的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">标识</param>
                public ReaderWriterQueue(IdentityObject parent, string id)
                        : base(parent, id)
                {
                }

                /// <summary>
                ///         The _usage
                /// </summary>
                private readonly Queue<T> _queue = new Queue<T>();

                /// <summary>
                ///         添加缓冲对象到缓冲池
                /// </summary>
                /// <param name="t">缓冲对象</param>
                public void Enqueue(T t)
                {
                        _queue.Enqueue(t);
                }

                public T Dequeue()
                {
                       return _queue.Dequeue();
                }
        }
}
