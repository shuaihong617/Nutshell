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

namespace Nutshell.Messaging
{
        /// <summary>
        ///         消息接口
        /// </summary>
        public interface IMessage
        {
                /// <summary>
                ///         时间
                /// </summary>
                /// <value>The time.</value>
                DateTime Time { get; }
        }
}