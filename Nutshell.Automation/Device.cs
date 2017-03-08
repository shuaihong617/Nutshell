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

using System;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Models;
using Nutshell.Components;
using Nutshell.Data;

namespace Nutshell.Automation
{
	/// <summary>
	///         设备
	/// </summary>
	public abstract class Device : Component,IStorable<IDeviceModel>
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
		[MustNotEqualNull]
		public ManufacturingInformation ManufacturingInformation { get; set; }

		#endregion

		#region 方法

		#region 存储

		/// <summary>
		///         从数据模型加载数据
		/// </summary>
		/// <param name="model">读取数据的源数据模型，该数据模型不能为null</param>
		public void Load(IDeviceModel model)
		{
			base.Load(model);
		}

		/// <summary>
		///         保存数据到数据模型
		/// </summary>
		/// <param name="model">写入数据的目的数据模型，该数据模型不能为null</param>
		public void Save(IDeviceModel model)
		{
			throw new NotImplementedException();
		}

		#endregion

		#endregion


	}
}
