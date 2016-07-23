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
using System.Threading.Tasks;
using Nutshell.Components;
using Nutshell.Drawing.Imaging;

namespace Nutshell.Hardware.Vision
{
        /// <summary>
        ///         摄像机图像消费者
        /// </summary>
        public abstract class CameraConsumer : Worker
        {
                /// <summary>
                ///         初始化<see cref="CameraConsumer" />的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">The key.</param>
                /// <param name="camera">The camera.</param>
                /// <param name="pixelFormat">The pixel format.</param>
                protected CameraConsumer(IdentityObject parent, string id, Camera camera, PixelFormat pixelFormat)
                        : base(parent, id)
                {
                        camera.MustNotNull();
                        Camera = camera;

                        ProcessBitmap = new Bitmap(this, "处理图像", camera.Region.Width, camera.Region.Height, pixelFormat);
                }

                /// <summary>
                ///         摄像机
                /// </summary>
                public Camera Camera { get; private set; }

                /// <summary>
                ///         待处理图像
                /// </summary>
                public Bitmap ProcessBitmap { get; private set; }

                #region 处理流程

                protected override sealed bool StartCore()
                {
                        Camera.CaptureSuccessed += Camera_CaptureSuccessed;
                        return true;
                }

                protected override sealed bool StopCore()
                {
                        Camera.CaptureSuccessed -= Camera_CaptureSuccessed;

                        if (_processTask != null)
                        {
                                if (!_processTask.IsCompleted)
                                {
                                        _processTask.Wait();
                                }
                        }
                        return true;
                }

                /// <summary>
                ///         处理任务
                /// </summary>
                private Task _processTask;

                /// <summary>
                ///         处理摄像机图像采集完成事件
                /// </summary>
                /// <param name="sender">The source of the event.</param>
                /// <param name="e">The e.</param>
                private void Camera_CaptureSuccessed(object sender, ValueEventArgs<Bitmap> e)
                {
                        if (_processTask != null && !_processTask.IsCompleted)
                        {
                                return;
                        }

                        Bitmap bitmap = e.Data;

                        if (Camera.RunMode == RunMode.Release)
                        {
                                if (!Camera.BitmapPool.EnterRead(bitmap))
                                {
                                        return;
                                }
                        }

                        bitmap.TranslateTo(ProcessBitmap);

                        if (Camera.RunMode == RunMode.Release)
                        {
                                Camera.BitmapPool.ExitRead(bitmap);
                        }

                        _processTask = Task.Run(() => Process());
                }

                /// <summary>
                ///         处理接收的图像数据
                /// </summary>
                protected void Process()
                {
                        if (!IsEnable || !IsStarted)
                        {
                                return;
                        }

                        ProcessCore();
                }

                protected abstract void ProcessCore();

                #endregion
        }
}