using System.Windows.Forms;
using Nutshell.Components;

namespace Nutshell.Presentation.Direct2D.WinForm
{
        public  abstract class CycleSence : BufferSence
        {
                protected CycleSence(IdentityObject parent, string id = "", Control control = null)
                        : base(parent, id, control)
                {
                        _renderLooper = new Looper(this, "采集循环", Render, 50);
                }

                private readonly Looper _renderLooper;

                public void Start()
                {
                        _renderLooper.Start();
                }

                public void Stop()
                {
                        _renderLooper.Stop();
                }
        }
}