// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-01-15
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-01-15
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;

namespace Nutshell.Hardware
{
        /// <summary>
        ///         采集设备
        /// </summary>
        public abstract class CaptureDevice<T> : Device
        {
                /// <summary>
                /// 初始化<see cref="T:CaptureDevice" />的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">The key.</param>
                protected CaptureDevice(IdentityObject parent, string id = "采集设备")
                        : base(parent, id)
                {
                        _isConnected = false;
                        LastCaptureTime = InvalidLastCaptureTime;
                }

                #region 属性

                public bool IsConnected
                {
                        get { return _isConnected; }
                        private set
                        {
                                if (value == _isConnected)
                                {
                                        return;
                                }
                                _isConnected = value;
                                RaisePropertyChanged();

                                if (IsConnected)
                                {
                                        OnConnectSuccessed(null);
                                }
                                else
                                {
                                        OnDisconnectSuccessed(null);
                                }
                        }
                }

                /// <summary>
                ///         连续采集是否已启动
                /// </summary>
                public bool IsStartCaptured
                {
                        get { return _isStartCaptured; }
                        private set
                        {
                                if (value == _isStartCaptured)
                                {
                                        return;
                                }
                                _isStartCaptured = value;
                                RaisePropertyChanged();
                        }
                }

                /// <summary>
                ///         无效的最近采集时间
                /// </summary>
                private static readonly DateTime InvalidLastCaptureTime = DateTime.MaxValue;

                public DateTime LastCaptureTime { get; protected set; }

                #endregion

                private bool _isStartCaptured;
                private bool _isConnected;

                #region 方法

                protected override sealed bool OpenCore()
                {
                        return Connect() && StartCapture();
                }

                protected override sealed bool CloseCore()
                {
                        return StopCapture() && Disconnect();
                }

                protected bool Connect()
                {
                        if (IsConnected)
                        {
                                return true;
                        }
                        IsConnected = ConnectCore();
                        return IsConnected;
                }

                protected abstract bool ConnectCore();

                protected bool Disconnect()
                {
                        if (!IsConnected)
                        {
                                return true;
                        }
                        IsConnected = !DisconnectCore();
                        return !IsConnected;
                }

                protected abstract bool DisconnectCore();

                /// <summary>
                ///         启动采集
                /// </summary>
                protected bool StartCapture()
                {
                        if (IsStartCaptured)
                        {
                                return true;
                        }
                        IsStartCaptured = StartCaptureCore();
                        return IsStartCaptured;
                }

                protected abstract bool StartCaptureCore();


                /// <summary>
                ///         停止采集
                /// </summary>
                protected bool StopCapture()
                {
                        if (!IsStartCaptured)
                        {
                                return true;
                        }
                        IsStartCaptured = !StopCaptureCore();
                        return !IsStartCaptured;
                }

                protected abstract bool StopCaptureCore();


                protected void Capture()
                {
                        var t = CaptureCore();
                        if (t == null)
                        {
                                return;
                        }

                        LastCaptureTime = DateTime.Now;
                        OnCaptureSuccessed(new ValueEventArgs<T>(t));
                }

                protected abstract T CaptureCore();


                /// <summary>
                ///         在线检测
                /// </summary>
                //public virtual void OnlineTest()
                //{
                //        //if (!IsEnable)
                //        //{
                //        //        return;
                //        //}

                //        if (!IsRuning)
                //        {
                //                return;
                //        }

                //        //if (!IsLoopStarted)
                //        //{
                //        //        return;
                //        //}

                //        if (LastCaptureTime == InvalidLastCaptureTime)
                //        {
                //                return;
                //        }

                //        TimeSpan over = DateTime.Now - LastCaptureTime;
                //        //if (over.TotalMilliseconds > 3000)
                //        //{
                //        //        OnOnlineTestFailed(null);
                //        //}
                //}

                #endregion

                #region 事件
                protected event EventHandler<EventArgs> ConnectSuccessed;


                /// <summary>
                ///         引发 <see cref="E:Opened" /> 事件.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnDisconnectFailed(EventArgs e)
                {
                        e.Raise(this, ref DisconnectFailed);
                }

                /// <summary>
                ///         Occurs when [openCaptur].
                /// </summary>
                public event EventHandler<OperationEventArgs> StartCaptured;

                /// <summary>
                ///         Raises the <see cref="E:OpenCaptur" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnStartCaptured(OperationEventArgs e)
                {
                        e.Raise(this, ref StartCaptured);
                }

                /// <summary>
                ///         Occurs when [openCaptur].
                /// </summary>
                public event EventHandler<OperationEventArgs> StopCaptured;

                /// <summary>
                ///         Raises the <see cref="E:OpenCaptur" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
                protected virtual void OnStopCaptured(OperationEventArgs e)
                {
                        e.Raise(this, ref StopCaptured);
                }

                /// <summary>
                ///         Occurs when [snaped].
                /// </summary>
                public event EventHandler<ValueEventArgs<T>> CaptureSuccessed;

                /// <summary>
                ///         Called when [capture successed].
                /// </summary>
                /// <param name="e">The e.</param>
                protected virtual void OnCaptureSuccessed(ValueEventArgs<T> e)
                {
                        //this.InfoEventRaise("采集成功");
                        e.Raise(this, ref CaptureSuccessed);
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