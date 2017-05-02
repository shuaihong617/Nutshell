// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-01-17
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-01-17
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Components;
using Nutshell.Extensions;
using Nutshell.Threading;
using System;
using System.Threading;

namespace Nutshell.Automation
{
        /// <summary>
        ///         摄像机图像消费者
        /// </summary>
        public abstract class Decoder<T> : Worker where T : IIdentifiable
        {
                /// <summary>
                ///         初始化<see cref="Decoder{T}" />的新实例.
                /// </summary>
                /// <param name="id">The key.</param>
                /// <param name="capturer">The camera.</param>
                protected Decoder(string id, CapturableDevice<T> capturer)
                        : base(id)
                {
                        capturer.NotNull();
                        Capturer = capturer;

                        DecodeLooper = new Looper("解码循环", ThreadPriority.Highest, 10, Decode);
                        DecodeLooper.Parent = this;
                }

                /// <summary>
                ///         摄像机
                /// </summary>
                public CapturableDevice<T> Capturer { get; }

                public Looper DecodeLooper { get; }

                /// <summary>
                ///         图像池
                /// </summary>
                public ReadWritePool<T> Pool { get; private set; }

                private T _decodeSource;

                /// <summary>
                ///         创建图像缓冲池
                /// </summary>
                protected abstract ReadWritePool<T> CreatePool();

                #region 处理流程

                protected override bool StartCore()
                {
                        if (Pool == null)
                        {
                                Pool = CreatePool();
                                Pool.Parent = this;
                        }

                        Capturer.CaptureSuccessed += Capturer_CaptureSuccessed;

                        return DecodeLooper.Start();
                }

                private void Capturer_CaptureSuccessed(object sender, ValueEventArgs<T> e)
                {
                        if (_decodeSource != null)
                        {
                                return;
                        }

                        _decodeSource = e.Value;

                        Capturer.Pool.ReadLock(_decodeSource);
                }

                protected override bool StopCore()
                {
                        DecodeLooper.Stop();
                        Capturer.CaptureSuccessed -= Capturer_CaptureSuccessed;
                        return true;
                }

                private void Decode()
                {
                        if (_decodeSource == null)
                        {
                                return ;
                        }

                        if (!IsEnable || WorkerState != WorkerState.已启动)
                        {
                                Capturer.Pool.ReadUnlock(_decodeSource);
                                _decodeSource = default(T);
                                return;
                        }

                        if (Capturer.Pool.GetLock(_decodeSource) < 1)
                        {
                                return;
                        }

                        var target = Pool.WriteLock();

                        DecodeCore(_decodeSource, target);

                        target.TimeStamps["CaptureTime"] = _decodeSource.TimeStamps["CaptureTime"];
                        target.TimeStamps["DecodeTime"] = DateTime.Now;

                        Pool.WriteUnlock(target);

                        Capturer.Pool.ReadUnlock(_decodeSource);

                        OnDecodeFinished(new ValueEventArgs<T>(target));

                        _decodeSource = default(T);

                }

                protected abstract void DecodeCore(T source, T target);

                #endregion 处理流程

                #region 事件

                public event EventHandler<ValueEventArgs<T>> DecodeFinished;

                /// <summary>
                ///         引发 <see cref="E:Opened" /> 事件.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
                protected virtual void OnDecodeFinished(ValueEventArgs<T> e)
                {
                        e.Raise(this, ref DecodeFinished);
                }

                #endregion 事件
        }
}