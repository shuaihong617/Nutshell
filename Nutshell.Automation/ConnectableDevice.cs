// ***********************************************************************
// 作者           : shuaihong617@qq.com
// 创建           : 2016-10-30
//
// 编辑           : shuaihong617@qq.com
// 日期           : 2016-11-11
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Aspects.Events;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Automation.Models;
using Nutshell.Data;
using Nutshell.Extensions;
using System;
using System.ComponentModel;
using Nutshell.Storaging;

namespace Nutshell.Automation
{
        /// <summary>
        ///         可连接组件
        /// </summary>
        public abstract class ConnectableDevice : Device, IStorable<ConnectableDeviceModel>
        {
                /// <summary>
                ///         初始化<see cref="ConnectableDevice" />的新实例.
                /// </summary>
                /// <param name="id">The identifier.</param>
                protected ConnectableDevice(string id = "")
                        : base(id)
                {
                        ConnectState = ConnectState.Disconnected;
                }

                #region 字段

                /// <summary>
                ///         线程同步标识
                /// </summary>
                private readonly object _lockFlag = new object();

                #endregion 字段

                #region 属性

                /// <summary>
                ///         获取连接状态
                /// </summary>
                /// <value>连接状态</value>
                [NotifyPropertyValueChanged]
                public ConnectState ConnectState { get; private set; }

                #endregion 属性

                #region 存储

                /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">读取数据的源数据模型，该数据模型不能为空引用</param>
                public void Load(ConnectableDeviceModel model)
                {
                        base.Load(model);
                }

                /// <summary>
                ///         保存数据到数据模型
                /// </summary>
                /// <param name="model">写入数据的目的数据模型，该数据模型不能为null</param>
                public void Save(ConnectableDeviceModel model)
                {
                        throw new NotImplementedException();
                }

                #endregion 存储

                /// <summary>
                /// 连接
                /// </summary>
                /// <returns>操作结果</returns>
                public bool StartConnect()
                {
                        lock (_lockFlag)
                        {
                                if (ConnectState == ConnectState.Connected)
                                {
                                        return true;
                                }

                                ConnectState = ConnectState.Connecting;

                                if (!IsEnable)
                                {
                                        this.Warn("未启用");

                                        ConnectState = ConnectState.Disconnected;
                                        return false;
                                }

                                var result = StartConnectCore();

                                ConnectState = result ? ConnectState.Connected : ConnectState.Disconnected;

                                return result;
                        }
                }

                protected virtual bool StartConnectCore()
                {
                        return true;
                }

                /// <summary>
                /// 断开连接
                /// </summary>
                /// <returns>操作结果</returns>
                public bool StopConnect()
                {
                        lock (_lockFlag)
                        {
                                if (ConnectState == ConnectState.Disconnected)
                                {
                                        return true;
                                }

                                ConnectState = ConnectState.Disconnecting;

                                if (!IsEnable)
                                {
                                        this.Warn("未启用");

                                        ConnectState = ConnectState.Disconnected;
                                        return true;
                                }

                                var result = StopConnectCore();

                                ConnectState = ConnectState.Disconnected;

                                return result;
                        }
                }

                protected virtual bool StopConnectCore()
                {
                        return true;
                }

                #region 事件

                [Description("连接成功")]
                [LogEventInvokeHandler]
                protected event EventHandler<EventArgs> ConnectSuccessed;

                /// <summary>
                ///         引发 <see cref="E:Opened" /> 事件.
                /// </summary>
                /// <param name="e">包含事件数据的实例<see cref="EventArgs" /></param>
                protected virtual void OnConnectSuccessed(EventArgs e)
                {
                        e.Raise(this, ref ConnectSuccessed);
                }

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                protected event EventHandler<EventArgs> ConnectFailed;

                /// <summary>
                ///         引发 <see cref="E:Opened" /> 事件.
                /// </summary>
                /// <param name="e">包含事件数据的实例<see cref="EventArgs" /></param>
                protected virtual void OnConnectFailed(EventArgs e)
                {
                        e.Raise(this, ref ConnectFailed);
                }

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                protected event EventHandler<EventArgs> DisconnectSuccessed;

                /// <summary>
                ///         引发 <see cref="E:Opened" /> 事件.
                /// </summary>
                /// <param name="e">包含事件数据的实例<see cref="EventArgs" /></param>
                protected virtual void OnDisconnectSuccessed(EventArgs e)
                {
                        e.Raise(this, ref DisconnectSuccessed);
                }

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                protected event EventHandler<EventArgs> DisconnectFailed;

                /// <summary>
                ///         引发 <see cref="E:Opened" /> 事件.
                /// </summary>
                /// <param name="e">包含事件数据的实例<see cref="EventArgs" /></param>
                protected virtual void OnDisconnectFailed(EventArgs e)
                {
                        e.Raise(this, ref DisconnectFailed);
                }

                /// <summary>
                ///         Occurs when [openCaptur].
                /// </summary>
                public event EventHandler<EventArgs> StartCaptured;

                /// <summary>
                ///         引发<see cref="E:OpenCaptur" />事件
                /// </summary>
                /// <param name="e">包含事件数据的实例<see cref="EventArgs" /></param>
                protected virtual void OnStartCaptured(EventArgs e)
                {
                        e.Raise(this, ref StartCaptured);
                }

                /// <summary>
                ///         Occurs when [openCaptur].
                /// </summary>
                public event EventHandler<EventArgs> StopCaptured;

                /// <summary>
                ///         引发<see cref="E:OpenCaptur" />事件
                /// </summary>
                /// <param name="e">包含事件数据的实例<see cref="EventArgs" /></param>
                protected virtual void OnStopCaptured(EventArgs e)
                {
                        e.Raise(this, ref StopCaptured);
                }

                #endregion 事件
        }
}