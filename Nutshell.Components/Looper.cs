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

using System.Diagnostics;
using System.Threading;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Components.Models;
using Nutshell.Data.Models;
using Nutshell.Extensions;

namespace Nutshell.Components
{
        /// <summary>
        ///         循环工作者抽象基类
        /// </summary>
        public abstract class Looper : Worker
        {
                protected Looper(string id, ThreadPriority priority, int interval)
                        : base(id)
                {
                        Priority = priority;
                        Interval = interval;
                }

                #region 字段

                private Thread _thread;

                private bool _isContinue;

                #endregion 字段

                #region 属性

                /// <summary>
                ///         获取循环调度线程优先级
                /// </summary>
                /// <value>循环调度线程优先级</value>
                [NotifyPropertyValueChanged]
                public ThreadPriority Priority { get; private set; }

                /// <summary>
                ///         获取循环调度间隔时间
                /// </summary>
                /// <value>循环调度间隔事件</value>
                [MustGreaterThanOrEqual(0)]
                [NotifyPropertyValueChanged]
                public int Interval { get; private set; }

                #endregion 属性

                public override void Load(IIdentityModel model)
                {
                        base.Load(model);

                        var subModel = model as LooperModel;
                        Trace.Assert(subModel != null);

                        Priority = subModel.Priority;
                        Interval = subModel.Interval;
                }

                protected override bool StartCore()
                {
                        _isContinue = true;

                        _thread = new Thread(ThreadWork) {Priority = Priority};
                        _thread.Start();

                        return true;
                }

                private void ThreadWork()
                {
                        this.Info($"循环启动,周期{Interval}毫秒");
                        for (;;)
                        {
                                RepeatWork();

                                Thread.Sleep(Interval);

                                if (!_isContinue)
                                {
                                        this.Info("循环停止");
                                        break;
                                }
                        }
                }

                protected abstract void RepeatWork();

                protected override bool StopCore()
                {
                        _isContinue = false;

                        return true;
                }
        }
}