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
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Components.Models;
using Nutshell.Data;
using Nutshell.Log;

namespace Nutshell.Components
{
        /// <summary>
        ///         调度者
        /// </summary>
        public abstract class Dispatcher : StorableObject, IDispatcher
        {
                protected Dispatcher(IdentityObject parent, string id = null)
                        : base(parent, id)
                {
                        IsEnable = true;
                }

                #region 字段

                /// <summary>
                ///         线程同步标识
                /// </summary>
                private readonly object _syncFlag = new object();

                private DisptachState _disptachState;

                #endregion

                #region 属性

                /// <summary>
                ///         获取是否启用
                /// </summary>
                /// <value>如果启用则返回True，否则返回False</value>
                public bool IsEnable { get; set; }

                /// <summary>
                ///         获取调试模式
                /// </summary>
                /// <value>调试模式</value>
                public DebugMode DebugMode { get; private set; }

                /// <summary>
                ///         获取调度状态
                /// </summary>
                /// <value>调度状态</value>
                [WillNotifyPropertyChanged]
                public DisptachState DisptachState
                {
                        get { return _disptachState; }
                        private set
                        {
                                if (_disptachState == value)
                                {
                                        return;
                                }

                                var oldValue = _disptachState;
                                var newValue = value;

                                _disptachState = newValue;

                                switch (newValue)
                                {
                                        case DisptachState.Started:
                                                switch (oldValue)
                                                {
                                                        case DisptachState.Starting:
                                                                OnStartSuccessed(EventArgs.Empty);
                                                                break;

                                                        case DisptachState.Stoping:
                                                                OnStopFailed(EventArgs.Empty);
                                                                break;
                                                }
                                                break;

                                        case DisptachState.Stoped:
                                                switch (oldValue)
                                                {
                                                        case DisptachState.Starting:
                                                                OnStartFailed(EventArgs.Empty);
                                                                break;

                                                        case DisptachState.Stoping:
                                                                OnStopSuccessed(EventArgs.Empty);
                                                                break;
                                                }
                                                break;
                                }
                        }
                }

                #endregion

                /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">数据模型</param>
                public void Load(IDispatcherModel model)
                {
                        base.Load(model);

                        IsEnable = model.IsEnable;
                }

                /// <summary>
                ///         保存数据到数据模型
                /// </summary>
                /// <param name="model">数据模型</param>
                /// <returns>成功返回True, 否则返回False</returns>
                public void Save(IDispatcherModel model)
                {
                        base.Save(model);

                        model.IsEnable = IsEnable;
                }


                /// <summary>
                ///         启动
                /// </summary>
                /// <remarks>
                /// </remarks>
                public bool Start()
                {
                        lock (_syncFlag)
                        {
                                DisptachState = DisptachState.Starting;

                                if (!IsEnable)
                                {
                                        this.Warn("启用状态：否");

                                        DisptachState = DisptachState.Stoped;
                                        return false;
                                }

                                if (DisptachState == DisptachState.Started)
                                {
                                        return true;
                                }

                                var result = false;
                                try
                                {
                                        result = StartCore();
                                }
                                catch (Exception e)
                                {
                                        DisptachState = DisptachState.Stoped;
                                        result = false;
                                        this.Fatal(e);
                                }

                                return result;
                        }
                }


                /// <summary>
                ///         停止
                /// </summary>
                public bool Stop()
                {
                        lock (_syncFlag)
                        {
                                if (!IsEnable)
                                {
                                        this.Warn("启用状态：否");
                                        return false;
                                }

                                if (DisptachState == DisptachState.Stoped)
                                {
                                        return true;
                                }

                                var result = false;
                                try
                                {
                                        result = StopCore();
                                }
                                catch (Exception e)
                                {
                                        this.Fatal(e);
                                        result = false;
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
                protected abstract bool StartCore();

                /// <summary>
                ///         执行退出过程的具体步骤.
                /// </summary>
                /// <returns>成功返回True, 否则返回False.</returns>
                /// <remarks>
                ///         若退出过程有多个步骤,执行尽可能多的步骤, 以保证尽量清理现场.
                /// </remarks>
                protected abstract bool StopCore();

                #region 事件

                /// <summary>
                /// 当启动时发生。
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
                public event EventHandler<ValueEventArgs<Exception>> StartFailed;

                /// <summary>
                ///         Raises the <see cref="E:Opened" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
                protected virtual void OnStartFailed(ValueEventArgs<Exception> e)
                {
                        e.Raise(this, ref StartFailed);
                }


                public event EventHandler<EventArgs> Stoping;
                public event EventHandler<ValueEventArgs<Exception>> Stoped;

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                public event EventHandler<EventArgs> StopSuccessed;

                event EventHandler<ValueEventArgs<Exception>> IDispatcher.StopFailed
                {
                        add { throw new NotImplementedException(); }
                        remove { throw new NotImplementedException(); }
                }

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
                ///         Occurs when [opened].
                /// </summary>
                public event EventHandler<EventArgs> StopFailed;

                /// <summary>
                ///         Raises the <see cref="E:Opened" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
                protected virtual void OnStopFailed(EventArgs e)
                {
                        this.InfoEvent("停止失败");
                        e.Raise(this, ref StopFailed);
                }

                #endregion
        }
}