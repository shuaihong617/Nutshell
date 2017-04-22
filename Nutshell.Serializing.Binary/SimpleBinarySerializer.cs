using Nutshell.Storaging.Models;

namespace Nutshell.Serializing.Binary
{
        public class SimpleBinarySerializer<T> : BinarySerializer<T> where T : DataModel
        {
                public override byte[] Serialize(T t)
                {
                        throw new System.NotImplementedException();
                }

                public override T Deserialize(byte[] content)
                {
                        throw new System.NotImplementedException();
                }
        }
}