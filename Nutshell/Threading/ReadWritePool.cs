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

using Nutshell.Aspects.Locations.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Nutshell.Threading
{
        /// <summary>
        ///         为对象添加读写锁的缓冲池
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class ReadWritePool<T> : IdentityObject where T : IIdentifiable
        {
                /// <summary>
                ///         初始化<see cref="IdentityObject" />的新实例.
                /// </summary>
                /// <param name="id">标识</param>
                public ReadWritePool(string id)
                        : base(id)
                {
                }

                /// <summary>
                ///         The _usage
                /// </summary>
                private readonly Dictionary<T, int> _buffers = new Dictionary<T, int>(7);

                private readonly object _lockObject = new object();

                /// <summary>
                ///         添加缓冲对象到缓冲池
                /// </summary>
                /// <param name="t">缓冲对象</param>
                public void Add([MustNotEqualNull]T t)
                {
                        lock (_lockObject)
                        {
                                t.Parent = this;
                                _buffers[t] = 0;
                        }
                }

                /// <summary>
                /// 获取当前对象锁的值
                /// </summary>
                /// <param name="t">当前对象锁的值</param>
                /// <returns>
                /// 0:未加锁
                /// -1:写锁
                /// >0:读锁
                /// </returns>
                public int GetLock([MustNotEqualNull]T t)
                {
                        lock (_lockObject)
                        {
                                return _buffers[t];
                        }
                }

                /// <summary>
                ///         Enters the read.
                /// </summary>
                /// <param name="t">The t.</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                public void ReadLock([MustNotEqualNull]T t)
                {
                        lock (_lockObject)
                        {
                                if (_buffers[t] < 0)
                                {
                                        throw new InvalidOperationException("当前值为" + _buffers[t]);
                                }
                                _buffers[t]++;
                        }
                }

                /// <summary>
                ///         Exits the read.
                /// </summary>
                /// <param name="t">The t.</param>
                public void ReadUnlock([MustNotEqualNull]T t)
                {
                        lock (_lockObject)
                        {
                                if (_buffers[t] < 1)
                                {
                                        throw new InvalidOperationException("当前值为" + _buffers[t]);
                                }
                                _buffers[t]--;
                        }
                }

                /// <summary>
                ///         Enters the write.
                /// </summary>
                /// <returns>T.</returns>
                public T WriteLock()
                {
                        lock (_lockObject)
                        {
                                //Trace.WriteLine(Id + "获取写锁");

                                foreach (var pair in _buffers)
                                {
                                        if (pair.Value == 0)
                                        {
                                                T t = pair.Key;
                                                _buffers[t] = -1;
                                                return t;
                                        }
                                }

                                throw new InvalidOperationException();
                        }
                }

                /// <summary>
                ///         Exits the write.
                /// </summary>
                /// <param name="t">The t.</param>
                public void WriteUnlock(T t)
                {
                        Contract.Requires(t != null);

                        lock (_lockObject)
                        {
                                //Trace.WriteLine(Id + "释放写锁");
                                if (_buffers[t] != -1)
                                {
                                        throw new InvalidOperationException("当前值为" + _buffers[t]);
                                }
                                _buffers[t] = 0;
                        }
                }
        }
}