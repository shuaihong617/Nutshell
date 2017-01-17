using System.Collections.ObjectModel;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Components;
//重命名OPCDAAuto.dll中类名，禁止删除；
using NativeOpcServer = OPCAutomation.OPCServer;

namespace Nutshell.Automation.Opc
{
        public class OpcRuntime : Runtime
        {
                protected OpcRuntime(IIdentityObject parent)
                        : base(parent, "过程控制通讯运行环境")
                {
                        DispatchWorker = new OpcRuntimeDispatchWorker(this);
                }


                [MustNotEqualNull]
                public ReadOnlyCollection<string> OpcServerNames { get; private set; }

	        /// <summary>
                ///         Starts this instance.
                /// </summary>
                public override sealed IResult Start()
                {
                        var result = base.Start();

	                if (result.IsSuccessed)
	                {

                                var opcResult = result as OpcRuntimeDispatchResult;
                                if (result.IsSuccessed)
                                {
                                        OpcServerNames = opcResult.OpcServerNames;
                                        RuntimeInformation = new RuntimeInformation(opcResult.OpcVersion);
                                }
                        }

		        return result;
                }
        }
}
