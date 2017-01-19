using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Nutshell.Speech.Microsoft.WPFUI
{
	/// <summary>
	///         SynthesisPage.xaml 的交互逻辑
	/// </summary>
	public partial class SynthesisPage : Page
	{
		private readonly GlobalManager _gm = GlobalManager.Instance;

		public SynthesisPage()
		{
			InitializeComponent();
		}

		private void PlayButton_Click(object sender, RoutedEventArgs e)
		{
			var content = MainTextBox.Text.Trim();
			_gm.Synthesizer.SynthesizeAsync(content);
		}

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			var content = MainTextBox.Text.Trim();

			var myInvalidChars = new char[]
			{
				',', '，',
				'.', '。',
				';', '；',
				':', '：',
				'!', '！',
				'?', '?',
				'、', '、'
			};

			var allInvalid = myInvalidChars.Union(Path.GetInvalidFileNameChars()).ToArray();

			//取第一句话作为默认文件名
			var segments = content.Split(allInvalid, StringSplitOptions.RemoveEmptyEntries);
			var title = segments.FirstOrDefault();

			var dir = "输出";
			if (!Directory.Exists(dir))
			{
				Directory.CreateDirectory(dir);
			}

			var now = DateTime.Now.ToChineseLongFileName();

			var fileName = Path.Combine(dir, now + title + ".wav");
				_gm.Synthesizer.OutputMode = OutputMode.文件;
			_gm.Synthesizer.SynthesizeAsync(content, fileName);
		}
	}
}
