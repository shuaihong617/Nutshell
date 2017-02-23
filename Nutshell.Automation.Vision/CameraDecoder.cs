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
using Nutshell.Hardware.Vision;
using Nutshell.Threading;

namespace Nutshell.Automation.Vision
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
                public CameraDecoder(string id, Camera camera, PixelFormat pixelFormat)
                        : base( id)
                {
                        camera.NotNull();
                        Camera = camera;

                        PixelFormat = pixelFormat;

                        //_looper = new Looper(this, string.Empty, ThreadPriority.Highest,5, Decode);
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
                public NSReadWritePool<Bitmap> Buffers { get; private set; }

                private readonly Looper _looper;

                private Bitmap _decodeBitmap;

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

                        Buffers = new NSReadWritePool<Bitmap>("解码图像缓冲池");
                        for (int i = 1; i < 5; i++)
                        {
				throw new NotImplementedException();
				//
				//var bitmap = new Bitmap(Buffers, i + "号缓冲位图", width, height, PixelFormat, new NSDecodeTimeStamp<string>());
                                //Buffers.Add(bitmap);
                        }
                }

                #region 处理流程

                protected override sealed IResult Starup(IRunableObject runableObject)
                {
                        CreateBitmapPool();

                        Camera.CaptureSuccessed += Camera_CaptureSuccessed;
			throw new NotImplementedException();
			//_looper.Start();
                        //return true;
                }

                private void Camera_CaptureSuccessed(object sender, ValueEventArgs<Bitmap> e)
                {
                        if (_decodeBitmap != null)
                        {
                                return;
                        }

                        _decodeBitmap = e.Value;

                        Camera.Buffers.ReadLock(_decodeBitmap);
                }

                protected override sealed IResult Clean(IRunableObject runableObject)
                {
			throw new NotImplementedException();
			// _looper.Stop();
			//Camera.CaptureSuccessed -= Camera_CaptureSuccessed;
                        //return true;
                }

                private void Decode()
                {
                        if (_decodeBitmap == null)
                        {
                                return;
                        }

			throw new NotImplementedException();
			//
			//if (!IsEnable || !IsStarted)
   //                     {
   //                             Camera.Buffers.ReadUnlock(_decodeBitmap);
   //                             _decodeBitmap = null;
   //                             return;
   //                     }                        
                        
                        Bitmap target = Buffers.WriteLock();

                        _decodeBitmap.TranslateTo(target);

                        var sourceStamp = _decodeBitmap.TimeStampChain as CaptureTimeStampChain;
                        var targetStamp = target.TimeStampChain as DecodeTimeStampChain;
                        if (sourceStamp != null && targetStamp != null)
                        {
                                targetStamp.CaptureTime = sourceStamp.CaptureTime;
                                targetStamp.DecodeTime = DateTime.Now;
                        }

                        Buffers.WriteUnlock(target);

                        Camera.Buffers.ReadUnlock(_decodeBitmap);

                        OnDecodeFinished(new ValueEventArgs<Bitmap>(target));

                        _decodeBitmap = null;
                }

                #endregion

                #region 事件

                public event EventHandler<ValueEventArgs<Bitmap>> DecodeFinished;

                /// <summary>
                ///         引发 <see cref="E:Opened" /> 事件.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
                protected virtual void OnDecodeFinished(ValueEventArgs<Bitmap> e)
                {
                        e.Raise(this, ref DecodeFinished);
                }

                #endregion
        }
}
