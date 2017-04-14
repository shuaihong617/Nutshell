using Nutshell.Data.Models;
using Nutshell.Storaging.Models;

namespace Nutshell.Serializing.Binary
{
        public class BinarySerializer<T> : Serializer<T> where T : IDataModel
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