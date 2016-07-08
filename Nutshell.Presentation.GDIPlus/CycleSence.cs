using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Nutshell.Components;

namespace Nutshell.Presentation.GDIPlus
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