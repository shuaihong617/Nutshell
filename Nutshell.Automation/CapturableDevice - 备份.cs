//// ***********************************************************************
//// 作者           : 阿尔卑斯 shuaihong617@qq.com
//// 创建           : 2015-01-15
////
//// 编辑           : 阿尔卑斯 shuaihong617@qq.com
//// 日期           : 2015-01-15
//// 内容           : 创建文件
//// ***********************************************************************
//// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
//// <summary>
//// </summary>
//// ***********************************************************************

//using System;
//using Nutshell.Threading;

//namespace Nutshell.Automation
//{
//        /// <summary>
//        ///         采集设备
//        /// </summary>
//        public abstract class CapturableDevice<T> : DispatchableDevice where T:IIdentityObject
//        {
//                /// <summary>
//                /// 初始化<see cref="T:CaptureDevice" />的新实例.
//                /// </summary>
//                /// <param name="parent">上级对象</param>
//                /// <param name="id">The key.</param>
//                protected CapturableDevice(string id = "采集设备")
//                        : base( id)
//                {
//                        _isConnected = false;
//                        LastCaptureTime = InvalidLastCaptureTime;
//                }

//                #region 属性

//                public bool IsConnected
//                {
//                        get { return _isConnected; }
//                        private set
//                        {
//                                if (value == _isConnected)
//                                {
//                                        return;
//                                }
//                                _isConnected = value;
//                                OnPropertyChanged();

//                                if (IsConnected)
//                                {
//                                        OnConnectSuccessed(null);
//                                }
//                                else
//                                {
//                                        OnDisconnectSuccessed(null);
//                                }
//                        }
//                }

//                /// <summary>
//                ///         连续采集是否已启动
//                /// </summary>
//                public bool IsStartCaptured
//                {
//                        get { return _isStartCaptured; }
//                        private set
//                        {
//                                if (value == _isStartCaptured)
//                                {
//                                        return;
//                                }
//                                _isStartCaptured = value;
//                                OnPropertyChanged();
//                        }
//                }

//                /// <summary>
//                ///         无效的最近采集时间
//                /// </summary>
//                private static readonly DateTime InvalidLastCaptureTime = DateTime.MaxValue;

//                public DateTime LastCaptureTime { get; protected set; }


//		/// <summary>
//		///         图像池
//		/// </summary>
//		public NSReadWritePool<T> Buffers { get; protected set; }


//		#endregion

//		private bool _isStartCaptured;
//                private bool _isConnected;

//		#region 方法

//	        public virtual void CreatePool()
//	        {
		        
//	        }



//		protected bool Connect()
//                {
//                        if (IsConnected)
//                        {
//                                return true;
//                        }
//                        IsConnected = ConnectCore();
//                        return IsConnected;
//                }

//                protected abstract bool ConnectCore();

//                protected bool Disconnect()
//                {
//                        if (!IsConnected)
//                        {
//                                return true;
//                        }
//                        IsConnected = !DisconnectCore();
//                        return !IsConnected;
//                }

//                protected abstract bool DisconnectCore();

//                /// <summary>
//                ///         启动采集
//                /// </summary>
//                protected bool StartCapture()
//                {
//                        if (IsStartCaptured)
//                        {
//                                return true;
//                        }
//                        IsStartCaptured = StartCaptureCore();
//                        return IsStartCaptured;
//                }

//                protected abstract bool StartCaptureCore();


//                /// <summary>
//                ///         停止采集
//                /// </summary>
//                protected bool StopCapture()
//                {
//                        if (!IsStartCaptured)
//                        {
//                                return true;
//                        }
//                        IsStartCaptured = !StopCaptureCore();
//                        return !IsStartCaptured;
//                }

//                protected abstract bool StopCaptureCore();


//                protected void Capture()
//                {
//                        var t = CaptureCore();
//                        if (t == null)
//                        {
//                                return;
//                        }

//                        LastCaptureTime = DateTime.Now;
//                        OnCaptureSuccessed(new ValueEventArgs<T>(t));
//                }

//                protected abstract T CaptureCore();


//                /// <summary>
//                ///         在线检测
//                /// </summary>
//                //public virtual void OnlineTest()
//                //{
//                //        //if (!IsEnable)
//                //        //{
//                //        //        return;
//                //        //}

//                //        if (!IsRuning)
//                //        {
//                //                return;
//                //        }

//                //        //if (!IsLoopStarted)
//                //        //{
//                //        //        return;
//                //        //}

//                //        if (LastCaptureTime == InvalidLastCaptureTime)
//                //        {
//                //                return;
//                //        }

//                //        TimeSpan over = DateTime.Now - LastCaptureTime;
//                //        //if (over.TotalMilliseconds > 3000)
//                //        //{
//                //        //        OnOnlineTestFailed(null);
//                //        //}
//                //}

//                #endregion

//                #region 事件

//                /// <summary>
//                ///         Occurs when [snaped].
//                /// </summary>
//                public event EventHandler<ValueEventArgs<T>> CaptureSuccessed;

//                /// <summary>
//                ///         Called when [capture successed].
//                /// </summary>
//                /// <param name="e">The e.</param>
//                protected virtual void OnCaptureSuccessed(ValueEventArgs<T> e)
//                {
//                        //this.InfoEventRaise("采集成功");
//                        e.Raise(this, ref CaptureSuccessed);
//                }


//                //protected override void OnOnlineTestFailed(EventArgs e)
//                //{
//                //        this.WarnFail("在线检测");
//                //        Shutdown();
//                //        base.OnOnlineTestFailed(e);
//                //}

//                #endregion
//        }
//}