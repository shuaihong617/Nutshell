// ***********************************************************************
// 作者           : shuaihong617@qq.com
// 创建           : 2016-10-30
//
// 编辑           : shuaihong617@qq.com
// 日期           : 2016-11-11
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Models;
using Nutshell.Components;
using Nutshell.Storaging;

namespace Nutshell.Automation
{
	/// <summary>
	///         设备
	/// </summary>
	public abstract class Device : Component
	{
		/// <summary>
		///         初始化<see cref="Device" />的新实例.
		/// </summary>
		/// <param name="id">The identifier.</param>
		protected Device(string id = "")
			: base(id)
		{
		}

		#region 属性

		/// <summary>
		///         制造信息
		/// </summary>
		public ManufacturingInformation ManufacturingInformation { get; set ; }

		#endregion 属性

		#region 方法

		#region 存储

		

		#endregion 存储

		#endregion 方法
	}
}