using System.Windows;
using System.Windows.Controls;

namespace Nutshell.Hikvision.MachineVision.WPFUI
{
        /// <summary>
        ///         SynthesisPage.xaml 的交互逻辑
        /// </summary>
        public partial class ImagePage : Page
        {
                private readonly GlobalManager _gm = GlobalManager.Instance;

                public ImagePage()
                {
                        InitializeComponent();
                }

                private void PlayButton_Click(object sender, RoutedEventArgs e)
                {
                }

                private void SaveButton_Click(object sender, RoutedEventArgs e)
                {
                }
        }
}
