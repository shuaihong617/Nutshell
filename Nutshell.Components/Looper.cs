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
using System.Threading;
using Nutshell.Aspects.Events;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Components.Models;
using Nutshell.Data;
using Nutshell.Extensions;

namespace Nutshell.Components
{
	/// <summary>
	///         循环工作者
	/// </summary>
	public class Looper : Worker, IStorable<ILooperModel>
	{
		public Looper(string id, Func<Result> repeat)
			: this(id, ThreadPriority.Normal, 1000, repeat)
		{
		}

		public Looper(string id, int interval, Func<Result> repeat)
			: this(id, ThreadPriority.Normal, interval, repeat)
		{
		}

		public Looper(string id, ThreadPriority priority, int interval, Func<Result> repeat)
			: base(id)
		{
			Priority = priority;
			Interval = interval;
			_repeat = repeat;
		}

		#region 字段

		private Thread _thread;

		private bool _isContinue;

		private readonly Func<Result> _repeat;

		#endregion

		#region 属性

		/// <summary>
		///         获取循环调度线程优先级
		/// </summary>
		/// <value>循环调度线程优先级</value>
		[NotifyPropertyValueChanged]
		public ThreadPriority Priority { get; private set; }

		/// <summary>
		///         获取循环调度间隔时间
		/// </summary>
		/// <value>循环调度间隔事件</value>
		[MustGreaterThanOrEqual(0)]
		[NotifyPropertyValueChanged]
		public int Interval { get; set; }

		#endregion

		public void Load([MustNotEqualNull] ILooperModel model)
		{
			base.Load(model);

			Priority = model.Priority;
			Interval = model.Interval;
		}

		public void Save([MustNotEqualNull] ILooperModel model)
		{
			throw new NotImplementedException();
		}

		protected override Result StartCore()
		{
			_isContinue = true;

			_thread = new Thread(ThreadWork) {Priority = Priority};
			_thread.Start();

			return Result.Successed;
		}

		private void ThreadWork()
		{
			this.Info("循环启动,周期", Interval, "毫秒");
			for (;;)
			{
				var result = _repeat();
				OnRepeatFinshed(new ValueEventArgs<Result>(result));

				Thread.Sleep(Interval);

				if (!_isContinue)
				{
					this.Info("循环停止");
					break;
				}
			}
		}

		protected override Result StopCore()
		{
			_isContinue = false;

			return Result.Successed;
		}

		#region 事件

		/// <summary>
		///         当启动时发生。
		/// </summary>
		[Description("启动事件")]
		[WillLogEventInvokeHandler]
		public event EventHandler<ValueEventArgs<Result>> RepeatFinshed;

		/// <summary>
		///         引发启动事件。
		/// </summary>
		/// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
		protected virtual void OnRepeatFinshed(ValueEventArgs<Result> e)
		{
			e.Raise(this, ref RepeatFinshed);
		}

		#endregion
	}
}