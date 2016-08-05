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
using Nutshell.Components.Models;
using Nutshell.Data.Models;
using Nutshell.Log;

namespace Nutshell.Components
{
        /// <summary>
        ///         循环工作者
        /// </summary>
        public class Looper : Worker
        {
                public Looper(IdentityObject parent, Action action)
                        : this(parent, 1000, action)
                {
                }

                public Looper(IdentityObject parent, string id, Action action)
                        : this(parent, id, ThreadPriority.Normal, 1000, action)
                {

                }

                public Looper(IdentityObject parent, int interval, Action action)
                        : this(parent, String.Empty, interval, action)
                {
                }

                public Looper(IdentityObject parent, string id, int interval, Action action)
                        : this(parent, id, ThreadPriority.Normal,  interval, action)
                {
                       
                }

                public Looper(IdentityObject parent, string id, ThreadPriority priority, int interval, Action action)
                        : base(parent, id)
                {
                        _action = action;
                        Interval = interval;

                        _thread = new Thread(ThreadWork);
                        _thread.Priority = priority;
                }

                #region 字段

                private readonly Thread _thread;

                private bool _isWork;

                private readonly Action _action;

                #endregion

                public int Interval { get; private set; }

                public override void Load(IStorableModel model)
                {
                        model.MustNotNull();
                        

                        base.Load(model);

                        var looperModel = model as LooperModel;
                        Trace.Assert(looperModel != null);

                        Trace.Assert(looperModel.Interval > 0);
                        Interval = looperModel.Interval;
                }

                protected override bool StartCore()
                {
                        _isWork = true;

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