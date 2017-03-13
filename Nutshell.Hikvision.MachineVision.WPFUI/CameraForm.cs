using Nutshell.Automation.Vision;
using Nutshell.Direct2D.WinForm.Vision;
using Nutshell.Drawing.Imaging;
using System;
using System.Windows.Forms;

namespace Nutshell.Hikvision.MachineVision.WPFUI
{
        public partial class CameraForm : Form
        {
                private readonly GlobalManager _gm = GlobalManager.Instance;
                public CameraDecoder Decoder { get; private set; }

                public CameraSence Sence { get; private set; }

                public CameraRenderer Renderer { get; private set; }

                public CameraForm()
                {
                        InitializeComponent();
                }

                private void CameraForm_Load(object sender, EventArgs e)
                {
                        Width = _gm.Camera.Width + 40;
                        Height = _gm.Camera.Height + 40;

                        CameraPictureBox.Width = _gm.Camera.Width;
                        CameraPictureBox.Height = _gm.Camera.Height;

                        Decoder = new CameraDecoder("1号液位解码单元", _gm.Camera, PixelFormat.Bgra32);

                        Sence = new CameraSence("1号液位场景单元", CameraPictureBox, _gm.Camera);

                        Renderer = new CameraRenderer("1号液位显示单元", Decoder, Sence);

                        Decoder.Start();
                        Renderer.Start();
                }
        }
}