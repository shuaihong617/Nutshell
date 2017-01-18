using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Nutshell.Speech.Microsoft.WPFUI
{
	/// <summary>
	/// SynthesisPage.xaml 的交互逻辑
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

                        //取第一句话作为默认文件名
		        var segments = content.Split(new char[]
		        {
		                ',','，',
                                '.','。',
                                ';','；',
                                ':','：',
                                '!','！',
                                '?','?',
                        }, StringSplitOptions.RemoveEmptyEntries);
		        var title = segments.FirstOrDefault();

		        SaveFileDialog dialog = new SaveFileDialog()
		        {
                                AddExtension = true,
                                CheckFileExists = false,
                                CheckPathExists = true,
                                DefaultExt = ".wav",
                                FileName = title+".wav",
                                Filter = "Wav音频文件|*.wav",
                                Title = "保存音频文件"
		        };

		        if (dialog.ShowDialog().GetValueOrDefault(false))
		        {
                                _gm.Synthesizer.OutputMode = OutputMode.文件;
                                _gm.Synthesizer.SpeakAsync(content, dialog.FileName);
		        }
                        

			
		}
	}
}
