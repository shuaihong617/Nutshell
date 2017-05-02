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

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Components;
using Nutshell.Drawing.Imaging;
using System;
using System.Threading.Tasks;

namespace Nutshell.Automation.Vision
{
        /// <summary>
        ///         摄像机图像处理器
        /// </summary>
        public abstract class CameraDecoderConsumer : Worker
        {
                /// <summary>
                /// 初始化<see cref="CameraDecoderConsumer" />的新实例.
                /// </summary>
                /// <param name="id">The key.</param>
                /// <param name="decoder">The decoder.</param>
                protected CameraDecoderConsumer(string id, [MustNotEqualNull]CameraDecoder decoder)
                        : base(id)
                {
                        Decoder = decoder;

                        ProcessImage = new Bitmap(String.Empty, Decoder.Region.Width, Decoder.Region.Height, Decoder.PixelFormat);
                }

                /// <summary>
                ///         摄像机
                /// </summary>
                public CameraDecoder Decoder { get; private set; }

                /// <summary>
                ///         待处理图像
                /// </summary>
                public Bitmap ProcessImage { get; private set; }

                #region 处理流程

                protected sealed override bool StartCore()
                {
                        Decoder.DecodeFinished += Camera_CaptureSuccessed;
                        return true;
                }

                protected sealed override bool StopCore()
                {
                        Decoder.DecodeFinished -= Camera_CaptureSuccessed;

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
                /// <param name="sender">The source of the事件</param>
                /// <param name="e">The e.</param>
                private void Camera_CaptureSuccessed(object sender, ValueEventArgs<Bitmap> e)
                {
                        if (_processTask != null && !_processTask.IsCompleted)
                        {
                                return;
                        }

                        var bitmap = e.Value;

                        if (Decoder.RunMode == RunMode.Release)
                        {
                                Decoder.Pool.ReadLock(bitmap);
                        }

                        bitmap.CopyTo(ProcessImage);

                        if (Decoder.RunMode == RunMode.Release)
                        {
                                Decoder.Pool.ReadUnlock(bitmap);
                        }

                        _processTask = Task.Run(() => Process());
                }

                /// <summary>
                ///         处理接收的图像数据
                /// </summary>
                protected void Process()
                {
                        if (!IsEnable || WorkerState != WorkerState.已启动)
                        {
                                return;
                        }

                        ProcessCore();
                }

                protected abstract void ProcessCore();

                #endregion 处理流程
        }
}