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
using Nutshell.Extensions;

namespace Nutshell.Components
{
        /// <summary>
        ///         循环工作者
        /// </summary>
        public class FuncLooper<T> : Looper
        {
                public FuncLooper(string id, Func<T> repeat)
                        : this(id, ThreadPriority.Normal, 1000, repeat)
                {
                }

                public FuncLooper(string id, int interval, Func<T> repeat)
                        : this(id, ThreadPriority.Normal, interval, repeat)
                {
                }

                public FuncLooper(string id, ThreadPriority priority, int interval, Func<T> repeat)
                        : base(id, priority, interval)
                {
                        _repeat = repeat;
                }

                #region 字段

                private readonly Func<T> _repeat;

                #endregion 字段

                protected override void RepeatWork()
                {
                        var t = _repeat();
                        OnRepeatFinshed(new ValueEventArgs<T>(t));
                }

                #region 事件

                /// <summary>
                ///         当启动时发生。
                /// </summary>
                [Description("启动事件")]
                public event EventHandler<ValueEventArgs<T>> RepeatFinshed;

                /// <summary>
                ///         引发启动事件。
                /// </summary>
                /// <param name="e">包含事件数据的实例<see cref="EventArgs" /></param>
                protected virtual void OnRepeatFinshed(ValueEventArgs<T> e)
                {
                        e.Raise(this, ref RepeatFinshed);
                }

                #endregion 事件
        }
}