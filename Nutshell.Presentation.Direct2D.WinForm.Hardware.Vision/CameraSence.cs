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
        public abstract class CameraSence : CycleSence
        {
                /// <summary>
                /// 初始化<see cref="CameraSence" />的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">The key.</param>
                /// <param name="control">The image.</param>
                /// <param name="camera">The camera.</param>
                protected CameraSence(IdentityObject parent, string id, Control control, Camera camera)
                        : base(parent, id, control)
                {
                        camera.MustNotNull();
                        Camera = camera;

                        RedBrush = new SolidColorBrush(BufferBitmapRenderTarget, Colors.Red);
                        BlueBrush = new SolidColorBrush(BufferBitmapRenderTarget, Colors.Blue);

                        TextFactory = new SharpDX.DirectWrite.Factory();
                        YaHei36Font = new TextFormat(TextFactory, "Microsoft YaHei", 24);
                }

                private Camera Camera { get;  set; }

                protected SolidColorBrush RedBrush;
                protected SolidColorBrush BlueBrush;

                protected SharpDX.DirectWrite.Factory TextFactory;

                protected TextFormat YaHei36Font;

                protected override void Render(RenderTarget target)
                {              
                        target.DrawText(Camera.Id,YaHei36Font, new RawRectangleF(20, 20, 500,120), BlueBrush);

                        target.DrawText(Camera.IsConnected ? "在线" :"离线", YaHei36Font, 
                                new RawRectangleF(Camera.Region.Width - 120, 20, Camera.Region.Width, 120), Camera.IsConnected? BlueBrush:RedBrush);
                }                
        }
}