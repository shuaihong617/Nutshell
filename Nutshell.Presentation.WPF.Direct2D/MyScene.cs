using System;
using Microsoft.WindowsAPICodePack.DirectX.Direct2D1;
using Microsoft.WindowsAPICodePack.DirectX.DirectWrite;

namespace Nutshell.Presentation.Direct2D1
{
        public sealed class MySence : TimerSence
        {
                private SolidColorBrush redBrush;
                private SolidColorBrush whiteBrush;
                private TextFormat textFormat;
                private readonly DWriteFactory writeFactory;
                private double widthRatio;

                // These are used for tracking an accurate frames per second
                private DateTime time;
                private int frameCount;
                private int fps;

                public MySence()
                        : base(100) // Will probably only be about 67 fps due to the limitations of the timer
                {
                        writeFactory = DWriteFactory.CreateFactory();
                }

                protected override void DisposeManagedResources()
                {
                        writeFactory.Dispose();

                        base.DisposeManagedResources();
                }

                protected override void OnCreateResources(RenderTarget target)
                {
                        // We don't need to free any resources because the base class will
                        // call OnFreeResources if necessary before calling this method.
                        redBrush = target.CreateSolidColorBrush(new ColorF(1, 0, 0));
                        whiteBrush = target.CreateSolidColorBrush(new ColorF(1, 1, 1));

                        textFormat = writeFactory.CreateTextFormat("Arial", 12);

                        base.OnCreateResources(target); // Call this last to start the animation
                }

                protected override void OnFreeResources()
                {
                        base.OnFreeResources(); // Call this first to stop the animation

                        if (redBrush != null)
                        {
                                redBrush.Dispose();
                                redBrush = null;
                        }
                        if (whiteBrush != null)
                        {
                                whiteBrush.Dispose();
                                whiteBrush = null;
                        }
                        if (textFormat != null)
                        {
                                textFormat.Dispose();
                                textFormat = null;
                        }
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
                        widthRatio += ElapsedTime/5;
                        if (widthRatio > 1) // Reset
                        {
                                widthRatio = 0;
                        }

                        SizeF size = target.Size;
                        var width = (float) ((size.Width/3.0)*widthRatio);
                        var ellipse = new Ellipse(new Point2F(size.Width/2.0f, size.Height/2.0f), width,
                                size.Height/3.0f);

                        // This draws the ellipse in red on a semi-transparent blue background
                        target.BeginDraw();
                        target.Clear(new ColorF(0, 0, 1, 0.5f));
                        target.FillEllipse(ellipse, redBrush);

                        // Draw a little FPS in the top left corner
                        string text = string.Format("FPS {0}", fps);
                        target.DrawText(text, textFormat, new RectF(10, 10, 100, 20), whiteBrush);

                        // All done!
                        target.EndDraw();
                }
        }
}
