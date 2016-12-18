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

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Messaging;

namespace Nutshell.Communication
{
        /// <summary>
        /// 发送端口接口
        /// </summary>
        public interface ISendPort:IPort
        {
                /// <summary>
                /// 获取发送者
                /// </summary>
                /// <value>发送者</value>
                [MustNotEqualNull]
                ISender Sender { get; }

                /// <summary>
                /// 发送消息
                /// </summary>
                /// <param name="message">待发送的消息</param>
                void Send(IMessage message);
                
        }
}
