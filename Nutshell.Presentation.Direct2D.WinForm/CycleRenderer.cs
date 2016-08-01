using System.Windows.Forms;
using Nutshell.Components;
using Nutshell.Drawing.Imaging;

namespace Nutshell.Presentation.Direct2D.WinForm
{
        public abstract class CycleRenderer:Worker
        {
                protected CycleRenderer(IdentityObject parent, string id = "", Control control = null)
                        : base(parent, id)
                {
                        _renderLooper = new Looper(this, "显示循环", Render, 50);
                }

                private readonly Looper _renderLooper;

                protected Bitmap Bitmap { get; set; }

                private BitmapSence Sence { get; set; }


                private bool isRendering = false;

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
                        if (isRendering)
                        {
                            return;    
                        }

                        Sence.Update(Bitmap);
                        Sence.Render();
                }


                
        }
}