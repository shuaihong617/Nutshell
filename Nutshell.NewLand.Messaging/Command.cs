using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutshell.Messaging.Models;

namespace Nutshell.NewLand.Messaging
{
        public class Command
        {
                public static readonly byte Dollor = Encoding.ASCII.GetBytes("$")[0];
        }
}
