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
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Automation.Models;
using Nutshell.Components;

namespace Nutshell.Automation
{
        /// <summary>
        ///         可连接设备
        /// </summary>
        public abstract class ConnectableDevice : Device, IConnectableDevice
        {                
                /// <summary>
                ///         初始化<see cref="DispatchableDevice" />的新实例.
                /// </summary> 
                /// <param name="parent">The parent.</param>
                /// <param name="id">The identifier.</param>
                protected ConnectableDevice([MustNotEqualNull]IIdentityObject parent,
                                            string id)
                        : base(parent, id)
                {
                        ConnectState = ConnectState.Disconnected; 
                                               
                }

                private IWorker _connectWorker;

                #region 属性

                /// <summary>
                ///         获取连接状态
                /// </summary>
                /// <value>连接状态</value>
                [WillNotifyPropertyChanged]
                public ConnectState ConnectState { get; private set; }

                /// <summary>
                ///         获取连接工作者，连接工作者负责设备的连接\断开
                /// </summary>
                /// <value>连接工作者</value>
                [MustNotEqualNull]
                public IWorker ConnectWorker
                {
                        get { return _connectWorker; }
                        protected set
                        {
                                _connectWorker = value;
                                OnPropertyChanged();

                                ConnectWorker.Starting += (obj, args) => ConnectState = ConnectState.Connecting;
                                ConnectWorker.StartSuccessed += (obj, args) => ConnectState = ConnectState.Connected;
                                ConnectWorker.Stoping += (obj, args) => ConnectState = ConnectState.Disconnecting;
                                ConnectWorker.StopSuccessed += (obj, args) => ConnectState = ConnectState.Disconnected;
                        }
                }

                

                /// <summary>
                ///         获取在线工作者,在线工作者负责检查设备在连接后是否依然在线
                /// </summary>
                /// <value>在线工作者</value>
                public ILooper SurviveLooper { get; protected set; }

                #endregion

                /// <summary>
                ///         Loads the specified model.
                /// </summary>
                /// <param name="model">The model.</param>
                public void Load([MustNotEqualNull] IConnectableDeviceModel model)
                {
                        base.Load(model);
                }

                /// <summary>
                ///         保存数据到数据模型
                /// </summary>
                /// <param name="model">写入数据的目的数据模型，该数据模型不能为null</param>
                public void Save([MustNotEqualNull] IConnectableDeviceModel model)
                {
                        throw new NotImplementedException();
                }

                protected abstract IWorkContext CreateConnectContext();

                protected abstract IWorkContext CreateSurviveContext();

                public void Connect()
                {
                        var connectContext = CreateConnectContext();                        
                        var surviveContext = CreateSurviveContext();

                        ConnectWorker.Start(connectContext);
                        SurviveLooper.Start(surviveContext);
                }

                public  void Disconnect()
                {
                        var connectContext = CreateConnectContext();
                        var surviveContext = CreateSurviveContext();

                        SurviveLooper.Stop(surviveContext);
                        ConnectWorker.Stop(connectContext);
                }

                /// <summary>
                /// 在线测试
                /// </summary>
                /// <returns>设备在线返回True，否则返回False</returns>
                public virtual bool OnlineTest()
                {
                        return true;
                }
        }
}
