using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Methods.Contracts;
using Nutshell.Automation.Opc;
using Nutshell.Automation.Opc.Models;
using Nutshell.Components;
using OPCAutomation;

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
        public class OpcServer : DispatchableComponent, IOpcServer
        {
	        public OpcServer(string id = null, string address = null, ReadOnlyCollection<IOpcGroup> opcGroups = null)
                        : base(id)
                {
                        if (!string.IsNullOrEmpty(address))
                        {
                                Address = address;                                
                        }

                        NativeOpcServer = new NativeOpcServer();

		        if (opcGroups != null)
		        {
				AddGroups(opcGroups);
			}

			ConnectWorker = new OpcServerConnectWorker(this);
			DispatchWorker = new OpcServerDispatchWorker(this);
                }

                #region 属性

                public NativeOpcServer NativeOpcServer { get; private set; }

                [MustNotEqualNullOrEmpty]
                public string Name { get; private set; }

		[MustNotEqualNullOrEmpty]
                public string Address { get; private set; }


                public ReadOnlyCollection<IOpcGroup> OpcGroups { get; private set; }

                public ReadOnlyCollection<IOpcItem> OpcItems { get; private set; }

                #endregion

                public void Load([MustNotEqualNull] IOpcServerModel model)
                {
                        base.Load(model);

                        Address = model.Address;
                }

		public void Save(IOpcServerModel model)
                {
                        throw new NotImplementedException();
                }

               

	        public void AddGroups(ReadOnlyCollection<IOpcGroup> opcGroups)
	        {
		        OpcGroups = opcGroups;

			var opcItems = new List<IOpcItem>();
		        foreach (var opcGroup in OpcGroups)
		        {
			        opcItems.AddRange(opcGroup.OpcItems);
		        }
			OpcItems = new ReadOnlyCollection<IOpcItem>(opcItems);
	        }
        }
}