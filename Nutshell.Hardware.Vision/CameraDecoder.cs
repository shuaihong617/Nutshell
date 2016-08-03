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
using System.Diagnostics;
using System.Threading;
using Nutshell.Collections;
using Nutshell.Components;
using Nutshell.Drawing.Imaging;

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
                public CameraDecoder(IdentityObject parent, string id, Camera camera, PixelFormat pixelFormat)
                        : base(parent, id)
                {
                        camera.MustNotNull();
                        Camera = camera;

                        PixelFormat = pixelFormat;

                        _thread = new Thread(ThreadWork) {Priority = ThreadPriority.Highest};
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
                public QueueBuffer<Bitmap> Buffers { get; private set; }

                public DateTime LastDecodeBitmapTimeStamp { get; private set; }

                /// <summary>
                ///         处理任务
                /// </summary>
                private readonly Thread _thread;

                private bool _isThreadExit;

                private Stopwatch _stopwatch = new Stopwatch();

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

                        Buffers = new QueueBuffer<Bitmap>(this, "图像缓冲池");
                        for (int i = 1; i < 8; i++)
                        {
                                var bitmap = new Bitmap(Buffers, i + "号缓冲位图", width, height, PixelFormat);
                                Buffers.Enqueue(bitmap);
                        }
                }

                #region 处理流程

                protected override sealed bool StartCore()
                {
                        CreateBitmapPool();

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
                        Bitmap source;
                        int count = 0;
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

                                if (Camera.Buffers == null)
                                {
                                        return;
                                }

                                _stopwatch.Restart();

                                count = 0;

                                for (;;)
                                {
                                       

                                        var bitmap = Camera.Buffers.Dequeue();
                                        if (bitmap == null)
                                        {
                                                throw new InvalidOperationException();
                                        }

                                        count++;
                                        //Trace.WriteLine(DateTime.Now.ToChineseLongMillisecondString() + " : " + Id + "     摄像机缓冲区出队  " + bitmap);

                                        if (bitmap.TimeStamp < LastDecodeBitmapTimeStamp)
                                        {
                                                
                                               Camera.Buffers.Enqueue(bitmap);
                                               //Trace.WriteLine(DateTime.Now.ToChineseLongMillisecondString() + " : " + Id + "     摄像机  旧数据入队  " + bitmap);
                                               continue;
                                        }

                                        

                                        source = bitmap;
                                        break;
                                }

                                Bitmap target = Buffers.Dequeue();
                                if (target == null)
                                {
                                        throw new InvalidOperationException();
                                }
                                //Trace.WriteLine(DateTime.Now.ToChineseLongMillisecondString() + " : " + Id + "     解码  出队  " + target);

                                source.TranslateTo(target);
                                target.UpdateTimeStamp();
                                LastDecodeBitmapTimeStamp = source.TimeStamp;

                                Camera.Buffers.Enqueue(source);
                                //Trace.WriteLine(DateTime.Now.ToChineseLongMillisecondString() + " : " + Id + "     摄像机  入队  " + source);

                                Buffers.Enqueue(target);
                                //Trace.WriteLine(DateTime.Now.ToChineseLongMillisecondString() + " : " + Id + "     解码  入队  " + target);

                                _stopwatch.Stop();

                                Trace.WriteLine(DateTime.Now.ToChineseLongMillisecondString() + "   解码: " + count + "  " +
                                                _stopwatch.ElapsedMilliseconds);

                                Thread.Sleep(5);
                        }
                }

                #endregion
        }
}