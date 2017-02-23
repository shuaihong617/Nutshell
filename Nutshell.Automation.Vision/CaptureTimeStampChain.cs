// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-08-04
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-08-04
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;

namespace Nutshell.Automation.Vision
{
	/// <summary>
	///         采集时间戳
	/// </summary>
	public class CaptureTimeStampChain : TimeStampChain
	{
		public CaptureTimeStampChain()
		{
			CaptureTime = DateTime.Now;
		}

		public DateTime CaptureTime { get; set; }
	}
}
