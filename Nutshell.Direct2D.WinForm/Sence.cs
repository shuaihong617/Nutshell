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
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Extensions;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DXGI;

namespace Nutshell.Direct2D.WinForm
{
        /// <summary>
        /// 基于Direct2D的Winform控件渲染场景
        /// </summary>
        public abstract class Sence : IdentityObject
        {
                /// <summary>
                /// 初始化<see cref="Sence" />的新实例.
                /// </summary>
                /// <param name="id">标识</param>
                /// <param name="control">渲染的目标控件</param>
                protected Sence(string id = "", [MustNotEqualNull]Control control = null)
                        :base( id)
                {
                        Control = control;

                        Direct2D1Factory = new SharpDX.Direct2D1.Factory();

                        SurfaceRenderTarget = new WindowRenderTarget(Direct2D1Factory,
                                new RenderTargetProperties
                                (
                                        //此处必须为B8G8R8A8格式，否则至少Win7不支持
                                        new PixelFormat(Format.B8G8R8A8_UNorm, SharpDX.Direct2D1.AlphaMode.Ignore)
                                ),
                                new HwndRenderTargetProperties
                                {
                                        Hwnd = Control.Handle,
                                        PixelSize = new Size2(Control.Width, Control.Height),
                                        PresentOptions = PresentOptions.None,
                                }) {AntialiasMode = AntialiasMode.PerPrimitive};

                        DirectWriteFactory = new SharpDX.DirectWrite.Factory();
                }

		[MustNotEqualNull]
                protected Control Control { get; private set; }

                /// <summary>
                /// 图像渲染工厂
                /// </summary>
                public SharpDX.Direct2D1.Factory Direct2D1Factory { get; }

                /// <summary>
                /// 控件表面渲染
                /// </summary>
                public WindowRenderTarget SurfaceRenderTarget { get; private set; }

                /// <summary>
                /// 文字渲染工厂
                /// </summary>
                public SharpDX.DirectWrite.Factory DirectWriteFactory { get; private set; }

                /// <summary>
                /// 渲染
                /// </summary>
                public abstract void Render();
        }
}