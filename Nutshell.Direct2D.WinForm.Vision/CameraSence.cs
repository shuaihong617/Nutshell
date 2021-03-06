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

using Nutshell.Automation.Vision;
using Nutshell.Extensions;
using SharpDX.Direct2D1;
using SharpDX.DirectWrite;
using SharpDX.Mathematics.Interop;
using System;
using System.Windows.Forms;

namespace Nutshell.Direct2D.WinForm.Vision
{
        /// <summary>
        ///         Class CameraRender.
        /// </summary>
        public class CameraSence : BitmapSence
        {
                /// <summary>
                /// 初始化<see cref="CameraSence" />的新实例.
                /// </summary>
                /// <param name="id">The key.</param>
                /// <param name="control">The image.</param>
                /// <param name="cameraDevice">The camera.</param>
                public CameraSence(string id, Control control, MediaCaptureDevice cameraDevice)
                        : base(id, control)
                {
                        cameraDevice.NotNull();
                        CameraDevice = cameraDevice;

                        RedBrush = new SolidColorBrush(SurfaceRenderTarget, Colors.Red);
                        BlueBrush = new SolidColorBrush(SurfaceRenderTarget, Colors.Blue);
                        LawnGreenBrush = new SolidColorBrush(SurfaceRenderTarget, Colors.LawnGreen);

                        TextFactory = new SharpDX.DirectWrite.Factory();
                        YaHei36Font = new TextFormat(TextFactory, "Microsoft YaHei", FontWeight.Light, FontStyle.Normal, 36);
                        YaHei18Font = new TextFormat(TextFactory, "Microsoft YaHei", FontWeight.Light, FontStyle.Normal, 18);

                        _cameraOnlineLocation = new RawRectangleF(CameraDevice.Region.Width - 96, CameraDevice.Region.Height - 60, CameraDevice.Region.Width, CameraDevice.Region.Height);
                }

                private readonly RawRectangleF _cameraIdLocation = new RawRectangleF(20, 20, 500, 120);
                private readonly RawRectangleF _cameraOnlineLocation;

                protected MediaCaptureDevice CameraDevice { get; set; }

                protected SolidColorBrush RedBrush;
                protected SolidColorBrush BlueBrush;
                protected SolidColorBrush LawnGreenBrush;

                protected SharpDX.DirectWrite.Factory TextFactory;

                protected TextFormat YaHei36Font;
                protected TextFormat YaHei18Font;

                private double _processUsedMilliseconds = 0;
                private int _nowSecond = 0;

                protected override void Render(RenderTarget target)
                {
                        target.DrawText(CameraDevice.Id, YaHei36Font, _cameraIdLocation, RedBrush);

                        target.DrawText("PUM = " + _processUsedMilliseconds.ToString("f0"), YaHei36Font, new RawRectangleF(20, 120, 500, 120), BlueBrush);

                        var second = DateTime.Now.Second;
                        if (second != _nowSecond)
                        {
                                _processUsedMilliseconds = ProcessTimeSpan.TotalMilliseconds;
                                _nowSecond = second;
                        }

                        if (second % 2 == 0)
                        {
                                target.DrawText(_processUsedMilliseconds < 1500 ? "在线" : "离线", YaHei36Font,
                                _cameraOnlineLocation, _processUsedMilliseconds < 1500 ? RedBrush : BlueBrush);
                        }
                }
        }
}