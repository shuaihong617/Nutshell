using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Nutshell.Messaging
{
        public abstract class BinaryMessageFilter:MessageFilter
        {
                public virtual void Fitting(byte[] messageData)
                {
                }
        }
}
