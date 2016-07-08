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
using System.Threading.Tasks;
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
                public Looper(IdentityObject parent, Action work)
                        : this(parent, String.Empty, work)
                {
                }

                public Looper(IdentityObject parent, string id = "", Action work = null, int interval = 1000)
                        : base(parent, id)
                {
                        _work = work;
                        Interval = interval;
                }

                #region 字段

                private readonly Action _work;

                private bool _isTaskRuning;

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
                        _isTaskRuning = true;
                        Task.Run(() =>
                        {
                                this.Info("循环启动,周期",Interval,"毫秒");
                                for (;;)
                                {
                                        _work();

                                        Thread.Sleep(Interval);

                                        if (!_isTaskRuning)
                                        {
                                                this.Info("循环停止");
                                                break;
                                        }
                                }
                        });

                        return true;
                }

                protected override bool StopCore()
                {
                        _isTaskRuning = false;

                        //_workTask.Wait();

                        //_workTask.Dispose();
                        //_workTask = null;


                        return true;
                }
        }
}