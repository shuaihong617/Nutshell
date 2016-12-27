// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-10-30
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-12-28
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************
using Nutshell.Aspects.Locations.Contracts;

namespace Nutshell.Automation
{
	/// <summary>
	/// 间接控制设备
	/// </summary>
	public abstract class IndirectControlDevice:ControllableDevice
        {
		/// <summary>
		/// 初始化<see cref="ControllableDevice" />的新实例.
		/// </summary>
		/// <param name="parent">The parent.</param>
		/// <param name="id">The identifier.</param>
		protected IndirectControlDevice([MustNotEqualNull]IdentityObject parent, 
						[MustNotEqualNull]string id = null)
                        : base(parent, id)
                {
                }
        }
}
