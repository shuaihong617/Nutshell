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

namespace Nutshell.Components
{
        /// <summary>
        /// 可调试接口
        /// </summary>b
        public interface IDebuggable
        {
                /// <summary>
                /// 获取调试模式
                /// </summary>
                /// <value>调试模式</value>
                RunMode RunMode { get; }
        }
}