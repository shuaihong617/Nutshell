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

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Nutshell.Messaging;
using Nutshell.Serializing;

namespace Nutshell.Communication
{
        /// <summary>
        /// 发送者接口
        /// </summary>
        public class SendExchanger : Exchanger, ISendExchanger
        {

                public SendExchanger(IdentityObject parent, string id = null) 
                        : base(parent, id)
                {
                }

		private Dictionary<string, ISendPort> _sendPorts = new Dictionary<string, ISendPort>(); 

                /// <summary>
                /// 获取发送端口集合
                /// </summary>
                /// <value>发送端口集合</value>
                public ReadOnlyCollection<ISendPort> SendPorts { get; private set; }

	        public void AddSendPort(ISendPort sendPort)
	        {
		        
	        }


                protected override bool StartCore()
                {
                        throw new System.NotImplementedException();
                }

                protected override bool StopCore()
                {
                        throw new System.NotImplementedException();
                }

                /// <summary>
                /// 发送消息
                /// </summary>
                /// <param name="message">待发送的消息</param>
                public void Send(IMessage message)
                {
                        SendPorts[0].Send(message);
                }

                

                
        }
}
