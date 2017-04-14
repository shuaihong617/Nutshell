using System.Windows;
using System.Windows.Controls;
using Nutshell.RabbitMQForOpc.WPFUI;

namespace Nutshell.RabbitMQForOpc.WPFUI
{
        /// <summary>
        ///         SynthesisPage.xaml 的交互逻辑
        /// </summary>
        public partial class DataPage : Page
        {
                private readonly GlobalManager _gm = GlobalManager.Instance;

                public DataPage()
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