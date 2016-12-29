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

namespace Nutshell.Communication
{
	/// <summary>
	///         发送器接口
	/// </summary>
	public interface ISender : IActor
	{
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
		[WillLogEventInvokeHandler]
		event EventHandler<ValueEventArgs<Exception>> SendSuccessed;

		/// <summary>
		///         当数据发送失败时发生。
		/// </summary>
		[Description("数据发送失败事件")]
		[WillLogEventInvokeHandler]
		event EventHandler<ValueEventArgs<Exception>> SendFailed;

		#endregion
	}
}
