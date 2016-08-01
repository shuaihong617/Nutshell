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

using System;
using System.Threading;
using System.Threading.Tasks;
using Nutshell.Components;
using Nutshell.Drawing.Imaging;
using Nutshell.Drawing.Shapes;
using Nutshell.Threading;

namespace Nutshell.Hardware.Vision
{
        /// <summary>
        ///         摄像机图像消费者
        /// </summary>
        public abstract class CameraDecoder : Worker
        {
                /// <summary>
                ///         初始化<see cref="CameraDecoder" />的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">The key.</param>
                /// <param name="camera">The camera.</param>
                /// <param name="pixelFormat">The pixel format.</param>
                protected CameraDecoder(IdentityObject parent, string id, Camera camera, PixelFormat pixelFormat)
                        : base(parent, id)
                {
                        camera.MustNotNull();
                        Camera = camera;

                        PixelFormat = pixelFormat;

                        //ProcessBitmap = new Bitmap(this, "处理图像", camera.Region.Width, camera.Region.Height, pixelFormat);

                        _thread = new Thread(ThreadWork) {Priority = ThreadPriority.Normal};
                }

                /// <summary>
                ///         摄像机
                /// </summary>
                public Camera Camera { get; private set; }

                /// <summary>
                ///         格式
                /// </summary>
                public PixelFormat PixelFormat { get; private set; }

                /// <summary>
                ///         图像池
                /// </summary>
                public ReaderWriterQueueBuffer<ReaderWriterObject<Bitmap>> Buffer { get; private set; }

                /// <summary>
                ///         处理任务
                /// </summary>
                private readonly Thread _thread;

                private bool _isThreadExit = false;

                /// <summary>
                /// 创建图像缓冲池
                /// </summary>
                public void CreateBitmapPool()
                {
                        var width = Camera.Region.Width;
                        var height = Camera.Region.Height;

                        if (width == 0 || height == 0)
                        {
                                throw new InvalidOperationException();
                        }

                        if (Buffer != null)
                        {
                                return;
                        }

                        Buffer = new ReaderWriterQueueBuffer<ReaderWriterObject<Bitmap>>(this, "图像缓冲池");
                        for (int i = 1; i < 8; i++)
                        {
                                var bitmap = new Bitmap(Buffer, i + "号缓冲位图", width, height, PixelFormat);
                                var readerWriterBitmap = new ReaderWriterObject<Bitmap>(Buffer, i + "号读写缓冲位图", bitmap);
                                Buffer.Enqueue(readerWriterBitmap);
                        }
                }

                #region 处理流程

                protected override sealed bool StartCore()
                {
                        _isThreadExit = false;
                        _thread.Start();

                        return true;
                }

                protected override sealed bool StopCore()
                {
                        _isThreadExit = true;
                        return true;
                }

                private void ThreadWork()
                {
                        for (;;)
                        {
                                if (_isThreadExit)
                                {
                                        break;
                                }

                                if (!IsEnable || !IsStarted)
                                {
                                        return;
                                }

                                var source = Camera.Buffers.Dequeue();
                                if (source == null)
                                {
                                        throw new InvalidOperationException();
                                }

                                var target = Buffer.Dequeue();
                                if (target == null)
                                {
                                        throw new InvalidOperationException();
                                }

                                source.Value.TranslateTo(target.Value);

                                Thread.Sleep(20);
                        }
                }

                #endregion
        }
}