using System.Text;
using System.Xml.Linq;
using Nutshell.Serializing.Xml;

namespace Nutshell.Messaging
{
        public class XmlMessageFilter : MessageFilter
        {
                public virtual void Fitting(byte[] messageData)
                {
                        var encoding = new UTF8Encoding();
                        var messageString = encoding.GetString(messageData, 0, messageData.Length);
                        var doc = XDocument.Parse(messageString);
                        var root = doc.Root;
                        var type = root.Element("Type");

                        //XmlSerializer<T>.Instance.Deserialize(messageData);
                }
        }
}
