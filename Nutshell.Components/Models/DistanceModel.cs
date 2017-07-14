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
using Nutshell.Data.Models;

namespace Nutshell.Components.Models
{
	/// <summary>
	///         距离数据模型
	/// </summary>
	
	public class DistanceModel:IdentityModel
	{
		
		public float Accuracy { get; set; }

		/// <summary>
		///         Gets the standard value.
		/// </summary>
		/// <value>The standard value.</value>
		
		public float Standard { get; set; }
	}
}
