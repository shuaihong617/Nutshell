// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-04-21
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-04-21
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳.. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Xml.Serialization;
using Nutshell.Storaging.Models;

namespace Nutshell.Components.Models
{
	/// <summary>
	///         限位数据模型
	/// </summary>
	[XmlType]
	public class LimiterModel:DataModel
	{
		/// <summary>
		///         Gets the mode.
		/// </summary>
		/// <value>The mode.</value>
		[XmlAttribute]
		public LimitMode Mode { get; set; }

		[XmlAttribute]
		public double Accuracy { get; set; }

		/// <summary>
		///         Gets the standard value.
		/// </summary>
		/// <value>The standard value.</value>
		[XmlAttribute]
		public double StandardValue { get; set; }
	}
}
