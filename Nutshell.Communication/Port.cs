using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Components;
using Nutshell.Serializing;

namespace Nutshell.Communication
{
        /// <summary>
        /// 通讯上下文接口
        /// </summary>
        public abstract class Port:Worker,IPort
        {
                protected Port(IdentityObject parent, string id = null, [MustNotEqualNull]ISerializer serializer= null) 
                        : base(parent, id)
                {
                        Serializer = serializer;
                }

                /// <summary>
                /// 获取序列化器，该序列化器用来序列化或反序列化通讯的消息
                /// </summary>
                /// <value>序列化器</value>
                [MustNotEqualNull]
                public ISerializer Serializer { get; private set; }                
        }
}
