using System;
using System.Threading;
using Nutshell.Components;
using SharpDXBitmap = SharpDX.Direct2D1.Bitmap;
using NutshellBitmap = Nutshell.Drawing.Imaging.Bitmap;

namespace Nutshell.Presentation.Direct2D.WinForm
{
        public abstract class CycleRenderer : Worker
        {
                protected CycleRenderer(IdentityObject parent, string id = "", BackgroundSence sence = null)
                        : base(parent, id)
                {
                        if (sence == null)
                        {
                                throw new ArgumentException("渲染场景不能为null");
                        }
                        _sence = sence;

                        _renderLooper = new Looper(this, "显示循环", Render, 5, ThreadPriority.Highest);
                }

                private readonly BackgroundSence _sence;
                private readonly Looper _renderLooper;

                protected NutshellBitmap Bitmap { get; set; }

                private bool _isRendering;

                protected override bool StartCore()
                {
                        return _renderLooper.Start();
                }

                protected override bool StopCore()
                {
                        return _renderLooper.Stop();
                }


                protected virtual void Render()
                {
                        if (_isRendering)
                        {
                                return;
                        }

                        _isRendering = true;

                        _sence.Update(Bitmap);
                        _sence.Render();

                        _isRendering = false;
                }
        }
}