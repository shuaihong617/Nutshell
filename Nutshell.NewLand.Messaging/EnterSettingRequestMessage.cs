using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutshell.Messaging;
using Nutshell.Messaging.Models;

namespace Nutshell.NewLand.Messaging
{
        public class EnterSettingRequestMessage:BinaryMessage
        {
                public EnterSettingRequestMessage()
                {
                        Buffer = Encoding.ASCII.GetBytes("$$$$");
                }
        }
}
