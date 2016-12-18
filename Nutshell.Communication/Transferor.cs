// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-12-17
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-12-17
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Components;
using Nutshell.Serializing;

namespace Nutshell.Communication
{
        /// <summary>
        ///         转发器接口
        /// </summary>
        public abstract class Transferor : Worker, ITransferor
        {
                protected Transferor(IdentityObject parent, string id = null) 
                        : base(parent, id)
                {
                }

                /// <summary>
                ///         获取序列化器，该序列化器用来序列化或反序列化通讯的消息
                /// </summary>
                /// <value>序列化器</value>
                public ISerializer Serializer { get; private set; }
        }
}
