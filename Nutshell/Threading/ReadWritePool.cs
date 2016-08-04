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
using System.Threading;

namespace Nutshell.Threading
{
        /// <summary>
        /// 为对象添加读写锁的缓冲池
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class ReadWritePool<T> : IdentityObject where T : IdentityObject
        {
                /// <summary>
                /// 初始化<see cref="IdentityObject" />的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">标识</param>
                public ReadWritePool(IdentityObject parent, string id)
                        : base(parent, id)
                {
                }

                /// <summary>
                /// The _usage
                /// </summary>
                private readonly Dictionary<T, ReaderWriterLockSlim> _buffers =
                        new Dictionary<T, ReaderWriterLockSlim>();

                /// <summary>
                /// 添加缓冲对象到缓冲池
                /// </summary>
                /// <param name="t">缓冲对象</param>
                public void Add(T t)
                {
                        _buffers[t] = new ReaderWriterLockSlim();
                }

                /// <summary>
                /// Enters the read.
                /// </summary>
                /// <param name="t">The t.</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                public bool ReadLock(T t)
                {
                        return _buffers[t].TryEnterReadLock(0);
                }

                /// <summary>
                /// Exits the read.
                /// </summary>
                /// <param name="t">The t.</param>
                public void ReadUnlock(T t)
                {
                        _buffers[t].ExitReadLock();
                }

                /// <summary>
                /// Enters the write.
                /// </summary>
                /// <returns>T.</returns>
                public T WriteLock()
                {
                        foreach (var pair in _buffers)
                        {
                                if (pair.Value.TryEnterWriteLock(0))
                                {
                                        return pair.Key;
                                }
                        }
                        return null;
                }

                /// <summary>
                /// Exits the write.
                /// </summary>
                /// <param name="t">The t.</param>
                public void WriteUnlock(T t)
                {
                        _buffers[t].ExitWriteLock();
                }
        }
}
