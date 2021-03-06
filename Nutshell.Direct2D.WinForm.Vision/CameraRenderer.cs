﻿// ***********************************************************************
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

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Vision;
using Bitmap = Nutshell.Drawing.Imaging.Bitmap;

namespace Nutshell.Direct2D.WinForm.Vision
{
        /// <summary>
        ///         Class CameraRender.
        /// </summary>
        public class CameraRenderer : CycleRenderer
        {
                /// <summary>
                ///         初始化<see cref="CameraRenderer" />的新实例.
                /// </summary>
                /// <param name="id">The key.</param>
                /// <param name="decoderDevice">The decoder.</param>
                /// <param name="sence">The sence.</param>
                /// <exception cref="System.ArgumentException">摄像机解码单元不能为null</exception>
                public CameraRenderer(string id, [MustNotEqualNull]MediaDecoderDevice decoderDevice, CameraSence sence)
                        : base(id, sence)
                {
                        _decoderDevice = decoderDevice;
                }

                private readonly MediaDecoderDevice _decoderDevice;

                protected override bool StartCore()
                {
                        if (!base.StartCore())
                        {
                                return false;
                        }
                        _decoderDevice.DecodeFinished += DecoderDeviceDecodeFinished;
                        return true;
                }

                private void DecoderDeviceDecodeFinished(object sender, ValueEventArgs<Bitmap> e)
                {
                        var bitmap = e.Value;

                        _decoderDevice.Pool.ReadLock(bitmap);
                        Sence.Swap(e.Value);

                        _decoderDevice.Pool.ReadUnlock(bitmap);
                }

                protected override bool StopCore()
                {
                        _decoderDevice.DecodeFinished -= DecoderDeviceDecodeFinished;

                        return base.StartCore();
                }
        }
}