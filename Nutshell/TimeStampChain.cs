// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-10-28
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-12-23
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;

namespace Nutshell
{
	/// <summary>
	///         时间戳链，用于跟踪其附着的对象状态变更的时间
	/// </summary>
	public class TimeStampChain
	{
	        public TimeStampChain()
	        {
	                CreateTime = DateTime.Now;
	        }

	        public DateTime CreateTime { get; private set; }
	}
}
