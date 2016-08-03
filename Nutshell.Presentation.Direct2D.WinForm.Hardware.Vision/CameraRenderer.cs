// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-11-19
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-11-19
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Drawing;
using Nutshell.Hardware.Vision;
using Bitmap = Nutshell.Drawing.Imaging.Bitmap;

namespace Nutshell.Presentation.Direct2D.WinForm.Hardware.Vision
{
        /// <summary>
        ///         Class CameraRender.
        /// </summary>
        public class CameraRenderer : CycleRenderer
        {
                /// <summary>
                ///         初始化<see cref="CameraRenderer" />的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">The key.</param>
                /// <param name="decoder">The decoder.</param>
                /// <param name="sence">The sence.</param>
                /// <exception cref="System.ArgumentException">摄像机解码单元不能为null</exception>
                public CameraRenderer(IdentityObject parent, string id, CameraDecoder decoder, CameraSence sence)
                        : base(parent, id, sence)
                {
                        if (decoder == null)
                        {
                                throw new ArgumentException("摄像机解码单元不能为null");
                        }
                        _decoder = decoder;
                }

                private readonly CameraDecoder _decoder;

                public bool IsRenderStarted
                {
                        get { return _isRenderStarted; }
                        private set
                        {
                                _isRenderStarted = value;
                                RaisePropertyChanged();
                        }
                }

                protected static Font YaHei40Font = new Font("Microsoft YaHei", 10);
                private bool _isRenderStarted;


                public DateTime LastDecodeBitmapTimeStamp { get; private set; }

                protected override void Render()
                {
                        Bitmap source = _decoder.Buffers.Dequeue();
                        if (source == null)
                        {
                                throw new InvalidOperationException();
                        }

                        if (source.TimeStamp < LastDecodeBitmapTimeStamp)
                        {
                                _decoder.Buffers.Enqueue(source);
                                return;
                        }

                        Bitmap = source;
                        base.Render();

                        LastDecodeBitmapTimeStamp = source.TimeStamp;
                        _decoder.Buffers.Enqueue(source);

                        //Trace.WriteLine(DateTime.Now.ToChineseLongMillisecondString());

                }
        }
}