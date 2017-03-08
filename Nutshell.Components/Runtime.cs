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

using Nutshell.Aspects.Locations.Contracts;

namespace Nutshell.Components
{
	/// <summary>
	///         运行环境
	/// </summary>
	public abstract class Runtime : Worker
	{
		protected Runtime([MustNotEqualNullOrEmpty] string id)
			: base(id)
		{
		}
	}
}