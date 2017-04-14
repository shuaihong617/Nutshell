// ***********************************************************************
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

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Models;
using Nutshell.Components;
using Nutshell.Data;
using Nutshell.Extensions;
using Nutshell.Threading;
using System;
using System.ComponentModel;
using Nutshell.Storaging;

namespace Nutshell.Automation
{
        /// <summary>
        ///         采集设备
        /// </summary>
        public abstract class CapturableDevice<T> : DispatchableDevice, IStorable<ICapturableDeviceModel> where T : IIdentifiable
        {
                /// <summary>
                ///         初始化<see cref="T:CaptureDevice" />的新实例.
                /// </summary>
                /// <param name="id">The key.</param>
                protected CapturableDevice(string id = "")
                        : base(id)
                {
                        CaptureLooper = new Looper(String.Empty, Capture);
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

                public Looper CaptureLooper { get; private set; }

                #endregion 属性

                #region 方法

                #region 存储

                /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">读取数据的源数据模型，该数据模型不能为null</param>
                public void Load([MustNotEqualNull]ICapturableDeviceModel model)
                {
                        base.Load(model);
                }

                /// <summary>
                ///         保存数据到数据模型
                /// </summary>
                /// <param name="model">写入数据的目的数据模型，该数据模型不能为null</param>
                public void Save(ICapturableDeviceModel model)
                {
                        throw new NotImplementedException();
                }

                #endregion 存储

                protected override Result StartDispatchCore()
                {
                        if (Pool == null)
                        {
                                Pool = CreatePool();
                                Pool.Parent = this;
                        }

                        return Result.Successed;
                }

                protected abstract ReadWritePool<T> CreatePool();

                /// <summary>
                ///         连接
                /// </summary>
                /// <returns>操作结果</returns>
                public Result StartCaptureLoop()
                {
                        lock (_lockFlag)
                        {
                                if (CaptureLooper.WorkerState == WorkerState.已启动)
                                {
                                        return Result.Successed;
                                }

                                if (!IsEnable)
                                {
                                        this.Warn("未启用");
                                        return Result.Failed;
                                }

                                return CaptureLooper.Start();
                        }
                }

                /// <summary>
                ///         断开连接
                /// </summary>
                /// <returns>操作结果</returns>
                public Result StopCaptureLoop()
                {
                        lock (_lockFlag)
                        {
                                if (CaptureLooper.WorkerState == WorkerState.已停止)
                                {
                                        return Result.Successed;
                                }

                                if (!IsEnable)
                                {
                                        this.Warn("未启用");
                                        return Result.Successed;
                                }

                                return CaptureLooper.Stop();
                        }
                }

                protected Result Capture()
                {
                        var t = CaptureCore();
                        if (t != null && t.IsSuccessed)
                        {
                                OnCaptureSuccessed(new ValueEventArgs<T>(t.Value));
                        }
                        return t;
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