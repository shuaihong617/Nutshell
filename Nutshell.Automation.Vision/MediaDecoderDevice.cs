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

using Nutshell.Drawing;
using Nutshell.Drawing.Imaging;
using Nutshell.Threading;
using System.Diagnostics;

namespace Nutshell.Automation.Vision
{
        /// <summary>
        ///         摄像机图像消费者
        /// </summary>
        public class MediaDecoderDevice : Decoder<Bitmap>
        {
                /// <summary>
                ///         初始化<see cref="MediaDecoderDevice" />的新实例.
                /// </summary>
                /// <param name="id">The key.</param>
                /// <param name="mediaCaptureDevice">The camera.</param>
                /// <param name="pixelFormat">The pixel format.</param>
                public MediaDecoderDevice(string id, MediaCaptureDevice mediaCaptureDevice, PixelFormat pixelFormat)
                        : base(id, mediaCaptureDevice)
                {
                        PixelFormat = pixelFormat;

                        Region = mediaCaptureDevice.Region;
                }

                /// <summary>
                ///         格式
                /// </summary>
                public PixelFormat PixelFormat { get; }

                public Region Region { get; }

                /// <summary>
                ///         创建图像缓冲池
                /// </summary>
                protected override ReadWritePool<Bitmap> CreatePool()
                {
                        Debug.Assert(Region.Width > 0);
                        Debug.Assert(Region.Height > 0);

                        var pool = new ReadWritePool<Bitmap>("采集图像缓冲池");
                        for (var i = 1; i < 5; i++)
                        {
                                var bitmap = new Bitmap(i + "号缓冲位图", Region.Width, Region.Height, PixelFormat);
                                pool.Add(bitmap);
                        }
                        return pool;
                }

                protected override void DecodeCore(Bitmap source, Bitmap target)
                {
                        BitmapConverter.ConvertTo(source, target);
                }
        }
}