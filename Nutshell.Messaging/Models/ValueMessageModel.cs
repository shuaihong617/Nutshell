// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-10-16
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-10-17
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Xml.Serialization;
using Nutshell.Aspects.Locations.Contracts;

namespace Nutshell.Messaging.Models
{
	/// <summary>
	///         值消息数据模型
	/// </summary>
	
	public class ValueMessage<T> : Message
	{
		
		[MustNotEqualNull]
		public T Value { get; set; }
	}
}