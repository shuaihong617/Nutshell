using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Methods.Contracts;
using Nutshell.Automation.Opc;
using Nutshell.Automation.OPC.Models;
using Nutshell.Components;

//重命名OPCDAAuto.dll中类名，禁止删除；
using NativeOpcServer = OPCAutomation.OPCServer; 

namespace Nutshell.Automation.OPC
{
        /// <summary>
        ///         OPCServer
        /// </summary>
        /// <remarks>
        ///         处于调试模式下时：
        ///         1. 启动时不连接物理OPC服务器
        ///         2. 通过人工写入模拟OPC项值的变化
        ///         3. OPC项写入请求直接完成
        /// </remarks>
        public class OpcServer : DispatchableDevice, IOpcServer
        {
                public OpcServer([MustNotEqualNull]IIdentityObject parent, 
                        string id = null, string name = null, string address = null)
                        : base(parent, id)
                {
                        if (!string.IsNullOrEmpty(name))
                        {
                                Name = name;
                        }

                        if (!string.IsNullOrEmpty(address))
                        {
                                Address = address;                                
                        }

                        OpcGroups = new ObservableCollection<IOpcGroup>();
                        OpcItems = new ObservableCollection<IOpcItem>();
                        OpcItemsLookupTable = new Dictionary<string, IOpcItem>();

                        ConnectWorker = new OpcServerConnectWorker(this);
			SurviveLooper = new OpcServerSurviveLooper(this);
			DispatchWorker = new OpcServerDispatchWorker(this);
                }

                #region 字段

                public static int ClientHandleIndex;

                private readonly NativeOpcServer _nativeOpcServer = new NativeOpcServer();

                public Dictionary<string, IOpcItem> OpcItemsLookupTable { get; private set; }


                #endregion

                #region 属性

                [MustNotEqualNullOrEmpty]
                public string Name { get; private set; }

		[MustNotEqualNullOrEmpty]
                public string Address { get; private set; }


                public ObservableCollection<IOpcGroup> OpcGroups { get; private set; }

                public ObservableCollection<IOpcItem> OpcItems { get; private set; }


                #endregion

                public void Load([MustNotEqualNull] IOpcServerModel model)
                {
                        base.Load(model);

                        Name = model.Name;
                        Address = model.Address;
                }

                

                public void Save(IOpcServerModel model)
                {
                        throw new NotImplementedException();
                }

                public void AddGroup(IOpcGroup group)
                {
                        OpcGroups.Add(group);

                        foreach (var opcItem in group.OpcItems)
                        {
                                OpcItems.Add(opcItem);
                                OpcItemsLookupTable.Add(opcItem.Id, opcItem);
                        }
                }

		[MustReturnNotEqualNull]
                protected override IWorkContext CreateConnectContext()
                {
                        return new OpcServerConnectContext(_nativeOpcServer,Name, Address);
                }

		[MustReturnNotEqualNull]
                protected override IWorkContext CreateSurviveContext()
		{
			return WorkContext.EnableRelease;
		}

		[MustReturnNotEqualNull]
                protected override IWorkContext CreateDispatchContext()
                {
			return new OpcServerDispatchContext(_nativeOpcServer, Address, OpcGroups);
		}

                

                
        }
}