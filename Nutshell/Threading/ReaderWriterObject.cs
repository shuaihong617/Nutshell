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

using System.Threading;

namespace Nutshell.Threading
{
        /// <summary>
        ///         缓冲池
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class ReaderWriterObject<T> : IdentityObject,IReaderWriterObject where T : IdentityObject
        {
                /// <summary>
                ///         初始化<see cref="IdentityObject" />的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">标识</param>
                public ReaderWriterObject(IdentityObject parent, string id, T t)
                        : base(parent, id)
                {
                }

                private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

                public bool IsReadLockHeld
                {
                        get { return _lock.IsReadLockHeld; }
                }

                public T Value { get; private set; }


                /// <summary>
                ///         Enters the read.
                /// </summary>
                /// <param name="t">The t.</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                public bool EnterRead()
                {
                        return _lock.TryEnterReadLock(0);
                }

                /// <summary>
                ///         Exits the read.
                /// </summary>
                /// <param name="t">The t.</param>
                public void ExitRead()
                {
                        _lock.ExitReadLock();
                }

                /// <summary>
                ///         Enters the write.
                /// </summary>
                /// <returns>T.</returns>
                public bool EnterWrite()
                {
                        return _lock.TryEnterWriteLock(0);
                }

                /// <summary>
                ///         Exits the write.
                /// </summary>
                /// <param name="t">The t.</param>
                public void ExitWrite()
                {
                        _lock.ExitWriteLock();
                }
        }
}
