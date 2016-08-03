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


using System;
using System.Windows.Forms;
using SharpDX.Direct2D1;
using SharpDXBitmap = SharpDX.Direct2D1.Bitmap;
using NutshellBitmap = Nutshell.Drawing.Imaging.Bitmap;

namespace Nutshell.Presentation.Direct2D.WinForm
{
        /// <summary>
        ///         位图渲染场景
        /// </summary>
        public abstract class BackgroundSence : Sence
        {
                protected BackgroundSence(IdentityObject parent, string id = "", Control control = null)
                        : base(parent, id, control)
                {
                        BufferBitmapRenderTarget = new BitmapRenderTarget(SurfaceRenderTarget,
                                CompatibleRenderTargetOptions.None);
                }

                protected BitmapRenderTarget BufferBitmapRenderTarget { get; private set; }
                public DateTime UpdateTime { get; private set; }

                public void Update(NutshellBitmap source)
                {
                        var target = BufferBitmapRenderTarget.Bitmap;
                        source.Width.MustEqual(target.PixelSize.Width);
                        source.Height.MustEqual(target.PixelSize.Height);

                        BufferBitmapRenderTarget.Bitmap.CopyFromMemory(source.Buffer, source.Stride);

                        UpdateTime = DateTime.Now;

                        OnUpdated(EventArgs.Empty);
                }

                public override sealed void Render()
                {
                        BufferBitmapRenderTarget.BeginDraw();
                        Render(BufferBitmapRenderTarget);
                        BufferBitmapRenderTarget.EndDraw();

                        SurfaceRenderTarget.BeginDraw();
                        SurfaceRenderTarget.DrawBitmap(BufferBitmapRenderTarget.Bitmap, 1,
                                BitmapInterpolationMode.Linear);
                        SurfaceRenderTarget.EndDraw();
                }

                protected abstract void Render(RenderTarget target);

                #region 事件

                /// <summary>
                ///         当缓冲区图像已更新时发生
                /// </summary>
                public event EventHandler<EventArgs> Updated;

                /// <summary>
                ///         引发<see cref="E:Updated" />事件
                /// </summary>
                /// <param name="e">包含事件数据的<see cref="EventArgs" />实例</param>
                protected virtual void OnUpdated(EventArgs e)
                {
                        e.Raise(this, ref Updated);
                }

                #endregion
        }
}