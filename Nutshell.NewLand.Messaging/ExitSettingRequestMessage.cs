using System.Text;
using Nutshell.Messaging;
using Nutshell.Messaging.Models;

namespace Nutshell.NewLand.Messaging
{
        public class ExitSettingRequestMessage : BinaryMessage
        {
                public ExitSettingRequestMessage()
                {
                        Buffer = Encoding.ASCII.GetBytes("%%%%");
                }
        }
}
