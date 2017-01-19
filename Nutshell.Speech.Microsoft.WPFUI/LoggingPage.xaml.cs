using System.Windows;
using System.Windows.Controls;

namespace Nutshell.Speech.Microsoft.WPFUI
{
        /// <summary>
        ///         SynthesisPage.xaml 的交互逻辑
        /// </summary>
        public partial class LoggingPage : Page
        {
                private readonly GlobalManager _gm = GlobalManager.Instance;

                public LoggingPage()
                {
                        InitializeComponent();
                }
        }
}
