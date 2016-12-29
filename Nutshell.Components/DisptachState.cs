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
        ///         调度状态枚举
        /// </summary>
        public enum DisptachState
        {
                /// <summary>
                ///         已停止
                /// </summary>
                Stoped = 0,

                /// <summary>
                ///         正在开始
                /// </summary>
                Starting = 1,

                /// <summary>
                ///         已开始
                /// </summary>
                Started = 2,

                /// <summary>
                ///         正在停止
                /// </summary>
                Stoping = 3,
        }
}