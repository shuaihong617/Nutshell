using System.Collections.Generic;
using Nutshell.Automation.OPC;
using Nutshell.Components;
//重命名OPCDAAuto.dll中类名，禁止删除；
using NativeOpcServer = OPCAutomation.OPCServer;

namespace Nutshell.Automation.Opc
{
	public class OpcServerDispatchContext : WorkContext
	{
		public OpcServerDispatchContext(NativeOpcServer opcServer, string address, IEnumerable<IOpcGroup> opcGroups )
		{
			NativeOpcServer = opcServer;
			Address = address;
			OpcGroups = opcGroups;
		}

		public NativeOpcServer NativeOpcServer { get; private set; }
		public string Address { get; private set; }

		public IEnumerable<IOpcGroup> OpcGroups { get; private set; }
	}
}
