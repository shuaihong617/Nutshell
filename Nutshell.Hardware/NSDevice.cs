// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-05-11
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-05-14
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Diagnostics;
using Nutshell.Components;
using Nutshell.Data;
using Nutshell.Data.Models;
using Nutshell.Hardware.Models;
using Nutshell.Log;

namespace Nutshell.Hardware
{
        /// <summary>
        ///         设备
        /// </summary>
        public abstract class NSDevice : Worker,INSDevice
        {
                #region 构造函数

                protected NSDevice(IdentityObject parent, string id = "")
                        : base(parent,id)
                {
                        NSRunMode = NSRunMode.Release;
                }

                #endregion

                #region 字段

                private bool _isOpened;
                private bool _isOnline;

                #endregion

                #region 属性

                public NSRunMode NSRunMode { get; private set; }

                /// <summary>
                ///         设备是否已打开
                /// </summary>
                public bool IsOpened
                {
                        get { return _isOpened; }
                        private set
                        {
                                if (value == _isOpened)
                                {
                                        return;
                                }
                                _isOpened = value;
                                RaisePropertyChanged();
                        }
                }

                /// <summary>
                ///         是否在线
                /// </summary>
                public bool IsOnline
                {
                        get { return _isOnline; }
                        private set
                        {
                                if (value == _isOnline)
                                {
                                        return;
                                }
                                _isOnline = value;
                                RaisePropertyChanged();

                                if (IsOnline)
                                {
                                        OnOnlined(null);
                                }
                                else
                                {
                                        OnOfflined(null);
                                }
                        }
                }

                #endregion

                #region 方法

                public override void Load(IStorableModel model)
                {
                        base.Load(model);

                        var deviceModel = model as DeviceModel;
                        deviceModel.MustNotNull();

                        NSRunMode = deviceModel.NSRunMode;
                }

                protected override sealed bool StartCore()
                {
                        return Open();
                }

                protected override sealed bool StopCore()
                {
                        return Close();
                }

                protected bool Open()
                {
                        if (IsOpened)
                        {
                                return true;
                        }

                        this.Info("运行状态：" + NSRunMode);

                        IsOpened = OpenCore();
                        return IsOpened;
                }

                protected abstract bool OpenCore();

                protected bool Close()
                {
                        if (!IsOpened)
                        {
                                return true;
                        }
                        IsOpened = !CloseCore();
                        return !IsOpened;
                }

                protected abstract bool CloseCore();

                protected void Online()
                {
                        IsOnline = true;
                }

                protected void Offline()
                {
                        IsOnline = false;
                }

                #endregion

                #region 事件

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                public event EventHandler<EventArgs> Onlined;

                /// <summary>
                ///         Raises the <see cref="E:Opened" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnOnlined(EventArgs e)
                {
                        this.InfoEvent("上线");
                        e.Raise(this, ref Onlined);
                }

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                public event EventHandler<EventArgs> Offlined;

                /// <summary>
                ///         Raises the <see cref="E:Opened" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnOfflined(EventArgs e)
                {
                        this.InfoEvent("离线");
                        e.Raise(this, ref Offlined);
                }

                /// <summary>
                ///         Occurs when [closed].
                /// </summary>
                protected event EventHandler<EventArgs> OnlineTestFailed;

                /// <summary>
                ///         引发 <see cref="E:Closed" /> 事件.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnOnlineTestFailed(EventArgs e)
                {
                        //Close();
                        e.Raise(this, ref OnlineTestFailed);
                }

                #endregion
        }
}