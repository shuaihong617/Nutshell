// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-01-05
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-01-05
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Components.Models;
using Nutshell.Data.Models;
using Nutshell.Log;

namespace Nutshell.Components
{
        /// <summary>
        ///         应用程序令牌集合
        /// </summary>
        public class WatchDog : Worker
        {
                public WatchDog(IdentityObject parent, string id = "看门狗", int scanInterval = int.MaxValue,
                        int overflowInterval = int.MaxValue)
                        : base(parent, id)
                {
                        ScanLooper = new Looper(this, "扫描循环", scanInterval, Scan);

                        OverflowSpan = TimeSpan.FromMilliseconds(overflowInterval);
                }

                #region 字段

                private DateTime _feedTime;

                #endregion

                public Looper ScanLooper { get; private set; }


                public TimeSpan OverflowSpan { get; private set; }

                public DateTime FeedTime
                {
                        get { return _feedTime; }
                        private set
                        {
                                _feedTime = value;
                                OnPropertyChanged();

                                OnFeeded(null);
                        }
                }

                public override void Load([AssignableFrom(typeof(IWatchDogModel))]IDataModel model)
                {

                        base.Load(model);

                        var watchDogModel = (IWatchDogModel) model;
                        Trace.Assert(watchDogModel.Interval > 0);

                        OverflowSpan = TimeSpan.FromMilliseconds(watchDogModel.Interval);
                        //ScanLooper.Load(watchDogModel.ScanLooperModel);
                }

                protected override bool StartCore()
                {
                        FeedTime = DateTime.Now;

                        ScanLooper.Start();
                        return ScanLooper.IsStarted;
                }

                protected override bool StopCore()
                {
                        ScanLooper.Stop();
                        return ScanLooper.IsStarted;
                }

                /// <summary>
                ///         喂狗
                /// </summary>
                public void Feed()
                {
                        FeedTime = DateTime.Now;
                }

                private void Scan()
                {
                        if (DateTime.Now - FeedTime > OverflowSpan)
                        {
                                OnOverflowed(null);
                                Stop();
                        }
                }

                #region 事件

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                public event EventHandler<EventArgs> Feeded;

                /// <summary>
                ///         Raises the <see cref="E:Opened" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
                protected virtual void OnFeeded(EventArgs e)
                {
                        this.InfoEvent("喂狗");
                        e.Raise(this, ref Feeded);
                }

                /// <summary>
                ///         Occurs when [opened].
                /// </summary>
                public event EventHandler<EventArgs> Overflowed;

                /// <summary>
                ///         Raises the <see cref="E:Opened" /> event.
                /// </summary>
                /// <param name="e">The <see cref="EventArgs" /> Itance containing the event data.</param>
                protected virtual void OnOverflowed(EventArgs e)
                {
                        this.InfoEvent("溢出");
                        e.Raise(this, ref Overflowed);
                }

                #endregion
        }
}