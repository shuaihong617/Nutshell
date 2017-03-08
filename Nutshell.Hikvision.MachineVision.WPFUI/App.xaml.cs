using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Nutshell.Logging;
using Nutshell.Logging.KernelLogging;

namespace Nutshell.Hikvision.MachineVision.WPFUI
{
	/// <summary>
	///         App.xaml 的交互逻辑
	/// </summary>
	public partial class App
	{
		private readonly GlobalManager _gm = GlobalManager.Instance;
		private Mutex _mutex;

		public App()
		{
			NLoger.Instance.Separate();

			//AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
			//DispatcherUnhandledException += Application_DispatcherUnhandledException;
		}

		private void Application_Startup(object sender, StartupEventArgs e)
		{
			_gm.LoadApplication();
			if (string.IsNullOrEmpty(_gm.Application.Id))
			{
				MessageBox.Show("应用程序令牌加载失败, 请联系软件发行方以协助改进这个问题, 非常感谢！");
				Shutdown();
				return;
			}

			bool isNotEixst;
			_mutex = new Mutex(true, _gm.Application.Id, out isNotEixst);

			if (!isNotEixst)
			{
				MessageBox.Show("应用程序 " + _gm.Application.Id + " 已运行！");
				Shutdown();
				return;
			}

			var window = new MainWindow();
			window.Closed += MainWindow_Closed;
			window.Show();
		}

		private void MainWindow_Closed(object sender, EventArgs e)
		{
			Current.Shutdown();
		}

		private void Application_DispatcherUnhandledException(object sender,
			DispatcherUnhandledExceptionEventArgs e)
		{
			LogProvider.Instance.Fatal(e.Exception);
			MessageBox.Show("当前应用程序发生了一个不曾预料的错误, 操作无法继续, 请联系软件发行方以协助改进这个问题, 非常感谢！");

			Current.Shutdown();
		}

		private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			LogProvider.Instance.Fatal((Exception) e.ExceptionObject);
			MessageBox.Show("当前应用程序发生了一个不曾预料的错误, 操作无法继续, 请联系软件发行方以协助改进这个问题, 非常感谢！");

			Current.Shutdown();
		}
	}
}