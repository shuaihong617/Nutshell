// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-12-20
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-12-23
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
using Nutshell.Components;

namespace Nutshell.Communication
{
	/// <summary>
	///         站点接口
	/// </summary>
	public interface ISite : IWorker
	{
		#region 发送部分

		/// <summary>
		///         获取或设置发送者
		/// </summary>
		/// <value>发送者</value>
		[MustNotEqualNull]
		ISender Sender { get; set; }

		/// <summary>
		///         发送字节数组数据
		/// </summary>
		/// <param name="data">待发送数据</param>
		void Send([MustNotEqualNull] byte[] data);

		#region 事件

		/// <summary>
		///         当数据发送成功时发生。
		/// </summary>
		[Description("数据发送成功事件")]
		[LogEventInvokeHandler]
		event EventHandler<EventArgs> SendSuccessed;

		/// <summary>
		///         当数据发送成功时发生。
		/// </summary>
		[Description("数据发送成功事件")]
		[LogEventInvokeHandler]
		event EventHandler<EventArgs> SendFailed;

		#endregion

		#endregion

		#region 接收部分

		/// <summary>
		///         获取或设置接收者
		/// </summary>
		/// <value>接收者</value>
		[MustNotEqualNull]
		IReceiver Receiver { get; set; }

		#region 事件

		/// <summary>
		///         当数据接收成功时发生。
		/// </summary>
		[Description("数据接收成功事件")]
		[LogEventInvokeHandler]
		event EventHandler<ValueEventArgs<byte[]>> ReceiveSuccessed;

		#endregion

		#endregion
	}
}
