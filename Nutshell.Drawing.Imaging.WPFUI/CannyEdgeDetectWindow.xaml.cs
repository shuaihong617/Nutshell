using AForge.Imaging.Filters;
using Nutshell.Extensions;
using System.Windows;

namespace Nutshell.Drawing.Imaging.WPFUI
{
        /// <summary>
        /// RuntimePage.xaml 的交互逻辑
        /// </summary>
        public partial class CannyEdgeDetectWindow
        {
                public CannyEdgeDetectWindow()
                {
                        InitializeComponent();
                }

                private readonly GlobalManager _gm = GlobalManager.Instance;

                private void Window_Loaded(object sender, RoutedEventArgs e)
                {
                        DataContext = _gm;
                }

                private void AcceptButton_Click(object sender, RoutedEventArgs e)
                {
                        if (_gm.SourceBitmap == null)
                        {
                                MessageBox.Show("NO SourcePicture");
                                return;
                        }

                        var low = LowThresholdTextBox.Text.Trim().ToByte();
                        var high = HighThresholdTextBox.Text.Trim().ToByte();

                        CannyEdgeDetector filter = new CannyEdgeDetector(low, high);
                        _gm.CannyBitmap = filter.Apply(_gm.SourceBitmap);

                        PictureBox.Width = _gm.CannyBitmap.Width;
                        PictureBox.Height = _gm.CannyBitmap.Height;
                        PictureBox.Image = _gm.CannyBitmap;
                }
        }
}