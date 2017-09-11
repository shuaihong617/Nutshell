// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-01-19
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-01-19
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

namespace Nutshell.YiDingRobot.Commanding
{
	/// <summary>
    /// 电池响应命令
    /// </summary>
	public class BatteryResponseCommand:ResponseCommand
	{
		public byte Percent { get; set; }
		public byte ChargeStatus { get; set; }
	}
}