// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-01-05
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-01-05
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;

namespace Nutshell.YiDingRobot
{
	/// <summary>
	///         SerialPort连接授权
	/// </summary>
	public class Authorization : IdentityObject
	{
		/// <summary>
		/// 获取校验模式
		/// </summary>
		/// <value>校验模式</value>
		public DateTime SystemTime { get; private set; }

		/// <summary>
		/// 获取数据位
		/// </summary>
		/// <value>数据位</value>
		public DateTime Deadline { get; private set; }
	}
}