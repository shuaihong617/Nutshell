namespace Nutshell.Messaging.Models
{
        public abstract class BinaryMessage:Message
        {
                public byte[] Buffer { get; protected set; }
        }
}
