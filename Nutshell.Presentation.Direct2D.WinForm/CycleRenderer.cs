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

                        SencePool = new Pool<BufferSence>(this, "场景池");
                }

                private Pool<BufferSence> SencePool; 

                private readonly Looper _renderLooper;

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