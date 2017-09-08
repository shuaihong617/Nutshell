using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Components;
using Nutshell.Drawing.Imaging;
using System.Threading;

namespace Nutshell.Direct2D.WinForm
{
        public abstract class CycleRenderer : Worker
        {
                protected CycleRenderer(string id = "", [MustNotEqualNull]BitmapSence sence = null)
                        : base(id)
                {
                        Sence = sence;
                        _renderLooper = new ActionLooper("显示循环", ThreadPriority.Highest, 15, Render);
                }

                protected BitmapSence Sence { get; }

                private readonly Looper _renderLooper;

                protected Bitmap Bitmap { get; set; }

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

                        Sence.Swap();
                        Sence.Render();

                        _isRendering = false;
                }
        }
}