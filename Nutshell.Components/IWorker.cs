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
        ///         工作者接口
        /// </summary>
        public interface IWorker : IStorable<IWorkerModel>, IEnable, IDebuggable
        {
                /// <summary>
                ///         获取调度状态
                /// </summary>
                /// <value>调度状态</value>
                WorkState WorkState { get; }


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
                event EventHandler<EventArgs> Starting;

                /// <summary>
                ///         当启动完成时发生。
                /// </summary>
                event EventHandler<ValueEventArgs<Exception>> Started;

                /// <summary>
                ///         当启动成功时发生。
                /// </summary>
                event EventHandler<EventArgs> StartSuccessed;


                /// <summary>
                ///         当启动失败时发生。
                /// </summary>
                event EventHandler<ValueEventArgs<Exception>> StartFailed;


                /// <summary>
                ///         当停止时发生。
                /// </summary>
                event EventHandler<EventArgs> Stoping;


                /// <summary>
                ///         当停止完成时发生。
                /// </summary>
                event EventHandler<ValueEventArgs<Exception>> Stoped;

                /// <summary>
                ///         当停止成功时发生。
                /// </summary>
                event EventHandler<EventArgs> StopSuccessed;


                /// <summary>
                ///         当停止失败时发生。
                /// </summary>
                event EventHandler<ValueEventArgs<Exception>> StopFailed;

                #endregion
        }
}