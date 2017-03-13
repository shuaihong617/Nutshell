using System.Windows;

namespace Nutshell.Hikvision.MachineVision.WPFUI
{
        /// <summary>
        ///         MainWindow.xaml 的交互逻辑
        /// </summary>
        public partial class AboutWindow
        {
                private readonly GlobalManager _gm = GlobalManager.Instance;

                public AboutWindow()
                {
                        InitializeComponent();
                }

                private void Window_OnLoaded(object sender, RoutedEventArgs e)
                {
                        DataContext = _gm;
                }
        }
}