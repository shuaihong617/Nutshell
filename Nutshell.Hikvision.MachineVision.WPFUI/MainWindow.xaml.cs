﻿using System;
using System.ComponentModel;
using System.Windows;
using Nutshell.Hikvision.MachineVision.WPFUI;
using Nutshell.Logging;

namespace Nutshell.Hikvision.MachineVision.WPFUI
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
			_gm.Start();
			//                    try
			//                    {
			//                            _gm.Start();
			//                    }
			//                    catch (Exception ex)
			//                    {
			//LogProvider.Instance.Fatal(ex);

			//MessageBox.Show("应用程序 " + _gm.Application.Id + " 加载数据失败, 请联系软件发行方以协助改进这个问题, 非常感谢！");
			//                            Close();
			//                            return;
			//                    }

			DataContext = _gm;
                }

                private void Window_OnClosing(object sender, CancelEventArgs e)
                {
                        _gm.Stop();
                }

		private void CameraImageButton_Click(object sender, RoutedEventArgs e)
		{
			var form = new CameraForm();
			form.ShowDialog();
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

		private void ImageButton_Click(object sender, RoutedEventArgs e)
		{
			MainFrame.Navigate(new Uri("ImagePage.xaml", UriKind.Relative));
		}

		private void RuntimeButton_Click(object sender, RoutedEventArgs e)
		{
			MainFrame.Navigate(new Uri("RuntimePage.xaml", UriKind.Relative));
		}

		private void LogButton_Click(object sender, RoutedEventArgs e)
		{
			MainFrame.Navigate(new Uri("LoggingPage.xaml", UriKind.Relative));
		}
	}
}
