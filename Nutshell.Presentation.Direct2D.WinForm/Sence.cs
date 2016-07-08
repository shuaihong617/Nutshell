// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-07-06
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-07-06
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Windows.Forms;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DXGI;

namespace Nutshell.Presentation.Direct2D.WinForm
{
        /// <summary>
        /// 基于Direct2D的Winform控件渲染器
        /// </summary>
        public abstract class Sence : IdentityObject
        {
                /// <summary>
                /// 初始化<see cref="Sence" />的新实例.
                /// </summary>
                /// <param name="control">The control.</param>
                protected Sence(IdentityObject parent, string id = "", Control control = null)
                        :base(parent, id)
                {
                        control.MustNotNull();

                        Direct2D1Factory = new SharpDX.Direct2D1.Factory();

                        SurfaceRenderTarget = new WindowRenderTarget(Direct2D1Factory,
                                new RenderTargetProperties
                                (
                                        new PixelFormat(Format.B8G8R8A8_UNorm, SharpDX.Direct2D1.AlphaMode.Ignore)
                                ),
                                new HwndRenderTargetProperties
                                {
                                        Hwnd = control.Handle,
                                        PixelSize = new Size2(control.Width, control.Height),
                                        PresentOptions = PresentOptions.None,
                                }) {AntialiasMode = AntialiasMode.PerPrimitive};

                        DirectWriteFactory = new SharpDX.DirectWrite.Factory();
                }


                /// <summary>
                /// Gets the direct2 d1 factory.
                /// </summary>
                /// <value>The direct2 d1 factory.</value>
                public SharpDX.Direct2D1.Factory Direct2D1Factory { get; private set; }

                /// <summary>
                /// 控件表面渲染
                /// </summary>
                public WindowRenderTarget SurfaceRenderTarget { get; private set; }

                /// <summary>
                /// 文字渲染工厂
                /// </summary>
                public SharpDX.DirectWrite.Factory DirectWriteFactory { get; private set; }

                public abstract void Render();
        }
}