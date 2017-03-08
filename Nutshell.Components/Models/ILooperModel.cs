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

using System.Threading;
using Nutshell.Data.Models;

namespace Nutshell.Components.Models
{
        /// <summary>
        ///         循环工作者数据模型接口
        /// </summary>
        public interface ILooperModel:IWorkerModel
        {
                /// <summary>
                /// 获取循环调度线程优先级
                /// </summary>
                /// <value>循环调度线程优先级</value>
                ThreadPriority Priority { get; set; }

                /// <summary>
                /// 获取循环工作线程休眠时间间隔
                /// </summary>
                /// <value>循环工作线程休眠时间间隔，单位为毫秒</value>
                int Interval { get; set; }
        }
}