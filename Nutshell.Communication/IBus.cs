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
using System.ComponentModel;
using Nutshell.Aspects.Events;
using Nutshell.Communication.Models;
using Nutshell.Components;
using Nutshell.Data;
using Nutshell.Messaging;
using Nutshell.Serializing;

namespace Nutshell.Communication
{
	/// <summary>
	///         总线接口
	/// </summary>
	public interface IBus : IWorker,IStorable<IBusModel>
	{
		/// <summary>
		/// 注册消息类型所用的序列化器
		/// </summary>
		/// <typeparam name="T">消息泛型</typeparam>
		/// <param name="category">消息类型</param>
		/// <param name="serializer">序列化器</param>
		void RegisterSerializer<T>(string category, ISerializer<T> serializer) where T : IMessage;

		/// <summary>
		/// 发送消息
		/// </summary>
		/// <param name="message">待发送的消息</param>
		void Send(IMessage message);

		#region 事件

		/// <summary>
		///         当消息接收成功时发生。
		/// </summary>
		[Description("消息接收成功事件")]
		[WillLogEventInvokeHandler]
		event EventHandler<ValueEventArgs<IMessage>> ReceiveSuccessed;

		#endregion
	}
}
