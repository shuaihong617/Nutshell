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
using Nutshell.Components.Models;
using Nutshell.Data;

namespace Nutshell.Components
{
        /// <summary>
        ///         工作上下文
        /// </summary>
        public abstract class WorkContext : IWorkContext
        {

		/// <summary>
		/// 获取是否启用
		/// </summary>
		/// <value>是否启用</value>
		public bool IsEnable { get; private set; }

	        /// <summary>
	        /// 获取调试模式
	        /// </summary>
	        /// <value>调试模式</value>
	        public RunMode RunMode { get; private set; }
        }
}