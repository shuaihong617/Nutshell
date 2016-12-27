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

using System;

namespace Nutshell.Automation
{
        /// <summary>
        ///         控制模式枚举
        /// </summary>
        [Flags]
        public enum ControlMode
        {
                /// <summary>
                ///         未定义模式，在此模式下设备不工作
                /// </summary>
                Undefined = 0,

                /// <summary>
                ///         发布模式，在此模式下设备按实际工作方式运行，接受真实控制信号
                /// </summary>
                Release = 1,

                /// <summary>
                ///         调试模式，用于模拟测试或其他用途，接受模拟控制信号
                /// </summary>
                Debug = 2,

		/// <summary>
		///  所有模式，兼容调试模式和发布模式
		/// </summary>
		All = Release| Debug
        }
}