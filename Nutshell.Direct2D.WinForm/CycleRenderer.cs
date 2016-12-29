using System;
using System.Threading;
using Nutshell.Components;
using Nutshell.Drawing.Imaging;
using SharpDXBitmap = SharpDX.Direct2D1.Bitmap;

namespace Nutshell.Presentation.Direct2D.WinForm
{
        public abstract class CycleRenderer : Dispatcher
        {
                protected CycleRenderer(IdentityObject parent, string id = null, BitmapSence sence = null)
                        : base(parent, id)
                {
                        if (sence == null)
                        {
                                throw new ArgumentException("渲染场景不能为null");
                        }
                        Sence = sence;

                        _renderLoopDispatcher = new LoopDispatcher(this, "显示循环", ThreadPriority.Highest,5, Render);
                }

                protected BitmapSence Sence { get;private set; }

                private readonly LoopDispatcher _renderLoopDispatcher;

                protected Bitmap Bitmap { get; set; }

                private bool _isRendering;

                protected override bool StartCore()
                {
                        return _renderLoopDispatcher.Start();
                }

                protected override bool StopCore()
                {
                        return _renderLoopDispatcher.Stop();
                }


                protected virtual void Render()
                {
                        if (_isRendering)
                        {
                                return;
                        }

                        _isRendering = true;

                        Sence.Swap();
                        Sence.Render();

                        _isRendering = false;
                }
        }
}