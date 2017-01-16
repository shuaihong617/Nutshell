// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-04-14
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-04-14
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************


using Nutshell.Components.Models;

namespace Nutshell.Automation.OPC.Models
{
	/// <summary>
	///         已定义主键的xmlOPC服务器数据模型
	/// </summary>
	public interface IOpcServerModel : IDispatchableComponentModel
	{
		/// <summary>
		///         名称
		/// </summary>
		string Name { get; set; }

		/// <summary>
		///         名称
		/// </summary>
		string Address { get; set; }
	}
}