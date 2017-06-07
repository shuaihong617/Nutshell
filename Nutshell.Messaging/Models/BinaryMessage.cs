namespace Nutshell.Messaging.Models
{
        public abstract class BinaryMessage:MessageModel
        {
                public byte[] Buffer { get; protected set; }
        }
}
