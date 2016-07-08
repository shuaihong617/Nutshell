using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FutureTech.Hardware;
using FutureTech.Media;

namespace FutureTech.Windows.Forms.Direct2D.Hardware
{
        public abstract class R8G8B8A8GrayCameraRender:CameraRender
        {
                protected R8G8B8A8GrayCameraRender(string key, Control control, Camera camera) 
                        : base(key, control, camera, ImageFormat.R8G8B8A8Gray)
                {
                }
        }
}
