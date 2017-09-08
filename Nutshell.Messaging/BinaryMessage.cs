namespace Nutshell.Messaging
{
        public abstract class BinaryMessage:Message
        {
                public byte[] Buffer { get; protected set; }
        }
}
