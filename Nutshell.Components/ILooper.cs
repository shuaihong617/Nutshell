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

using System.Threading;
using Nutshell.Components.Models;
using Nutshell.Data;

namespace Nutshell.Components
{
        /// <summary>
        ///         循环工作者接口
        /// </summary>
        public interface ILooper : IWorker,IStorable<ILooperModel>
        {
                /// <summary>
                /// 获取循环调度线程优先级
                /// </summary>
                /// <value>循环调度线程优先级</value>
                ThreadPriority Priority { get; }

                /// <summary>
                /// 获取循环调度间隔时间
                /// </summary>
                /// <value>循环调度间隔事件</value>
                int Interval { get; set; }
        }
}