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
using Nutshell.Data.Xml.Models;
using Nutshell.Messaging.Models;
using Nutshell.Storaging.Xml.Models;

namespace Nutshell.Messaging.Xml.Models
{
	/// <summary>
	///         Xml格式的消息
	/// </summary>
	[XmlType]
	public class XmlMessageModel : XmlDataModel, IMessageModel
	{
		/// <summary>
		///         获取消息的类型
		/// </summary>
		/// <value>消息类型</value>
		[XmlAttribute]
		[MustNotEqualNullOrEmpty]
		public string Category { get; set; }
	}
}