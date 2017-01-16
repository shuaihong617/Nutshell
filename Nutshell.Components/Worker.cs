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
using Nutshell.Aspects.Events;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Components.Models;
using Nutshell.Data;
using Nutshell.Log;

namespace Nutshell.Components
{
        /// <summary>
        ///         工作者
        /// </summary>
        public abstract class Worker : StorableObject, IWorker
        {
                protected Worker(IIdentityObject parent,
                        [MustNotEqualNullOrEmpty] string id)
                        : base(parent, id)
                {
                }

                #region 字段

                /// <summary>
                ///         线程同步标识
                /// </summary>
                private readonly object _syncFlag = new object();

                #endregion

                #region 属性

                /// <summary>
                ///         获取调度状态
                /// </summary>
                /// <value>调度状态</value>
                [WillNotifyPropertyChanged]
                public WorkState WorkState { get; private set; }

                #endregion

                /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">数据模型</param>
                public void Load(IWorkerModel model)
                {
                        base.Load(model);
                }

                /// <summary>
                ///         保存数据到数据模型
                /// </summary>
                /// <param name="model">数据模型</param>
                /// <returns>成功返回True, 否则返回False</returns>
                public void Save(IWorkerModel model)
                {
                        base.Save(model);
                }

                /// <summary>
                ///         启动
                /// </summary>
                /// <returns>成功返回True，失败返回False.</returns>
                public IResult Start(IWorkContext context)
                {
                        lock (_syncFlag)
                        {
                                if (WorkState == WorkState.Started)
                                {
                                        return Result.Successed;
                                }

                                WorkState = WorkState.Starting;

                                if (!context.IsEnable)
                                {
                                        this.Warn("启用状态：否");

                                        WorkState = WorkState.Stoped;
                                        return new Result(new ArgumentException("启用状态：否"));
                                }


                                var result = Starup(context);

                                if (!result.IsSuccessed)
                                {
                                        WorkState = WorkState.Stoped;
                                        foreach (var exception in result.Exceptions)
                                        {
                                                this.Fatal(exception);
                                        }
                                }

                                return result;
                        }
                }


                /// <summary>
                ///         停止
                /// </summary>
                /// <returns>成功返回True，失败返回False.</returns>
                public IResult Stop(IWorkContext context)
                {
                        lock (_syncFlag)
                        {
                                if (WorkState == WorkState.Stoped)
                                {
                                        return Result.Successed;
                                }

                                if (!context.IsEnable)
                                {
                                        this.Warn("启用状态：否");
                                        return new Result(new ArgumentException("启用状态：否"));
                                        ;
                                }


                                var result = Clean(context);

                                if (!result.IsSuccessed)
                                {
                                        foreach (var exception in result.Exceptions)
                                        {
                                                this.Fatal(exception);
                                        }
                                }

                                return result;
                        }
                }

                /// <summary>
                ///         执行启动过程的具体步骤.
                /// </summary>
                /// <returns>成功返回True, 否则返回False.</returns>
                /// <remarks>
                ///         若启动过程有多个步骤, 遇到返回错误的步骤立即停止向下执行.
                /// </remarks>
                protected abstract IResult Starup([MustNotEqualNull] IWorkContext context);

                /// <summary>
                ///         执行退出过程的具体步骤.
                /// </summary>
                /// <returns>成功返回True, 否则返回False.</returns>
                /// <remarks>
                ///         若退出过程有多个步骤,执行尽可能多的步骤, 以保证尽量清理现场.
                /// </remarks>
                protected abstract IResult Clean([MustNotEqualNull] IWorkContext context);

                #region 事件

                /// <summary>
                ///         当启动时发生。
                /// </summary>
                [Description("启动事件")]
                [WillLogEventInvokeHandler]
                public event EventHandler<EventArgs> Starting;

                /// <summary>
                ///         引发启动事件。
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
                protected virtual void OnStarting(EventArgs e)
                {
                        e.Raise(this, ref Starting);
                }


                /// <summary>
                ///         当启动完成时发生。
                /// </summary>
                [Description("启动完成事件")]
                [WillLogEventInvokeHandler]
                public event EventHandler<ValueEventArgs<Exception>> Started;

                /// <summary>
                ///         引发启动事件。
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
                protected virtual void OnStarted(ValueEventArgs<Exception> e)
                {
                        e.Raise(this, ref Started);
                        if (e.Value == null)
                        {
                                OnStartSuccessed(EventArgs.Empty);
                        }
                        else
                        {
                                OnStartFailed(e);
                        }
                }

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                [Description("启动成功事件")]
                [WillLogEventInvokeHandler]
                public event EventHandler<EventArgs> StartSuccessed;

                /// <summary>
                ///         Raises the <see cref="E:Opened" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
                protected virtual void OnStartSuccessed(EventArgs e)
                {
                        e.Raise(this, ref StartSuccessed);
                }


                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                [Description("启动失败事件")]
                [WillLogEventInvokeHandler]
                public event EventHandler<ValueEventArgs<Exception>> StartFailed;

                /// <summary>
                ///         Raises the <see cref="E:Opened" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
                protected virtual void OnStartFailed(ValueEventArgs<Exception> e)
                {
                        e.Raise(this, ref StartFailed);
                }

                /// <summary>
                ///         当停止时发生。
                /// </summary>
                [Description("停止事件")]
                [WillLogEventInvokeHandler]
                public event EventHandler<EventArgs> Stoping;

                /// <summary>
                ///         当停止完成时发生。
                /// </summary>
                [Description("停止完成事件")]
                [WillLogEventInvokeHandler]
                public event EventHandler<ValueEventArgs<Exception>> Stoped;


                /// <summary>
                ///         当停止成功时发生。
                /// </summary>
                [Description("停止成功事件")]
                [WillLogEventInvokeHandler]
                public event EventHandler<EventArgs> StopSuccessed;


                /// <summary>
                ///         Raises the <see cref="E:Opened" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
                protected virtual void OnStopSuccessed(EventArgs e)
                {
                        this.InfoEvent("停止成功");
                        e.Raise(this, ref StopSuccessed);
                }

                /// <summary>
                ///         当停止失败时发生。
                /// </summary>
                [Description("停止失败事件")]
                [WillLogEventInvokeHandler]
                public event EventHandler<ValueEventArgs<Exception>> StopFailed;

                /// <summary>
                ///         Raises the <see cref="E:Opened" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
                protected virtual void OnStopFailed(ValueEventArgs<Exception> e)
                {
                        this.InfoEvent("停止失败");
                        e.Raise(this, ref StopFailed);
                }

                #endregion
        }
}