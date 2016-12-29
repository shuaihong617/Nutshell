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
using Nutshell.Components.Models;
using Nutshell.Data;

namespace Nutshell.Components
{
        /// <summary>
        ///         调度者接口
        /// </summary>
        public interface IDispatcher : IStorable<IDispatcherModel>, IEnable, IDebuggable
        {
                /// <summary>
                ///         获取调度状态
                /// </summary>
                /// <value>调度状态</value>
                DisptachState DisptachState { get; }


                #region 属性

                /// <summary>
                /// 启动
                /// </summary>
                /// <returns>成功返回True，失败返回False.</returns>
                bool Start();

                /// <summary>
                ///         停止
                /// </summary>
                /// <returns>成功返回True，失败返回False.</returns>
                bool Stop();

                #endregion


                #region 事件

                /// <summary>
                ///         当启动时发生。
                /// </summary>
                [Description("启动事件")]
                [WillLogEventInvokeHandler]
                event EventHandler<EventArgs> Starting;

                /// <summary>
                ///         当启动完成时发生。
                /// </summary>
                [Description("启动完成事件")]
                [WillLogEventInvokeHandler]
                event EventHandler<ValueEventArgs<Exception>> Started;

                /// <summary>
                ///         当启动成功时发生。
                /// </summary>
                [Description("启动成功事件")]
                [WillLogEventInvokeHandler]
                event EventHandler<EventArgs> StartSuccessed;


                /// <summary>
                ///         当启动失败时发生。
                /// </summary>
                [Description("启动失败事件")]
                [WillLogEventInvokeHandler]
                event EventHandler<ValueEventArgs<Exception>> StartFailed;


                /// <summary>
                ///         当停止时发生。
                /// </summary>
                [Description("停止事件")]
                [WillLogEventInvokeHandler]
                event EventHandler<EventArgs> Stoping;


                /// <summary>
                ///         当停止完成时发生。
                /// </summary>
                [Description("停止完成事件")]
                [WillLogEventInvokeHandler]
                event EventHandler<ValueEventArgs<Exception>> Stoped;

                /// <summary>
                ///         当停止成功时发生。
                /// </summary>
                [Description("停止成功事件")]
                [WillLogEventInvokeHandler]
                event EventHandler<EventArgs> StopSuccessed;


                /// <summary>
                ///         当停止失败时发生。
                /// </summary>
                [Description("停止失败事件")]
                [WillLogEventInvokeHandler]
                event EventHandler<ValueEventArgs<Exception>> StopFailed;

                #endregion
        }
}