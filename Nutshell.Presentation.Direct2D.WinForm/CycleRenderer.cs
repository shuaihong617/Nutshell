using System.Windows.Forms;
using Nutshell.Components;
using Nutshell.Threading;

namespace Nutshell.Presentation.Direct2D.WinForm
{
        public  abstract class CycleRenderer:IdentityObject
        {
                protected CycleRenderer(IdentityObject parent, string id = "", Control control = null)
                        : base(parent, id)
                {
                        _renderLooper = new Looper(this, "显示循环", Render, 50);

                }

                private readonly Looper _renderLooper;

                private Sence ForgroundSence { get; set; }

                private Sence BackroundSence { get; set; }

                public void Start()
                {
                        _renderLooper.Start();
                }

                public void Stop()
                {
                        _renderLooper.Stop();
                }

                protected virtual void Render()
                {
                        
                }

        }
}