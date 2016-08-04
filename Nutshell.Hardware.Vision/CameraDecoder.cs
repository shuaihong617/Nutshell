﻿// ***********************************************************************
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

using System;
using System.Threading;
using Nutshell.Components;
using Nutshell.Drawing.Imaging;
using Nutshell.Threading;

namespace Nutshell.Hardware.Vision
{
        /// <summary>
        ///         摄像机图像消费者
        /// </summary>
        public class CameraDecoder : Worker
        {
                /// <summary>
                ///         初始化<see cref="CameraDecoder" />的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">The key.</param>
                /// <param name="camera">The camera.</param>
                /// <param name="pixelFormat">The pixel format.</param>
                public CameraDecoder(IdentityObject parent, string id, Camera camera, NSPixelFormat pixelFormat)
                        : base(parent, id)
                {
                        camera.MustNotNull();
                        Camera = camera;

                        PixelFormat = pixelFormat;

                        _asyncer = new Asyncer(this, string.Empty, ThreadPriority.Highest, Decode);
                }

                /// <summary>
                ///         摄像机
                /// </summary>
                public Camera Camera { get; private set; }

                /// <summary>
                ///         格式
                /// </summary>
                public NSPixelFormat PixelFormat { get; private set; }

                /// <summary>
                ///         图像池
                /// </summary>
                public ReadWritePool<NSBitmap> Buffers { get; private set; }

                private readonly Asyncer _asyncer;

                private NSBitmap _source;

                /// <summary>
                ///         创建图像缓冲池
                /// </summary>
                private void CreateBitmapPool()
                {
                        int width = Camera.Region.Width;
                        int height = Camera.Region.Height;

                        if (width == 0 || height == 0)
                        {
                                throw new InvalidOperationException();
                        }

                        if (Buffers != null)
                        {
                                return;
                        }

                        Buffers = new ReadWritePool<NSBitmap>(this, "图像缓冲池");
                        for (int i = 1; i < 5; i++)
                        {
                                var bitmap = new NSBitmap(Buffers, i + "号缓冲位图", width, height, PixelFormat);
                                Buffers.Add(bitmap);
                        }
                }

                #region 处理流程

                protected override sealed bool StartCore()
                {
                        CreateBitmapPool();

                        Camera.CaptureSuccessed += Camera_CaptureSuccessed;                        
                        return true;
                }

                private void Camera_CaptureSuccessed(object sender, ValueEventArgs<NSBitmap> e)
                {
                        if (_asyncer.IsBusy)
                        {
                                return;
                        }

                        _source = e.Data;
                        _asyncer.Start();
                }

                protected override sealed bool StopCore()
                {
                        Camera.CaptureSuccessed -= Camera_CaptureSuccessed;
                        return true;
                }

                private void Decode()
                {
                        if (!IsEnable || !IsStarted)
                        {
                                return;
                        }

                        if (_source == null)
                        {
                                throw new InvalidOperationException();
                        }


                        Camera.Buffers.ReadLock(_source);


                        NSBitmap target = Buffers.WriteLock();
                        if (target == null)
                        {
                                throw new InvalidOperationException();
                        }

                        _source.TranslateTo(target);

                        Buffers.WriteUnlock(target);

                        Camera.Buffers.ReadUnlock(_source);

                        OnDecodeFinished(new ValueEventArgs<NSBitmap>(target));
                }

                #endregion

                #region 事件

                public event EventHandler<ValueEventArgs<NSBitmap>> DecodeFinished;

                /// <summary>
                ///         引发 <see cref="E:Opened" /> 事件.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnDecodeFinished(ValueEventArgs<NSBitmap> e)
                {
                        e.Raise(this, ref DecodeFinished);
                }

                #endregion
        }
}
