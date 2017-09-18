using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nutshell.Automation.DaHeng.Sdk;

namespace Nutshell.Automation.DaHeng.WinFormUI
{
        public partial class MainForm : Form
        {
                private const string StartTitle = "开始";
                private const string StopTitle = "停止";

                private readonly GraphicsCard _graphicsCard = new GraphicsCard(1);


                private Thread _thread;
                private bool _isThreadWork = true;

                private Bitmap _bitmap = new Bitmap(GraphicsCard.Width, GraphicsCard.Height, PixelFormat.Format32bppRgb);
                private readonly Rectangle _rect = new Rectangle(0, 0, GraphicsCard.Width, GraphicsCard.Height);

                private Graphics _graphics;

                public MainForm()
                {
                        InitializeComponent();
                }

                private void MainForm_Load(object sender, EventArgs e)
                {
                        Card1RadioButton.Checked = true;
                        Camera1RadioButton.Checked = true;

                        _graphics = MainPictureBox.CreateGraphics();
                }

                private void StartButton_Click(object sender, EventArgs e)
                {
                        if (StartButton.Text == StartTitle)
                        {
                                StartButton.Text = StopTitle;

                                _graphicsCard.StartConnect();
                                _graphicsCard.SetVideoSource(0);

                                _thread = new Thread(Work);
                                _thread.Priority = ThreadPriority.Highest;

                                _isThreadWork = true;
                                _thread.Start();
                        }
                        else
                        {
                                StartButton.Text = StartTitle;

                                _isThreadWork = false;

                                _graphicsCard.StopConnect();
                        }
                }

                private unsafe void Work()
                {
                        for (;;)
                        {
                                if (!_isThreadWork)
                                {
                                     break;   
                                }

                                //采集
                                var isSuccess = _graphicsCard.CaptureOneFrameSync();
                                if (!isSuccess)
                                {
                                        return;
                                }

                                //传输到显示缓冲区
                                var bmpData =
                                    _bitmap.LockBits(_rect, ImageLockMode.ReadWrite, _bitmap.PixelFormat);

                                var sourcePtr = (byte*)_graphicsCard.CaptureFrameBuffer.ToPointer();
                                var targetPtr = (byte*)bmpData.Scan0.ToPointer();
                                for (int i = 0; i < GraphicsCard.FieldBufferSize; i++)
                                {
                                       var t  = *sourcePtr++;

                                        *targetPtr++ = t;
                                        *targetPtr++ = t;
                                        *targetPtr++ = t;
                                        *targetPtr++ = 0;
                                }
                                _bitmap.UnlockBits(bmpData);

                                //显示
                                _graphics.DrawImageUnscaled(_bitmap, 0, 0);

                                Thread.Sleep(10); 

                                Trace.WriteLine(DateTime.Now);
                        }
                }

                private void BrightnessTrackBar_ValueChanged(object sender, EventArgs e)
                {
                        BrightnessLabel.Text = BrightnessTrackBar.Value.ToString();
                }

                private void ContrastTrackBar_ValueChanged(object sender, EventArgs e)
                {
                        ContrastLabel.Text = ContrastTrackBar.Value.ToString();
                }

                private void CardsRadioButton_CheckedChanged(object sender, EventArgs e)
                {

                }

                private void CamerasRadioButton_CheckedChanged(object sender, EventArgs e)
                {

                }
        }
}
