using System;
using System.ComponentModel;
using System.Windows;

namespace Nutshell.Automation.Opc.WPFUI
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
                        try
                        {
                                _gm.Start();
                        }
                        catch (Exception)
                        {
                                MessageBox.Show("应用程序 " + _gm.Application.Id + " 加载数据失败, 请联系软件发行方以协助改进这个问题, 非常感谢！");
                                Close();
                                return;
                        }

                        DataContext = _gm;
                }

                private void MainWindow_OnClosing(object sender, CancelEventArgs e)
                {
                        _gm.Stop();
                }
        }
}
