using Nutshell.Serializing;

namespace Nutshell.Communication
{
        /// <summary>
        /// 通讯上下文接口
        /// </summary>
        public interface IPort
        {
                /// <summary>
                /// 获取序列化器，该序列化器用来序列化或反序列化通讯的消息
                /// </summary>
                /// <value>序列化器</value>
                ISerializer Serializer { get; }
        }
}
