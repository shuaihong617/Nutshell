using Microsoft.Win32;
using System.ComponentModel;
using System.Drawing;
using System.Windows;

namespace Nutshell.Drawing.Imaging.WPFUI
{
        /// <summary>
        ///         MainWindow.xaml 的交互逻辑
        /// </summary>
        public partial class MainWindow
        {
                private readonly GlobalManager _gm = GlobalManager.Instance;

                public MainWindow()
                {
                        InitializeComponent();
                }

                private void Window_OnLoaded(object sender, RoutedEventArgs e)
                {
                        DataContext = _gm;
                }

                private void Window_OnClosing(object sender, CancelEventArgs e)
                {
                }

                private void LoadBitmapButton_Click(object sender, RoutedEventArgs e)
                {
                        OpenFileDialog dialog = new OpenFileDialog();
                        dialog.DefaultExt = ".bmp"; // Default file extension
                        dialog.Filter = "位图文件 (.bmp)|*.bmp"; // Filter files by extension

                        if (!dialog.ShowDialog().GetValueOrDefault(false))
                        {
                                return;
                        }

                        _gm.SourceBitmap = new Bitmap(dialog.FileName);

                        PictureBox.Width = _gm.SourceBitmap.Width;
                        PictureBox.Height = _gm.SourceBitmap.Height;
                        PictureBox.Image = _gm.SourceBitmap;
                }

                private void CannyEdgeButton_Click(object sender, RoutedEventArgs e)
                {
                        var window = new CannyEdgeDetectWindow();
                        window.Show();
                }

                private void FeedbackButton_Click(object sender, RoutedEventArgs e)
                {
                }

                private void AboutButton_Click(object sender, RoutedEventArgs e)
                {
                        var window = new AboutWindow();
                        window.Owner = this;
                        window.ShowDialog();
                }
        }
}