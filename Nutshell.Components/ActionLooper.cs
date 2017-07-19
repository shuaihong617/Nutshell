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
using System.Threading;
using Nutshell.Aspects.Events;
using Nutshell.Extensions;

namespace Nutshell.Components
{
        /// <summary>
        ///         循环工作者
        /// </summary>
        public class ActionLooper : Looper
        {
                public ActionLooper(string id, Action repeat)
                        : this(id, ThreadPriority.Normal, 1000, repeat)
                {
                }

                public ActionLooper(string id, int interval, Action repeat)
                        : this(id, ThreadPriority.Normal, interval, repeat)
                {
                }

                public ActionLooper(string id, ThreadPriority priority, int interval, Action repeat)
                        : base(id, priority, interval)
                {
                        _repeat = repeat;
                }

                #region 字段

                private readonly Action _repeat;

                #endregion 字段

                protected override void RepeatWork()
                {
                        _repeat();
                        OnRepeatFinshed(EventArgs.Empty);
                }

                #region 事件

                /// <summary>
                ///         当启动时发生。
                /// </summary>
                [Description("启动事件")]
                [LogEventInvokeHandler]
                public event EventHandler<EventArgs> RepeatFinshed;

                /// <summary>
                ///         引发启动事件。
                /// </summary>
                /// <param name="e">包含事件数据的实例<see cref="EventArgs" /></param>
                protected virtual void OnRepeatFinshed(EventArgs e)
                {
                        e.Raise(this, ref RepeatFinshed);
                }

                #endregion 事件
        }
}