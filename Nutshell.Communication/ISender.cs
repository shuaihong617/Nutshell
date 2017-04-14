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
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Messaging;
using Nutshell.Messaging.Models;

namespace Nutshell.Communication
{
	/// <summary>
	/// 发送器接口
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <seealso cref="Nutshell.Communication.IActor{T}" />
	public interface ISender<T> : IActor<T> where T:IMessageModel
	{
		

		/// <summary>
		///         发送字节数组数据
		/// </summary>
		/// <param name="messageModel">待发送消息数据</param>
		void Send([MustNotEqualNull]T messageModel);

		#region 事件

		/// <summary>
		///         当数据发送成功时发生。
		/// </summary>
		[Description("数据发送成功事件")]
		[LogEventInvokeHandler]
		event EventHandler<ValueEventArgs<T>> SendSuccessed;

		/// <summary>
		///         当数据发送失败时发生。
		/// </summary>
		[Description("数据发送失败事件")]
		[LogEventInvokeHandler]
		event EventHandler<ValueEventArgs<Exception>> SendFailed;

		#endregion
	}
}
