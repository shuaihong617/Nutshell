using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Opc.Models;
using Nutshell.Data;
using Nutshell.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

//重命名OpcDAAuto.dll中类名，禁止删除；
using NativeOpcServer = OPCAutomation.OPCServer;

namespace Nutshell.Automation.Opc
{
        /// <summary>
        ///         OpcServer
        /// </summary>
        /// <remarks>
        ///         处于运行模式下时：
        ///         1. 启动时不连接物理Opc服务器
        ///         2. 通过人工写入模拟Opc项值的变化
        ///         3. Opc项写入请求直接完成
        /// </remarks>
        public class OpcServer : DispatchableDevice, IStorable<IOpcServerModel>
        {
                public OpcServer(string id = "", string address = "")
                        : base(id)
                {
                        if (!string.IsNullOrEmpty(address))
                        {
                                Address = address;
                        }

                        _nativeOpcServer = new NativeOpcServer();
                }

                #region 字段

                private readonly NativeOpcServer _nativeOpcServer;

                private ReadOnlyCollection<OpcGroup> _opcGroups;

                #endregion 字段

                #region 属性

                [MustNotEqualNullOrEmpty]
                public string Address { get; private set; }

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

                public void Load([MustNotEqualNull] IOpcServerModel model)
                {
                        base.Load(model);

                        Address = model.Address;
                }

                public void Save(IOpcServerModel model)
                {
                        throw new NotImplementedException();
                }

                protected override Result StartConnectCore()
                {
                        try
                        {
                                _nativeOpcServer.Connect(Address);
                        }
                        catch (Exception ex)
                        {
                                this.Error(Id + " " + Address + "  连接失败," + ex);
                                return Result.Failed;
                        }

                        this.InfoSuccess("连接" + Address);

                        return Result.Successed;
                }

                protected override Result StopConnectCore()
                {
                        try
                        {
                                _nativeOpcServer.Disconnect();
                        }
                        catch (Exception ex)
                        {
                                this.Error(Id + " " + Address + "  断开失败," + ex);
                                return Result.Failed;
                        }

                        this.InfoSuccess("断开" + Address);

                        return Result.Successed;
                }

                protected override Result StartDispatchCore()
                {
                        try
                        {
                                foreach (var group in OpcGroups)
                                {
                                        group.Attach(_nativeOpcServer, Address);
                                };
                        }
                        catch (Exception ex)
                        {
                                this.Error(Address + "  操作失败," + ex);
                        }

                        foreach (var opcGroup in OpcGroups)
                        {
                                foreach (var opcItem in opcGroup.OpcItems)
                                {
                                        opcItem.RemoteRead();
                                }
                        }

                        this.InfoSuccess("Attach" + Address);

                        return Result.Successed;
                }

                protected override Result StopDispatchCore()
                {
                        try
                        {
                                _nativeOpcServer.Disconnect();
                        }
                        catch (Exception ex)
                        {
                                this.Error(Id + " " + Address + "  断开失败," + ex);
                        }

                        this.InfoSuccess("断开" + Address);

                        return Result.Successed;
                }
        }
}