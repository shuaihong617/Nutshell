// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-09-05
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-09-05
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data.Models;
using Nutshell.Storaging.Models;

namespace Nutshell.Messaging.Models
{
	/// <summary>
	///         消息接口
	/// </summary>
	public interface IMessageModel : IDataModel
	{
		/// <summary>
		///         获取消息的类型
		/// </summary>
		/// <value>消息类型</value>
		[MustNotEqualNullOrEmpty]
		string Category { get; set; }
	}
}