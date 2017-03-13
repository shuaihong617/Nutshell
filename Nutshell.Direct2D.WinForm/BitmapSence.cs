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

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Drawing.Imaging;
using Nutshell.Extensions;
using SharpDX.Direct2D1;
using System;
using System.Windows.Forms;
using Bitmap = Nutshell.Drawing.Imaging.Bitmap;
using PixelFormat = Nutshell.Drawing.Imaging.PixelFormat;

namespace Nutshell.Direct2D.WinForm
{
        /// <summary>
        ///         位图渲染场景
        /// </summary>
        public abstract class BitmapSence : Sence
        {
                protected BitmapSence(string id = "", [MustNotEqualNull] Control control = null)
                        : base(id, control)
                {
                        BufferBitmapRenderTarget = new BitmapRenderTarget(SurfaceRenderTarget,
                                CompatibleRenderTargetOptions.None);

                        _backgroundBitmap = new Bitmap(string.Empty, control.Width, control.Height, PixelFormat.Bgra32);
                        _foregroundBitmap = new Bitmap(string.Empty, control.Width, control.Height, PixelFormat.Bgra32);
                }

                protected BitmapRenderTarget BufferBitmapRenderTarget { get; }
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
                                        var sourceStamps = _backgroundBitmap.TimeStamps;
                                        var targetStamps = _foregroundBitmap.TimeStamps;

                                        //source为null时，从背景位图更新前景位图数据
                                        if (sourceStamps["DecodeTime"] > targetStamps["DecodeTime"])
                                        {
                                                BitmapConverter.ConvertTo(_backgroundBitmap, _foregroundBitmap);

                                                targetStamps["CaptureTime"] = sourceStamps["CaptureTime"];
                                                targetStamps["DecodeTime"] = sourceStamps["DecodeTime"];
                                                targetStamps["SwapTime"] = sourceStamps["SwapTime"];
                                        }
                                }
                                else
                                {
                                        var sourceStamps = source.TimeStamps;
                                        var targetStamps = _backgroundBitmap.TimeStamps;

                                        //source不为null时，从解码位图更新背景位图数据
                                        BitmapConverter.ConvertTo(source, _backgroundBitmap);

                                        targetStamps["CaptureTime"] = sourceStamps["CaptureTime"];
                                        targetStamps["DecodeTime"] = sourceStamps["DecodeTime"];
                                        targetStamps["SwapTime"] = DateTime.Now;
                                }
                        }
                }

                public override sealed void Render()
                {
                        var captureTime = _foregroundBitmap.TimeStamps["CaptureTime"];
                        ProcessTimeSpan = DateTime.Now - captureTime;

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

                #endregion 事件
        }
}