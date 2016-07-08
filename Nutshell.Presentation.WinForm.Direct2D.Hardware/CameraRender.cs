using System.Diagnostics;
using System.Windows.Forms;
using Nutshell.Hardware.Vision;
using Nutshell.Presentation.Direct2D1;
using SharpDX.Direct2D1;
using SharpDX.DirectWrite;
using SharpDX.Mathematics.Interop;
using BitmapRenderTarget = SharpDX.Direct2D1.BitmapRenderTarget;

namespace Nutshell.Presentation.WinForm.Direct2D.Hardware
{
        public abstract class CameraRender : CameraProcessor
        {
                protected CameraRender(IdentityObject parent, string id, Control control, Camera camera)
                        : base(parent, id, camera, Drawing.Imaging.PixelFormat.Bgra32)
                {
                        Debug.Assert(control != null);

                        Width = camera.Region.Width;
                        Height = camera.Region.Height;

                        Render = new Direct2DDoubleBufferRender(control, Width, Height);

                        Brush = new SolidColorBrush(Render.BufferBitmapRenderTarget, Colors.Red);
                        YaHei40TextFormat = new TextFormat(Render.DirectWriteFactory, "Microsoft YaHei", 40);
                }

                public Direct2DDoubleBufferRender Render { get; set; }

                public int Width { get;private set; }

                public int Height { get; private set; }

                /// <summary>
                ///         缓冲采集的图像
                /// </summary>

                protected SolidColorBrush Brush { get; private set; }

                protected TextFormat YaHei40TextFormat { get; private set; }

                /// <summary>
                ///         传递摄像机采集到的图像数据到处理器数据接收对象
                /// </summary>
                protected override void ProcessCore()
                {
                        Render.BeginDraw();

                        //NLoger.Info(Key + "读锁定");
                        //if (PixelFormat == ProcessBitmap.PixelFormat)
                        //{
                        //        image.CopyTo(ProcessImage);
                        //}
                        //else
                        //{
                        //        image.ConvertTo(ProcessBitmap);                                
                        //}


                        Render.BufferBitmap.CopyFromMemory(ProcessBitmap.Buffer,
                                ProcessBitmap.Stride);

                        Render.DrawBufferBitmap();

                        Draw(Render.BufferBitmapRenderTarget);

                        Render.EndDraw();
                }

                protected virtual void Draw(BitmapRenderTarget target)
                {
                        Brush.Color = Colors.Green;
                        target.DrawText(Camera.Id, YaHei40TextFormat,
                                new RawRectangleF(20, 20, 800, 50), Brush);

                        Brush.Color = Camera.IsConnected ? Colors.Green : Colors.Red;
                        target.DrawText(Camera.IsConnected? "在线":"离线", YaHei40TextFormat,
                                new RawRectangleF(Width - 100, 20, 100, 50), Brush);
                }
        }
}