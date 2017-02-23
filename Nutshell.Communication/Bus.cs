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

using System;
using System.Collections.Generic;
using Nutshell.Communication.Models;
using Nutshell.Components;
using Nutshell.Data;
using Nutshell.Messaging;
using Nutshell.Serializing;

namespace Nutshell.Communication
{
        /// <summary>
        /// 总线
        /// </summary>
        public abstract class Bus:Worker,IBus
        {
                protected Bus(string id = null) 
                        : base( id)
                {
                }

		private readonly Dictionary<string, object> _serializers = new Dictionary<string, object>();

		private ISite _site;

		public void Load(IBusModel model)
		{
			throw new System.NotImplementedException();
		}

		public void Save(IBusModel model)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// 注册消息类型所用的序列化器
		/// </summary>
		/// <param name="category">消息类型</param>
		/// <param name="serializer">序列化器</param>
		public void RegisterSerializer<T>(string category, ISerializer<T> serializer) where T : IMessage
		{
			_serializers[category] = serializer;
		}

		/// <summary>
		/// 发送消息
		/// </summary>
		/// <param name="message">待发送的消息</param>
		public void Send(IMessage message)
		{
			dynamic serializer = _serializers[message.Category];
			var btyes = serializer.Serialize(message);
			_site.Send(btyes);
		}

		#region 事件

		/// <summary>
		/// 当消息接收成功时发生。
		/// </summary>
		public event EventHandler<ValueEventArgs<IMessage>> ReceiveSuccessed;

		/// <summary>
		/// 当消息成功接收时发生
		/// </summary>
		/// <param name="e">包含消息的事件参数</param>
		/// <exception cref="System.NotImplementedException"></exception>
		protected virtual void OnReceiveSuccessed(ValueEventArgs<IMessage> e)
		{
			e.Raise(this, ref ReceiveSuccessed);
		}

		#endregion
	}
}
