using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.DirectX.Direct2D1;
using Microsoft.WindowsAPICodePack.DirectX.DirectWrite;
using Microsoft.WindowsAPICodePack.DirectX.Graphics;
using Nutshell.Drawing.Imaging;
using Nutshell.Hardware;
using Nutshell.Hardware.Vision;
using PixelFormat = Nutshell.Drawing.Imaging.PixelFormat;

namespace Nutshell.Presentation.Direct2D1
{
        public class CameraSence : Sence
        {
                
                private TextFormat textFormat;
                private readonly DWriteFactory writeFactory;

                // These are used for tracking an accurate frames per second
                private DateTime time;
                private int frameCount;
                private int fps;

                public CameraSence(IdentityObject parent, string id, int width, int height, Camera camera)
                        : base() // Will probably only be about 67 fps due to the limitations of the timer
                {
                        camera.MustNotNull();
                        _camera = camera;

                        writeFactory = DWriteFactory.CreateFactory();

                        _bitmap = new Bitmap(this, "缓冲图像", width, height, PixelFormat.Bgra32);
                }


                protected SolidColorBrush RedBrush { get; private set; }

                public bool IsStarted { get; private set; }

                private readonly Camera _camera;

                private readonly Bitmap _bitmap;

                private D2DBitmap _d2DBitmap;

                protected override void DisposeManagedResources()
                {
                        writeFactory.Dispose();
                        base.DisposeManagedResources();
                }

                protected override void OnCreateResources(RenderTarget target)
                {
                        // We don't need to free any resources because the base class will
                        // call OnFreeResources if necessary before calling this method.

                        RedBrush = target.CreateSolidColorBrush(new ColorF(1, 0, 0));

                        //whiteBrush = RenderTarget.CreateSolidColorBrush(new ColorF(1, 1, 1));
                        _d2DBitmap = target.CreateBitmap(target.PixelSize,
                                new BitmapProperties(new Microsoft.WindowsAPICodePack.DirectX.Direct2D1.PixelFormat(Format.B8G8R8A8UNorm, AlphaMode.Premultiplied), 96, 96));

                        textFormat = writeFactory.CreateTextFormat("Arial", 12);

                        base.OnCreateResources(target); // Call this last to start the animation
                }

                protected override void OnFreeResources()
                {
                        base.OnFreeResources(); // Call this first to stop the animation

                        //SafeDispose(ref RedBrush);
                        SafeDispose(ref textFormat);
                }


                public void Start()
                {
                        _camera.CaptureSuccessed += Camera_CaptureSuccessed;
                        IsStarted = true;

                        //base.Start();
                }

                public  void Stop()
                {
                        //base.Stop();

                        IsStarted = false;
                        _camera.CaptureSuccessed -= Camera_CaptureSuccessed;

                        //if (_processTask != null)
                        //{
                        //        if (!_processTask.IsCompleted)
                        //        {
                        //                _processTask.Wait();
                        //        }
                        //}
                }

                /// <summary>
                ///         处理任务
                /// </summary>
                private Task _processTask;

                private int i = 4;

                /// <summary>
                ///         处理摄像机图像采集完成事件
                /// </summary>
                /// <param name="sender">The source of the event.</param>
                /// <param name="e">The e.</param>
                private void Camera_CaptureSuccessed(object sender, ValueEventArgs<Bitmap> e)
                {
                        if (_processTask != null && !_processTask.IsCompleted)
                        {
                                return;
                        }

                        var bitmap = e.Data;

                        if (_camera.RunMode == RunMode.Release)
                        {
                                if (!_camera.BitmapPool.EnterRead(bitmap))
                                {
                                        return;
                                }
                        }

                        if (IsStarted)
                        {
                                bitmap.ConvertTo(_bitmap);
                        }

                        if (_camera.RunMode == RunMode.Release)
                        {
                                _camera.BitmapPool.ExitRead(bitmap);

                        }

                        _processTask = Task.Run(() =>
                        {
                                Trace.WriteLine(DateTime.Now +  "   Render");
                                _d2DBitmap.CopyFromMemory(_bitmap.Buffer, (uint)_bitmap.Stride);
                                Render();
                                i++;                                
                        });
                }

                protected override void Render(RenderTarget target)
                {
                        // Calculate our actual frame rate
                        frameCount++;
                        if (DateTime.UtcNow.Subtract(time).TotalSeconds >= 1)
                        {
                                fps = frameCount;
                                frameCount = 0;
                                time = DateTime.UtcNow;
                        }

                        // This is what we're going to draw. We'll animate the width of the
                        // elipse over a span of five seconds (ElapsedTime / 5).
                        if (i > 200) // Reset
                        {
                                i = 4;
                        }

                        SizeF size = target.Size;
                        var ellipse = new Ellipse(new Point2F(size.Width / 2.0f, size.Height / 2.0f), 200,
                                size.Height / 3.0f);
                        //target.DrawEllipse(ellipse, RedBrush, 1);
                        

                        // This draws the ellipse in red on a semi-transparent blue background
                        target.BeginDraw();
                        //target.Clear(new ColorF(0, 0, 1, 1f));

                        

                        //target.DrawBitmap(_d2DBitmap, 1f, BitmapInterpolationMode.Linear);

                        RenderContent(target);
                        // Draw a little FPS in the top left corner
                        string text = string.Format("FPS {0}", fps);
                        //target.DrawText(text, textFormat, new RectF(10, 10, 100, 20), RedBrush);

                        // All done!
                        target.EndDraw();
                }

                protected virtual void RenderContent(RenderTarget target)
                {
                        
                }
        }
}
