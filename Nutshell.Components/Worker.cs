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
using Nutshell.Extensions;
using Nutshell.Storaging;

namespace Nutshell.Components
{
	/// <summary>
	///         工作者
	/// </summary>
	public abstract class Worker : Component, IStorable<WorkerModel>
	{
		protected Worker([MustNotEqualNull] string id)
			: base(id)
		{
			WorkerState = WorkerState.未启动;
		}

		#region 字段

		/// <summary>
		///         线程同步标识
		/// </summary>
		private readonly object _lockFlag = new object();

		#endregion 字段

		#region 属性

		/// <summary>
		///         获取工作状态
		/// </summary>
		/// <value>工作状态</value>
		[NotifyPropertyValueChanged]
		public WorkerState WorkerState { get; private set; }

		#endregion 属性

		public void Load(WorkerModel model)
		{
			base.Load(model);
		}

		public void Save(WorkerModel model)
		{
			base.Save(model);
		}

		/// <summary>
		///         启动
		/// </summary>
		/// <returns>成功返回True，失败返回False.</returns>
		public bool Start()
		{
			lock (_lockFlag)
			{
				if (WorkerState == WorkerState.已启动)
				{
					return true;
				}

				WorkerState = WorkerState.启动中;

				if (!IsEnable)
				{
					this.Warn("未启用");

					WorkerState = WorkerState.已停止;
					return false;
				}

				var result = StartCore();
				WorkerState = result ? WorkerState.已启动 : WorkerState.已停止;

				return result;
			}
		}

		/// <summary>
		///         停止
		/// </summary>
		/// <returns>成功返回True，失败返回False.</returns>
		public bool Stop()
		{
			lock (_lockFlag)
			{
				if (WorkerState == WorkerState.已停止)
				{
					return true;
				}

				WorkerState = WorkerState.停止中;

				if (!IsEnable)
				{
					this.Warn("启用状态:否");

					return false;
				}

				var result = StopCore();

				WorkerState = WorkerState.已停止;

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
		protected virtual bool StartCore()
		{
			return true;
		}

		/// <summary>
		///         执行退出过程的具体步骤.
		/// </summary>
		/// <returns>成功返回True, 否则返回False.</returns>
		/// <remarks>
		///         若退出过程有多个步骤,执行尽可能多的步骤, 以保证尽量清理现场.
		/// </remarks>
		protected virtual bool StopCore()
		{
			return true;
		}

		#region 事件

		/// <summary>
		///         当启动时发生。
		/// </summary>
		[Description("启动事件")]
		[LogEventInvokeHandler]
		public event EventHandler<EventArgs> Starting;

		/// <summary>
		///         引发启动事件。
		/// </summary>
		/// <param name="e">包含事件数据的实例<see cref="EventArgs" /></param>
		protected virtual void OnStarting(EventArgs e)
		{
			e.Raise(this, ref Starting);
		}

		/// <summary>
		///         当启动完成时发生。
		/// </summary>
		[Description("启动完成事件")]
		[LogEventInvokeHandler]
		public event EventHandler<ValueEventArgs<Exception>> Started;

		/// <summary>
		///         引发启动事件。
		/// </summary>
		/// <param name="e">包含事件数据的实例<see cref="EventArgs" /></param>
		protected virtual void OnStarted(ValueEventArgs<Exception> e)
		{
			e.Raise(this, ref Started);
		}

		/// <summary>
		///         当停止时发生。
		/// </summary>
		[Description("停止事件")]
		[LogEventInvokeHandler]
		public event EventHandler<EventArgs> Stoping;

		/// <summary>
		///         引发<see cref="E:Opened" />事件
		/// </summary>
		/// <param name="e">包含事件数据的实例<see cref="EventArgs" /></param>
		protected virtual void OnStoping(EventArgs e)
		{
			e.Raise(this, ref Stoping);
		}

		/// <summary>
		///         当停止完成时发生。
		/// </summary>
		[Description("停止完成事件")]
		[LogEventInvokeHandler]
		public event EventHandler<ValueEventArgs<Exception>> Stoped;

		/// <summary>
		///         引发<see cref="E:Opened" />事件
		/// </summary>
		/// <param name="e">包含事件数据的实例<see cref="EventArgs" /></param>
		protected virtual void OnStoped(ValueEventArgs<Exception> e)
		{
			e.Raise(this, ref Stoped);
		}

		#endregion 事件
	}
}