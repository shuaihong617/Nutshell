// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-10-24
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-10-24
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

namespace Nutshell.Components
{
	/// <summary>
	///         工作状态枚举
	/// </summary>
	public enum WorkerState
	{
		/// <summary>
		/// 未启动
		/// </summary>
		未启动 = 0,


		/// <summary>
		///         启动中
		/// </summary>
		启动中 = 1,

		/// <summary>
		///         已启动
		/// </summary>
		已启动 = 2,

		/// <summary>
		///         停止中
		/// </summary>
		停止中 = 3,

		/// <summary>
		///         已停止
		/// </summary>
		已停止 = 4
	}
}