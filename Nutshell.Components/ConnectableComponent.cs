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

using System;
using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Components.Models;

namespace Nutshell.Components
{
        /// <summary>
        ///         可连接组件
        /// </summary>
        public abstract class ConnectableComponent : Component, IConnectableComponent
        {                
                /// <summary>
                ///         初始化<see cref="DispatchableComponent" />的新实例.
                /// </summary> 
                /// <param name="id">The identifier.</param>
                protected ConnectableComponent(string id=null, IConnectWorker connectWorker=null, ISurviveLooper surviveLooper=null)
                        : base( id)
                {
                        ConnectState = ConnectState.Disconnected; 

			ConnectWorker = connectWorker;
			ConnectWorker.Starting += (obj, args) => ConnectState = ConnectState.Connecting;
                        ConnectWorker.Started += (obj, args) => ConnectState = ConnectState.Connected;
                        ConnectWorker.Stoping += (obj, args) => ConnectState = ConnectState.Disconnecting;
			ConnectWorker.Stoped += (obj, args) => ConnectState = ConnectState.Disconnected;

			SurviveLooper = surviveLooper;
                }

	        #region 字段

	        private IConnectWorker _connectWorker;
	        private ISurviveLooper _surviveLooper;

	        #endregion


                #region 属性

                /// <summary>
                ///         获取连接状态
                /// </summary>
                /// <value>连接状态</value>
                [WillNotifyPropertyChanged]
                public ConnectState ConnectState { get; private set; }

                /// <summary>
                ///         获取连接工作者，连接工作者负责组件的连接\断开
                /// </summary>
                /// <value>连接工作者</value>
                [MustNotEqualNull]
                public IConnectWorker ConnectWorker{ get; private set; }

		[MustNotEqualNull]
	        public ISurviveLooper SurviveLooper{ get; private set; }

	        #endregion


		/// <summary>
		/// 从数据模型加载数据
		/// </summary>
		/// <param name="model">读取数据的源数据模型，该数据模型不能为null</param>
		public void Load([MustNotEqualNull] IConnectableComponentModel model)
                {
                        base.Load(model);
                }

                /// <summary>
                ///         保存数据到数据模型
                /// </summary>
                /// <param name="model">写入数据的目的数据模型，该数据模型不能为null</param>
                public void Save([MustNotEqualNull] IConnectableComponentModel model)
                {
                        base.Save(model);
                }


		/// <summary>
		/// 连接
		/// </summary>
		/// <returns>操作结果</returns>
		public IResult StartConnect()
		{
			Trace.Assert(ConnectWorker != null, "连接工作者不能为空！");
                        return ConnectWorker.Start(this);
                }

		/// <summary>
		/// 断开连接
		/// </summary>
		/// <returns>操作结果</returns>
		public IResult StopConnect()
		{
			Trace.Assert(ConnectWorker != null, "连接工作者不能为空！");
                        return ConnectWorker.Stop(this);
                }

	        public IResult IsSurvive()
	        {
		        return Result.Successed;
	        }

		/// <summary>
		/// 连接
		/// </summary>
		/// <returns>操作结果</returns>
		public IResult StartSurvive()
		{
			Trace.Assert(SurviveLooper != null, "守护循环工作者不能为空！");
			return SurviveLooper.Start(this);
		}

		/// <summary>
		/// 断开连接
		/// </summary>
		/// <returns>操作结果</returns>
		public IResult StopSurvive()
		{
			Trace.Assert(SurviveLooper != null, "守护循环工作者不能为空！");
			return SurviveLooper.Stop(this);
		}

		#region 事件

		protected event EventHandler<EventArgs> ConnectSuccessed;


		/// <summary>
		///         引发 <see cref="E:Opened" /> 事件.
		/// </summary>
		/// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
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
		/// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
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
		/// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
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
		/// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
		protected virtual void OnDisconnectFailed(EventArgs e)
		{
			e.Raise(this, ref DisconnectFailed);
		}

		/// <summary>
		///         Occurs when [openCaptur].
		/// </summary>
		public event EventHandler<EventArgs> StartCaptured;

		/// <summary>
		///         Raises the <see cref="E:OpenCaptur" /> event.
		/// </summary>
		/// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
		protected virtual void OnStartCaptured(EventArgs e)
		{
			e.Raise(this, ref StartCaptured);
		}

		/// <summary>
		///         Occurs when [openCaptur].
		/// </summary>
		public event EventHandler<EventArgs> StopCaptured;

		/// <summary>
		///         Raises the <see cref="E:OpenCaptur" /> event.
		/// </summary>
		/// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
		protected virtual void OnStopCaptured(EventArgs e)
		{
			e.Raise(this, ref StopCaptured);
		}

		


		//protected override void OnOnlineTestFailed(EventArgs e)
		//{
		//        this.WarnFail("在线检测");
		//        Shutdown();
		//        base.OnOnlineTestFailed(e);
		//}

		#endregion
	}
}
