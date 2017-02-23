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
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Vision;
using Nutshell.Drawing.Imaging;
using Nutshell.Hardware.Vision;
using SharpDX.Direct2D1;
using Bitmap = Nutshell.Drawing.Imaging.Bitmap;
using DXBitmap = SharpDX.Direct2D1.Bitmap;
using PixelFormat = Nutshell.Drawing.Imaging.PixelFormat;

namespace Nutshell.Presentation.Direct2D.WinForm
{
        /// <summary>
        ///         位图渲染场景
        /// </summary>
        public abstract class BitmapSence : Sence
        {
                protected BitmapSence(IdentityObject parent, string id = null, [MustNotEqualNull]Control control = null)
                        : base(parent, id, control)
                {
                        BufferBitmapRenderTarget = new BitmapRenderTarget(SurfaceRenderTarget,
                                CompatibleRenderTargetOptions.None);

                        _backgroundBitmap = new Bitmap(this, string.Empty, control.Width, control.Height, PixelFormat.Bgra32, new SwapTimeStampChain());
                        _foregroundBitmap = new Bitmap(this, string.Empty, control.Width, control.Height, PixelFormat.Bgra32, new SwapTimeStampChain());
                }

                protected BitmapRenderTarget BufferBitmapRenderTarget { get; private set; }
                public DateTime UpdateTime { get; private set; }

                private readonly Bitmap _backgroundBitmap;

                private readonly Bitmap _foregroundBitmap;

                private readonly object _threadLock = new object();

                protected TimeSpan ProcessTimeSpan { get; private set; }

                public void Swap(Bitmap source = null)
                {
                        lock (_threadLock)
                        {
                                if (source == null)
                                {
                                        var sourceStamp = _backgroundBitmap.TimeStampChain as SwapTimeStampChain;
                                        if (sourceStamp == null)
                                        {
                                                throw new InvalidOperationException();
                                        }

                                        var targetStamp = _foregroundBitmap.TimeStampChain as SwapTimeStampChain;
                                        if (targetStamp == null)
                                        {
                                                throw new InvalidOperationException();
                                        }

                                        //source为null时，从背景位图更新前景位图数据
                                        if (sourceStamp.DecodeTime > targetStamp.DecodeTime)
                                        {
                                                _backgroundBitmap.TranslateTo(_foregroundBitmap);


                                                targetStamp.CaptureTime = sourceStamp.CaptureTime;
                                                targetStamp.DecodeTime = sourceStamp.DecodeTime;
                                                targetStamp.SwapTime = sourceStamp.SwapTime;
                                        }
                                }
                                else
                                {
                                        //source不为null时，从解码位图更新背景位图数据
                                        source.TranslateTo(_backgroundBitmap);

                                        var sourceStamp = source.TimeStampChain as DecodeTimeStampChain;
                                        var targetStamp = _backgroundBitmap.TimeStampChain as SwapTimeStampChain;
                                        if (sourceStamp != null && targetStamp != null)
                                        {
                                                targetStamp.CaptureTime = sourceStamp.CaptureTime;
                                                targetStamp.DecodeTime = sourceStamp.DecodeTime;
                                                targetStamp.SwapTime = DateTime.Now;

                                                //TimeSpan = targetStamp.SwapTime - targetStamp.CaptureTime;
                                        }
                                }
                        }
                }

                public override sealed void Render()
                {
                        var stamp = _foregroundBitmap.TimeStampChain as CaptureTimeStampChain;
                        ProcessTimeSpan = DateTime.Now - stamp.CaptureTime;

                        BufferBitmapRenderTarget.Bitmap.CopyFromMemory(_foregroundBitmap.Buffer,
                                _foregroundBitmap.Stride);

                        BufferBitmapRenderTarget.BeginDraw();
                        Render(BufferBitmapRenderTarget);
                        BufferBitmapRenderTarget.EndDraw();

                        //渲染缓冲图像到界面
                        SurfaceRenderTarget.BeginDraw();
                        //重要操作，清理以前绘制结果为透明黑色背景，无此行界面绘制结果会累加
                        SurfaceRenderTarget.Clear(null);

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