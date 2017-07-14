using Nutshell.Extensions;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Nutshell.RabbitMQ.Messaging.Models;

namespace Nutshell.RabbitMQ.WPFUI
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

                private void SendButton_Click(object sender, RoutedEventArgs e)
                {
	                var messageModel = new RabbitMQMultiStringKeyValuePairsMessageModel()
	                {
		                Id = Guid.NewGuid().ToString(),
		                RoutingKey = "S1200Write",
	                };
                        messageModel.Add("一号包车运动授权请求", true);
			_gm.Sender.Send(messageModel);
                }

                private void SaveButton_Click(object sender, RoutedEventArgs e)
                {
                        
                }
        }
}