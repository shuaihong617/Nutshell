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
using Nutshell.Threading;

namespace Nutshell.Automation
{
        /// <summary>
        ///         采集设备
        /// </summary>
        public abstract class CapturableDevice<T> : DispatchableDevice where T:IIdentityObject
        {
                /// <summary>
                /// 初始化<see cref="T:CaptureDevice" />的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">The key.</param>
                protected CapturableDevice(string id = "采集设备")
                        : base( id)
                {
                }

                #region 属性

		/// <summary>
		///         图像池
		/// </summary>
		public NSReadWritePool<T> Buffers { get; protected set; }

		public CaptureLooper CaptureLooper { get; private set; }

		#endregion



		#region 方法

		public virtual void CreatePool()
	        {
		        
	        }

                protected void Capture()
                {
                        var t = CaptureCore();
                        if (t == null)
                        {
                                return;
                        }

                        //LastCaptureTime = DateTime.Now;
                        OnCaptureSuccessed(new ValueEventArgs<T>(t));
                }

                protected abstract T CaptureCore();

                #endregion

                #region 事件

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


                

                #endregion
        }
}