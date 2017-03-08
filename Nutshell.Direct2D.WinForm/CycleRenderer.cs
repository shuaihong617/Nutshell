using System;
using System.Diagnostics;
using System.Threading;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Components;
using Nutshell.Drawing.Imaging;
using SharpDXBitmap = SharpDX.Direct2D1.Bitmap;

namespace Nutshell.Direct2D.WinForm
{
        public abstract class CycleRenderer : Worker
        {
                protected CycleRenderer(string id = "", [MustNotEqualNull]BitmapSence sence = null)
                        : base( id)
                {
                        Sence = sence;
                        _renderLooper = new Looper("显示循环", ThreadPriority.Highest,15, Render);
                }

                protected BitmapSence Sence { get;private set; }

                private readonly Looper _renderLooper;

                protected Bitmap Bitmap { get; set; }

                private bool _isRendering;

                protected override Result StartCore()
                {
                        return _renderLooper.Start();
                }

                protected override Result StopCore()
                {
			return _renderLooper.Stop();
                }


                protected virtual Result Render()
                {
                        if (_isRendering)
                        {
                                return Result.Failed;
                        }

                        _isRendering = true;

                        Sence.Swap();
                        Sence.Render();

                        _isRendering = false;

			return Result.Successed;
                }
        }
}