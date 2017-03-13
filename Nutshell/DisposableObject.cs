// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-08-31
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-08-31
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;

namespace Nutshell
{
        /// <summary>
        ///         实现资源释放模式接口
        /// </summary>
        public abstract class DisposableObject : NotifyPropertyChangedObject, IDisposable
        {
                #region 终结函数

                /// <summary>
                ///         此方法必须, 防止编码时忘记调用Dispose方法
                /// </summary>
                ~DisposableObject()
                {
                        //必须为false, 只释放非托管资源
                        Dispose(false);
                }

                #endregion 终结函数

                #region 字段

                /// <summary>
                ///         资源是否已释放
                /// </summary>
                private bool _isDisposed;

                #endregion 字段

                #region 方法

                /// <summary>
                ///         执行与释放或重置非托管资源相关的应用程序定义的任务.
                /// </summary>
                public void Dispose()
                {
                        //必须为true, 同时释放托管资源和非托管资源
                        Dispose(true);

                        //通知垃圾回收器不再调用终结器（~~DisposePatternTemplate方法）
                        GC.SuppressFinalize(this);
                }

                /// <summary>
                ///         完全释放指定对象
                /// </summary>
                /// <typeparam name="T">对象类型</typeparam>
                /// <param name="t">要释放的对象</param>
                public static void SafeDispose<T>(ref T t)
                        where T : class, IDisposable
                {
                        if (t != null)
                        {
                                t.Dispose();
                                t = null;
                        }
                }

                /// <summary>
                ///         释放资源.
                /// </summary>
                /// <param name="disposing">
                ///         <c>true</c> 同时释放托管和非托管资源; <c>false</c> 只释放非托管资源
                /// </param>
                /// <remarks>
                ///         重写此函数时必须调用基类函数以释放基类资源.
                /// </remarks>
                protected virtual void Dispose(bool disposing)
                {
                        //已释放直接返回
                        if (_isDisposed)
                        {
                                return;
                        }

                        if (disposing)
                        {
                                DisposeManagedResources();
                        }

                        DisposeUnmanagedResources();

                        //标记本实例中资源已释放
                        _isDisposed = true;
                }

                /// <summary>
                ///         释放托管资源
                /// </summary>
                protected virtual void DisposeManagedResources()
                {
                }

                /// <summary>
                ///         释放非托管资源
                /// </summary>
                protected virtual void DisposeUnmanagedResources()
                {
                }

                public void MustNotDisposed()
                {
                        if (_isDisposed)
                        {
                                throw new ObjectDisposedException("对象已释放");
                        }
                }

                #endregion 方法
        }
}