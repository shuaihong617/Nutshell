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
using System.Threading;
using System.Windows.Forms;
using Nutshell.Log;
using SharpDX.Direct2D1;

namespace Nutshell.Presentation.Direct2D.WinForm
{
        ///<summary>
        /// 双缓冲渲染场景
        ///</summary>
        public abstract class BufferSence : Sence
        {
                protected BufferSence(IdentityObject parent, string id = "", Control control = null)
                        : base(parent, id, control)
                {
                        BufferBitmapRenderTarget = new BitmapRenderTarget(SurfaceRenderTarget,
                                CompatibleRenderTargetOptions.None);
                }

                protected BitmapRenderTarget BufferBitmapRenderTarget { get; private set; }

                private readonly ReaderWriterLockSlim _bitmapLock = new ReaderWriterLockSlim();

                public void Update(Drawing.Imaging.Bitmap bitmap)
                {
                        if (_bitmapLock.TryEnterWriteLock(20))
                        {
                                bitmap.Width.MustEqual(BufferBitmapRenderTarget.Bitmap.PixelSize.Width);
                                bitmap.Height.MustEqual(BufferBitmapRenderTarget.Bitmap.PixelSize.Height);

                                BufferBitmapRenderTarget.Bitmap.CopyFromMemory(bitmap.Buffer, bitmap.Stride);

                                _bitmapLock.ExitWriteLock();

                                OnUpdated(EventArgs.Empty);
                        }
                }

                public override sealed void Render()
                {
                        if (_bitmapLock.TryEnterReadLock(20))
                        {
                                //绘制缓冲图像
                                BufferBitmapRenderTarget.BeginDraw();
                                Render(BufferBitmapRenderTarget);
                                BufferBitmapRenderTarget.EndDraw();

                                SurfaceRenderTarget.BeginDraw();
                                SurfaceRenderTarget.DrawBitmap(BufferBitmapRenderTarget.Bitmap, 1,
                                        BitmapInterpolationMode.Linear);
                                SurfaceRenderTarget.EndDraw();

                                _bitmapLock.ExitReadLock();
                        }
                }

                protected abstract void Render(RenderTarget target);

                #region 事件


                /// <summary>
                /// 当缓冲区图像已更新时发生
                /// </summary>
                public event EventHandler<EventArgs> Updated;

                /// <summary>
                /// 引发<see cref="E:Updated" />事件
                /// </summary>
                /// <param name="e">包含事件数据的<see cref="EventArgs"/>实例</param>
                protected virtual void OnUpdated(EventArgs e)
                {
                        e.Raise(this, ref Updated);
                }

                #endregion
        }
}