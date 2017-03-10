using System;
using System.ComponentModel;
using System.Windows;

namespace Nutshell.Drawing.Imaging.WPFUI
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
