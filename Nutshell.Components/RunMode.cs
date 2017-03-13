﻿// ***********************************************************************

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
        ///         运行模式枚举
        /// </summary>
        public enum RunMode
        {
                /// <summary>
                ///         发布模式，在此模式下组件按实际工作方式运行，接受真实控制信号
                /// </summary>
                Release = 0,

                /// <summary>
                ///         运行模式，用于模拟测试或其他用途，接受模拟控制信号
                /// </summary>
                Debug = 1,
        }
}