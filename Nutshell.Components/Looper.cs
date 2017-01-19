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
using System.Diagnostics;
using System.Threading;
using Nutshell.Aspects.Events;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Components.Models;
using Nutshell.Data.Models;
using Nutshell.Extensions;
using Nutshell.Logging.KernelLogging;

namespace Nutshell.Components
{
        /// <summary>
        ///         循环工作者
        /// </summary>
        public abstract class Looper : Worker,ILooper
        {
                protected Looper(IIdentityObject parent, string id)
                        : this(parent, id, ThreadPriority.Normal, 1000)
                {

                }

                protected Looper(IIdentityObject parent, string id, int interval)
                        : this(parent, id, ThreadPriority.Normal,  interval)
                {
                       
                }

                protected Looper(IIdentityObject parent, string id, ThreadPriority priority, int interval)
                        : base(parent, id)
                {
                        Priority = priority;
                        Interval = interval;
                }

                #region 字段

                private Thread _thread;

                private bool _isRequestWork;

                #endregion

                /// <summary>
                /// 获取循环调度线程优先级
                /// </summary>
                /// <value>循环调度线程优先级</value>
                [WillNotifyPropertyChanged]
                public ThreadPriority Priority { get; private set; }

                /// <summary>
                /// 获取循环调度间隔时间
                /// </summary>
                /// <value>循环调度间隔事件</value>
                [MustGreaterThanOrEqual(0)]
                [WillNotifyPropertyChanged]
                public int Interval { get; set; }

                public void Load([MustNotEqualNull]ILooperModel model)
                {
                        
                        base.Load(model);

                        Priority = model.Priority;
                        Interval = model.Interval;
                }

                public void Save([MustNotEqualNull]ILooperModel model)
                {
                        throw new NotImplementedException();
                }

                protected override IResult Starup(IWorkContext context)
                {
                        _isRequestWork = true;

                        _thread = new Thread(ThreadWork) {Priority = Priority};
                        _thread.Start();

                        return Result.Successed;
                }

                private void ThreadWork()
                {
                        this.Info("循环启动,周期", Interval, "毫秒");
                        for (; ; )
                        {
                                var result = RepeatWork();
                                OnRepeatWorkFinshed(new ValueEventArgs<IResult>(result));

                                Thread.Sleep(Interval);

                                if (!_isRequestWork)
                                {
                                        this.Info("循环停止");
                                        break;
                                }
                        }
                }

                protected override IResult Clean(IWorkContext context)
                {
                        _isRequestWork = false;

                        return Result.Successed;
                }

                protected abstract IResult RepeatWork();

                #region 事件

                /// <summary>
                ///         当启动时发生。
                /// </summary>
                [Description("启动事件")]
                [WillLogEventInvokeHandler]
                public event EventHandler<ValueEventArgs<IResult>> RepeatWorkFinshed;

                /// <summary>
                ///         引发启动事件。
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
                protected virtual void OnRepeatWorkFinshed(ValueEventArgs<IResult> e)
                {
                        e.Raise(this, ref RepeatWorkFinshed);
                }

                #endregion

        }
}