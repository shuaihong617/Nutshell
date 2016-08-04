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
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using Nutshell.Components;
using Nutshell.Drawing.Imaging;
using Nutshell.Hardware.Vision;

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

                protected override bool StartCore()
                {
                        _decoder.DecodeFinished += Decoder_DecodeFinished;
                        return base.StartCore();
                }

                private void Decoder_DecodeFinished(object sender, ValueEventArgs<NSBitmap> e)
                {
                        Sence.Update(e.Data);
                }

                protected override bool StopCore()
                {
                        _decoder.DecodeFinished -= Decoder_DecodeFinished;
                        return base.StopCore();
                }
        }
}