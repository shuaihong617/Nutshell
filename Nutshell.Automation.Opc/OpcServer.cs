// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-03-08
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-03-13
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Opc.Models;
using Nutshell.Extensions;
using Nutshell.IO.Aspects.Locations.Contracts;
using Nutshell.Serializing.Xml;
using Nutshell.Storaging;
using Nutshell.Storaging.Xml;
//重命名OpcDAAuto.dll中类名，禁止删除；
using NativeOpcServer = OPCAutomation.OPCServer;

namespace Nutshell.Automation.Opc
{
        /// <summary>
        ///         OpcServer
        /// </summary>
        /// <remarks>
        ///         处于运行模式下时:
        ///         1. 启动时不连接物理Opc服务器
        ///         2. 通过人工写入模拟Opc项值的变化
        ///         3. Opc项写入请求直接完成
        /// </remarks>
        public class OpcServer : DispatchableDevice, IStorable<OpcServerModel>
        {
                /// <summary>
                ///         初始化<see cref="OpcServer" />的新实例.
                /// </summary>
                /// <param name="id">The identifier.</param>
                /// <param name="address">The address.</param>
                public OpcServer(string id = "", string name = "", string address = "")
                        : base(id)
                {
                        if (!string.IsNullOrEmpty(name))
                        {
                                Name = name;
                        }

                        if (!string.IsNullOrEmpty(address))
                        {
                                Address = address;
                        }
                }

                #region 字段

                /// <summary>
                ///         The _native opc server
                /// </summary>
                private readonly NativeOpcServer _nativeOpcServer = new NativeOpcServer();

                /// <summary>
                ///         The _opc groups
                /// </summary>
                private ReadOnlyCollection<OpcGroup> _opcGroups;

                #endregion 字段

                #region 属性

                /// <summary>
                ///         Gets the address.
                /// </summary>
                /// <value>The address.</value>
                [MustNotEqualNullOrEmpty]
                public string Name { get; private set; } = string.Empty;

                /// <summary>
                ///         Gets the address.
                /// </summary>
                /// <value>The address.</value>
                [MustNotEqualNullOrEmpty]
                public string Address { get; private set; } = string.Empty;

                /// <summary>
                ///         Gets or sets the opc groups.
                /// </summary>
                /// <value>The opc groups.</value>
                public ReadOnlyCollection<OpcGroup> OpcGroups
                {
                        get { return _opcGroups; }
                        set
                        {
                                Debug.Assert(_opcGroups == null);
                                Debug.Assert(value != null);

                                _opcGroups = value;

                                foreach (var opcGroup in _opcGroups)
                                {
                                        opcGroup.Parent = this;
                                }
                        }
                }

                #endregion 属性

                public static OpcServer Load([MustFileExist] string fileName)
                {
                        var bytes = XmlStorager.Instance.Load(fileName);
                        var model = XmlSerializer<OpcServerModel>.Instance.Deserialize(bytes);

                        var opcServer = new OpcServer();
                        opcServer.Load(model);

                        return opcServer;
                }

                /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">读取数据的源数据模型，该数据模型不能为空引用</param>
                public virtual void Load([MustNotEqualNull] OpcServerModel model)
                {
                        base.Load(model);

                        Name = model.Name;
                        Address = model.Address;

                        var groups = new List<OpcGroup>(model.OpcGroupModels.Count);
                        foreach (var groupModel in model.OpcGroupModels)
                        {
                                var group = new OpcGroup();
                                group.Load(groupModel);

                                groups.Add(group);
                        }
                        OpcGroups = groups.AsReadOnly();
                }

                /// <summary>
                ///         保存数据到数据模型
                /// </summary>
                /// <param name="model">写入数据的目的数据模型，该数据模型不能为空引用</param>
                /// <exception cref="System.NotImplementedException"></exception>
                public void Save(OpcServerModel model)
                {
                        throw new NotImplementedException();
                }

                /// <summary>
                ///         Starts the connect core.
                /// </summary>
                /// <returns>Result.</returns>
                protected override bool StartConnectCore()
                {
                        try
                        {
                                _nativeOpcServer.Connect(Name);
                        }
                        catch (Exception ex)
                        {
                                this.Error($"{Id}{Name}连接失败,服务器名称:{Name},失败原因:{ex}");
                                return false;
                        }

                        this.Info($"连接成功,服务器名称:{Name}");
                        return true;
                }

                /// <summary>
                ///         Stops the connect core.
                /// </summary>
                /// <returns>Result.</returns>
                protected override bool StopConnectCore()
                {
                        try
                        {
                                _nativeOpcServer.Disconnect();
                        }
                        catch (Exception ex)
                        {
                                this.Error($"{Id}{Address}断开失败,{ex}");
                                return false;
                        }

                        this.InfoSuccess($"断开{Address}");

                        return true;
                }

                /// <summary>
                ///         Starts the dispatch core.
                /// </summary>
                /// <returns>Result.</returns>
                protected override bool StartDispatchCore()
                {
                        foreach (var group in OpcGroups)
                        {
                                group.Attach(_nativeOpcServer, Address);
                        }

                        foreach (var opcGroup in OpcGroups)
                        {
                                foreach (var opcItem in opcGroup.OpcItems)
                                {
                                        opcItem.RemoteRead();
                                }
                        }

                        return true;
                }
        }
}