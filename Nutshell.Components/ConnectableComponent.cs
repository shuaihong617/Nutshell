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
                /// <param name="parent">The parent.</param>
                /// <param name="id">The identifier.</param>
                protected ConnectableComponent([MustNotEqualNull]IIdentityObject parent,
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
                ///         获取连接工作者，连接工作者负责组件的连接\断开
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

                #endregion

                /// <summary>
                ///         Loads the specified model.
                /// </summary>
                /// <param name="model">The model.</param>
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
                        throw new NotImplementedException();
                }


                public void Connect()
                {

                        ConnectWorker.Start(this);
                }

                public  void Disconnect()
                {
                        ConnectWorker.Stop(this);
                }

                
        }
}
