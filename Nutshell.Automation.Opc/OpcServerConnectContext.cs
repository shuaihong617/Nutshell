using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutshell.Components;

//重命名OPCDAAuto.dll中类名，禁止删除；
using NativeOpcServer = OPCAutomation.OPCServer; 

namespace Nutshell.Automation.Opc
{
	public class OpcServerConnectContext:WorkContext
	{
	        public OpcServerConnectContext(NativeOpcServer opcServer, string name, string address)
	        {
			NativeOpcServer = opcServer;
			Name = name;
	                Address = address;
	                
	        }

		public NativeOpcServer NativeOpcServer { get; private set; }

		public string Name { get; private set; }

		public string Address { get; private set; }

                
	}
}
