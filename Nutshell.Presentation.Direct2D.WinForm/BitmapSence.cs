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
using Nutshell.Drawing.Imaging;
using SharpDX.Direct2D1;
using DXBitmap = SharpDX.Direct2D1.Bitmap;

namespace Nutshell.Presentation.Direct2D.WinForm
{
        /// <summary>
        ///         位图渲染场景
        /// </summary>
        public abstract class BitmapSence : Sence
        {
                protected BitmapSence(IdentityObject parent, string id = "", Control control = null)
                        : base(parent, id, control)
                {
                        BufferBitmapRenderTarget = new BitmapRenderTarget(SurfaceRenderTarget,
                                CompatibleRenderTargetOptions.None);
                }

                protected BitmapRenderTarget BufferBitmapRenderTarget { get; private set; }
                public DateTime UpdateTime { get; private set; }

                private NSBitmap _backgroundBitmap;

                private NSBitmap _foregroundBitmap;

                private readonly object _threadLock = new object();

                public void UpdateBackgroundBitmap(NSBitmap bitmap)
                {
                }

                public void Update(NSBitmap source = null)
                {
                        lock (_threadLock)
                        {
                                if (source == null)
                                {
                                        if (_backgroundBitmap != null)
                                        {
                                                _foregroundBitmap = _backgroundBitmap;
                                                _backgroundBitmap = null;
                                        }
                                }
                                else
                                {
                                        _backgroundBitmap = source;
                                }
                        }
                }

                public override sealed void Render()
                {
                        BufferBitmapRenderTarget.Bitmap.CopyFromMemory(_foregroundBitmap.Buffer, _foregroundBitmap.Stride);

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