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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Forms;
using Nutshell.Data;
using Nutshell.Hardware.Vision;
using Nutshell.Media.Imaging;

namespace Nutshell.Media.Hardware.Vision
{
        /// <summary>
        ///         Class CameraRender.
        /// </summary>
        public abstract class CameraRender : CameraProcessor
        {
                /// <summary>
                ///         初始化<see cref="CameraRender" />的新实例.
                /// </summary>
                /// <param name="id">The key.</param>
                /// <param name="control">The image.</param>
                /// <param name="camera">The camera.</param>
                protected CameraRender(IdentityObject parent, string id, Control control, Camera camera)
                        : base(parent, id, camera, PixelFormat.Format32bppRgb)
                {
                        Debug.Assert(control != null);
                        Debug.Assert(camera != null);

                        Control = control;

                        Background = new Bitmap(camera.InterestRegion.Width, camera.InterestRegion.Height,
                                PixelFormat.Format32bppRgb);
                }

                /// <summary>
                ///         显示位图的WPF Image控件
                /// </summary>
                /// <value>The image.</value>
                public Control Control { get; private set; }

                /// <summary>
                ///         后台在摄像机画面上附加绘制其他信息的位图
                /// </summary>
                public Bitmap Background { get; private set; }

                protected static Font YaHei40Font = new Font("Microsoft YaHei", 40);

                protected override void ProcessCore()
                {                        
                        using (var graphics = Graphics.FromImage(Background))
                        {
                                graphics.SmoothingMode = SmoothingMode.AntiAlias;

                                graphics.Clear(Color.White);

                                ProcessImage.CopyTo(Background);

                                RenderCamera(graphics);
                                RenderOther(graphics);
                        }

                        using (var graphics = Control.CreateGraphics())
                        {
                                graphics.DrawImageUnscaled(Background, 0, 0);
                        }
                }

                /// <summary>
                ///         Renders the camera.
                /// </summary>
                /// <param name="graphics">The drawing context.</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                protected void RenderCamera(Graphics graphics)
                {
                        graphics.DrawString(Camera.Id, YaHei40Font, Brushes.LawnGreen, 20, 20);
                }

                /// <summary>
                ///         Renders the other.
                /// </summary>
                /// <param name="graphics">The drawing context.</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                protected abstract bool RenderOther(Graphics graphics);
        }
}