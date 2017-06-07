using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutshell.Messaging
{
        public abstract class MessageFilter
        {
                protected readonly Dictionary<string, object> Serializers = new Dictionary<string, object>();
        }
}
