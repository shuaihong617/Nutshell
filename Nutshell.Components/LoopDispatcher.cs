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
using System.Diagnostics;
using System.Threading;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Components.Models;
using Nutshell.Data.Models;
using Nutshell.Log;

namespace Nutshell.Components
{
        /// <summary>
        ///         循环调度者
        /// </summary>
        public class LoopDispatcher : Dispatcher,ILoopDispatcher
        {
                public LoopDispatcher(IdentityObject parent, string id, Action action)
                        : this(parent, id, ThreadPriority.Normal, 1000, action)
                {

                }

                public LoopDispatcher(IdentityObject parent, string id, int interval, Action action)
                        : this(parent, id, ThreadPriority.Normal,  interval, action)
                {
                       
                }

                public LoopDispatcher(IdentityObject parent, string id, ThreadPriority priority, int interval, Action action)
                        : base(parent, id)
                {
                        Priority = priority;
                        Interval = interval;
                        _action = action;

                        
                }

                #region 字段

                private Thread _thread;

                private bool _isWork;

                private readonly Action _action;

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

                public void Load([MustNotEqualNull]ILoopDispatcherModel model)
                {
                        
                        base.Load(model);

                        Priority = model.Priority;
                        Interval = model.Interval;
                }

                public void Save([MustNotEqualNull]ILoopDispatcherModel model)
                {
                        throw new NotImplementedException();
                }

                protected override bool StartCore()
                {
                        _isWork = true;

                        _thread = new Thread(ThreadWork) {Priority = Priority};
                        _thread.Start();

                        return true;
                }

                private void ThreadWork()
                {
                        this.Info("循环启动,周期", Interval, "毫秒");
                        for (; ; )
                        {
                                _action();

                                Thread.Sleep(Interval);

                                if (!_isWork)
                                {
                                        this.Info("循环停止");
                                        break;
                                }
                        }
                }

                protected override bool StopCore()
                {
                        _isWork = false;

                        return true;
                }
        }
}