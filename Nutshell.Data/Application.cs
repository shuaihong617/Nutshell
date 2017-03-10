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

using System;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data.Models;

namespace Nutshell.Data
{
	/// <summary>
	///         封装应用程序标识
	/// </summary>
	public class Application : StorableObject, IStorable<IApplicationModel>
	{
		public Application(string id = "")
			: base(id)
		{
		}

		/// <summary>
		///         获取应用程序名称
		/// </summary>
		/// <value>应用程序名称</value>
		[MustNotEqualNullOrEmpty]
		public string Name { get; private set; }

		/// <summary>
		///         获取版本
		/// </summary>
		/// <value>版本</value>
		[MustNotEqualEmptyVersion]
		public Version Version { get; private set; }

		/// <summary>
		///         获取应用程序标题
		/// </summary>
		/// <value>应用程序标题</value>
		[MustNotEqualNullOrEmpty]
		public string Title { get; private set; }

		/// <summary>
		///         获取公司
		/// </summary>
		/// <value>公司</value>
		[MustNotEqualNullOrEmpty]
		public string Company { get; private set; }

		/// <summary>
		///         获取版权信息
		/// </summary>
		/// <value>版权信息</value>
		[MustNotEqualNullOrEmpty]
		public string CopyRight { get; private set; }

                /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">读取数据的源数据模型，该数据模型不能为空引用</param>
		public void Load(IApplicationModel model)
		{
			base.Load(model);

			Name = model.Name;
			Version = Version.Parse(model.Version);
			Title = model.Title;
			Company = model.Company;
			CopyRight = model.CopyRight;

		}

		public void Save(IApplicationModel model)
		{
		}
	}
}