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
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Components.Models;
using Nutshell.Data;
using Nutshell.Data.Models;
using Nutshell.Log;

namespace Nutshell.Components
{
        /// <summary>
        ///         工作者
        /// </summary>
        public abstract class Worker : StorableObject, IWorker
        {
                protected Worker(IdentityObject parent, string id = "")
                        : base(parent,id)
                {
                        IsEnable = true;
                }

                #region 字段

                private bool _isEnable;
                private bool _isStarted;

                #endregion

                #region 属性

                /// <summary>
                ///         是否启用
                /// </summary>
                public bool IsEnable
                {
                        get { return _isEnable; }
                        set
                        {
                                _isEnable = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                ///         是否已启动
                /// </summary>
                public virtual bool IsStarted
                {
                        get { return _isStarted; }
                        private set
                        {
                                if (value == _isStarted)
                                {
                                        return;
                                }
                                _isStarted = value;
                                OnPropertyChanged();

                                if (_isStarted)
                                {
                                        OnStartSuccessed(null);
                                }
                                else
                                {
                                        OnStopSuccessed(null);
                                }
                        }
                }

                #endregion

                public override void Load([MustAssignableFrom(typeof(IWorkerModel))]IDataModel model)
                {
                        base.Load(model);

                        var workerModel = model as IWorkerModel;
                        IsEnable = workerModel.IsEnable;
                }


                public override void Save([MustAssignableFrom(typeof(IWorkerModel))]IDataModel model)
                {
                        base.Save(model);

                        var workerModel = model as IWorkerModel;
                        workerModel.IsEnable = IsEnable;
                }


                /// <summary>
                ///         启动
                /// </summary>
                /// <remarks>
                /// </remarks>
                public bool Start()
                {
                        if (!IsEnable)
                        {
                                this.Warn("启用状态：否");

                                IsStarted = false;
                                OnStartFailed(null);
                                return IsStarted;
                        }

                        if (IsStarted)
                        {
                                return true;
                        }

                        try
                        {
                                IsStarted = StartCore();
                        }
                        catch (Exception e)
                        {
                                IsStarted = false;

                                this.Fatal(e);
                                OnStartFailed(null);
                        }

                        return IsStarted;
                }


                /// <summary>
                ///         停止
                /// </summary>
                public bool Stop()
                {
                        if (!IsEnable)
                        {
                                this.Warn("启用状态：否");
                                return true;
                        }

                        if (!IsStarted)
                        {
                                return true;
                        }

                        try
                        {
                                IsStarted = !StopCore();
                        }
                        catch (Exception e)
                        {
                                this.Fatal(e);
                                OnStopFailed(null);
                        }

                        return !IsStarted;
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
                ///         Occurs when [opened].
                /// </summary>
                [Description("启动成功事件")]
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
                public event EventHandler<EventArgs> StartFailed;

                /// <summary>
                ///         Raises the <see cref="E:Opened" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
                protected virtual void OnStartFailed(EventArgs e)
                {
                        e.Raise(this, ref StartFailed);
                }

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
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