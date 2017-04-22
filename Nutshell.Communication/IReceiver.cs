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
using Nutshell.Messaging;
using Nutshell.Messaging.Models;

namespace Nutshell.Communication
{
	/// <summary>
	///         接收器接口
	/// </summary>
	public interface IReceiver<T> : IActor<T> where T : MessageModel
        {
		#region 事件

		/// <summary>
		///         当数据接收成功时发生。
		/// </summary>
		[Description("数据接收成功事件")]
		[LogEventInvokeHandler]
		event EventHandler<ValueEventArgs<T>> ReceiveSuccessed;

		/// <summary>
		///         当数据接收失败时发生。
		/// </summary>
		[Description("数据接收失败事件")]
		[LogEventInvokeHandler]
		event EventHandler<ValueEventArgs<Exception>> ReceiveFailed;

		#endregion
	}
}
