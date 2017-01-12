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

using System;
using System.Windows.Forms;
using Nutshell.Hardware.Vision;
using SharpDX.Direct2D1;
using SharpDX.DirectWrite;
using SharpDX.Mathematics.Interop;

namespace Nutshell.Presentation.Direct2D.WinForm.Hardware.Vision
{
        /// <summary>
        ///         Class CameraRender.
        /// </summary>
        public class CameraSence : BitmapSence
        {
                /// <summary>
                /// 初始化<see cref="CameraSence" />的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">The key.</param>
                /// <param name="control">The image.</param>
                /// <param name="camera">The camera.</param>
                public CameraSence(IdentityObject parent, string id, Control control, Camera camera)
                        : base(parent, id, control)
                {
                        camera.NotNull();
                        Camera = camera;

                        RedBrush = new SolidColorBrush(SurfaceRenderTarget, Colors.Red);
                        BlueBrush = new SolidColorBrush(SurfaceRenderTarget, Colors.Blue);

                        TextFactory = new SharpDX.DirectWrite.Factory();
                        YaHei36Font = new TextFormat(TextFactory, "Microsoft YaHei", FontWeight.Light, FontStyle.Normal, 36);

                        _cameraOnlineLocation = new RawRectangleF(Camera.Region.Width - 96, Camera.Region.Height - 60, Camera.Region.Width, Camera.Region.Height);
                }

                private readonly RawRectangleF _cameraIdLocation = new RawRectangleF(20, 20, 500, 120);
                private readonly RawRectangleF _cameraOnlineLocation;

                protected Camera Camera { get;  set; }

                protected SolidColorBrush RedBrush;
                protected SolidColorBrush BlueBrush;

                protected SharpDX.DirectWrite.Factory TextFactory;

                protected TextFormat YaHei36Font;

                protected override void Render(RenderTarget target)
                {              
                        target.DrawText(Camera.Id,YaHei36Font, _cameraIdLocation, RedBrush);

                        var totalMilliseconds = ProcessTimeSpan.TotalMilliseconds;
                        //target.DrawText(totalMilliseconds.ToString(), YaHei36Font, new RawRectangleF(20, 120, 500, 120), BlueBrush);

                        var second = DateTime.Now.Second;
                        if (second % 2 == 0)
                        {
                                target.DrawText(totalMilliseconds < 1500 ? "在线" : "离线", YaHei36Font,
                                _cameraOnlineLocation, totalMilliseconds < 1500 ? RedBrush : BlueBrush);
                        }

                        //target.DrawText(totalMilliseconds < 1500 ? "在线" : "离线", YaHei36Font,
                        //        _cameraOnlineLocation, totalMilliseconds < 1500 ? BlueBrush : RedBrush);

                        //target.DrawText(Camera.IsConnected ? "在线" :"离线", YaHei36Font, 
                        //        new RawRectangleF(Camera.Region.Width - 120, 20, Camera.Region.Width, 120), Camera.IsConnected? BlueBrush:RedBrush);
                }                
        }
}