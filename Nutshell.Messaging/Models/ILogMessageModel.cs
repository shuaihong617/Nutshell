﻿// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-11-08
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-11-08
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Logging;

namespace Nutshell.Messaging.Models
{
	/// <summary>
	///         日志消息数据模型接口
	/// </summary>
	public interface ILogMessageModel : IMessageModel
	{
		LogLevel LogLevel { get; set; }

		[MustNotEqualNullOrEmpty]
		string Content { get; set; }
	}
}