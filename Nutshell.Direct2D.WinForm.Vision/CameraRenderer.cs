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
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Vision;
using Nutshell.Components;
using Nutshell.Direct2D.WinForm;
using Nutshell.Drawing.Imaging;
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
                /// <param name="decoder">The decoder.</param>
                /// <param name="sence">The sence.</param>
                /// <exception cref="System.ArgumentException">摄像机解码单元不能为null</exception>
                public CameraRenderer(string id, [MustNotEqualNull]CameraDecoder decoder, CameraSence sence)
                        : base( id, sence)
                {
                        _decoder = decoder;
                }

                private readonly CameraDecoder _decoder;

                protected override Result StartCore()
                {
	                var baseResult = base.StartCore();
	                if (!baseResult.IsSuccessed)
	                {
		                return baseResult;
	                }
                        _decoder.DecodeFinished += Decoder_DecodeFinished;
			return Result.Successed;
                }

                private void Decoder_DecodeFinished(object sender, ValueEventArgs<Bitmap> e)
                {
                        var bitmap = e.Value;

                        _decoder.Pool.ReadLock(bitmap);
                        Sence.Swap(e.Value);

                        _decoder.Pool.ReadUnlock(bitmap);
                }

                protected override Result StopCore()
                {
                        _decoder.DecodeFinished -= Decoder_DecodeFinished;

			return base.StartCore();
                }
        }
}