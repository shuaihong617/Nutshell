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
using System.ComponentModel;
using Nutshell.Aspects.Events;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data.Models;
using Nutshell.Log;

namespace Nutshell.Data
{
	/// <summary>
	///         封装应用程序标识
	/// </summary>
	public class Application : StorableObject,IApplication,IStorable<IApplicationModel>
	{
		public Application([MustNotEqualNullOrEmpty] string id = null)
			: base(null, id)
		{
		}

	        public void Load(IApplicationModel model)
	        {
	                base.Load(model);
	        }

	        public void Save(IApplicationModel model)
	        {
	                base.Save(model);
	        }
	}
}