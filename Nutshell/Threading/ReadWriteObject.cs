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
        ///         读写锁对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class ReadWriteObject<T> : IdentityObject,IReadWriteObject where T : IdentityObject
        {
                /// <summary>
                /// 初始化<see cref="IdentityObject" />的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">标识</param>
                /// <param name="t">需要锁定的对象</param>
                public ReadWriteObject(string id, T t)
                        : base( id)
                {
                        Value = t;
                }

                private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

                public T Value { get; private set; }


                /// <summary>
                /// 锁定
                /// </summary>
                /// <returns>锁定操作是否成功</returns>
                public bool Lock()
                {
                        return _lock.TryEnterWriteLock(0);
                }

                /// <summary>
                /// 解锁
                /// </summary>
                public void Unlock()
                {
                        _lock.ExitWriteLock();
                }

                public bool ReadLock()
                {
                        return _lock.TryEnterReadLock(0);
                }

                public void ReadUnlock()
                {
                        _lock.ExitReadLock();
                }

                public bool WriteLock()
                {
                        return _lock.TryEnterWriteLock(0);
                }

                public void WriteUnlock()
                {
                        _lock.ExitWriteLock();
                }
        }
}
