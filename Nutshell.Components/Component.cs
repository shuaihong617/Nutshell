// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-05-11
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-05-14
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Components.Models;

namespace Nutshell.Components
{
	/// <summary>
	///         组件
	/// </summary>
	public abstract class Component : RunableObject, IComponent
	{
		#region 构造函数

		protected Component(string id = null)
			: base(id)
		{
		}

		#endregion

		#region 属性

		/// <summary>
		///         制造信息
		/// </summary>
		[MustNotEqualNull]
		public IManufacturingInformation ManufacturingInformation { get; set; }

		#endregion

		#region 方法

		public void Load([MustNotEqualNull] IComponentObjectModel model)
		{
			base.Load(model);
		}

		/// <summary>
		///         保存数据到数据模型
		/// </summary>
		/// <param name="model">写入数据的目的数据模型，该数据模型不能为null</param>
		public void Save([MustNotEqualNull] IComponentObjectModel model)
		{
			base.Save(model);
		}

		#endregion
	}
}