﻿// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-01-15
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-01-15
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.ComponentModel;
using System.Diagnostics;
using Nutshell.Automation.Models;
using Nutshell.Components;
using Nutshell.Data.Models;
using Nutshell.Extensions;
using Nutshell.Threading;

namespace Nutshell.Automation
{
        /// <summary>
        ///         采集设备
        /// </summary>
        public abstract class CapturableDevice<T> : DispatchableDevice where T : IIdentifiable
        {
                /// <summary>
                ///         初始化<see cref="T:CaptureDevice" />的新实例.
                /// </summary>
                /// <param name="id">The key.</param>
                protected CapturableDevice(string id = "")
                        : base(id)
                {
                        CaptureLooper = new FuncLooper<T>(string.Empty, Capture);
                        CaptureLooper.Parent = this;
                }

                #region 字段

                /// <summary>
                ///         线程同步标识
                /// </summary>
                private readonly object _lockFlag = new object();

                #endregion 字段

                #region 属性

                /// <summary>
                ///         图像池
                /// </summary>
                public ReadWritePool<T> Pool { get; private set; }

                public Looper CaptureLooper { get; }

                #endregion 属性

                #region 方法

                #region 存储

                /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">读取数据的源数据模型，该数据模型不能为空引用.</param>
                public override void Load(IIdentityModel model)
                {
                        base.Load(model);

                        var subModel = model as CapturableDeviceModel;
                        Trace.Assert(subModel != null);

                        CaptureLooper.Load(subModel.CaptureLooperModel);
                }

                #endregion 存储

                protected override bool StartDispatchCore()
                {
                        if (Pool == null)
                        {
                                Pool = CreatePool();
                                Pool.Parent = this;
                        }

                        return true;
                }

                protected abstract ReadWritePool<T> CreatePool();

                /// <summary>
                ///         连接
                /// </summary>
                /// <returns>操作结果</returns>
                public bool StartCaptureLoop()
                {
                        lock (_lockFlag)
                        {
                                if (CaptureLooper.WorkerState == WorkerState.已启动)
                                {
                                        return true;
                                }

                                if (!IsEnable)
                                {
                                        this.Warn("未启用");
                                        return false;
                                }

                                return CaptureLooper.Start();
                        }
                }

                /// <summary>
                ///         断开连接
                /// </summary>
                /// <returns>操作结果</returns>
                public bool StopCaptureLoop()
                {
                        lock (_lockFlag)
                        {
                                if (CaptureLooper.WorkerState == WorkerState.已停止)
                                {
                                        return true;
                                }

                                if (!IsEnable)
                                {
                                        this.Warn("未启用");
                                        return false;
                                }

                                return CaptureLooper.Stop();
                        }
                }

                public T Capture()
                {
                        var t = CaptureCore();
                        if (t != null && t.IsSuccessed)
                        {
                                OnCaptureSuccessed(new ValueEventArgs<T>(t.Value));
                                return t.Value;
                        }

                        return default(T);
                }

                protected abstract ValueResult<T> CaptureCore();

                #endregion 方法

                #region 事件

                /// <summary>
                ///         Occurs when [snaped].
                /// </summary>
                [Description("采集成功")]
                //[LogEventInvokeHandler]
                public event EventHandler<ValueEventArgs<T>> CaptureSuccessed;

                /// <summary>
                ///         Called when [capture successed].
                /// </summary>
                /// <param name="e">The e.</param>
                protected virtual void OnCaptureSuccessed(ValueEventArgs<T> e)
                {
                        //this.InfoEventRaise("采集成功");
                        e.Raise(this, ref CaptureSuccessed);
                }

                #endregion 事件
        }
}