using System.Collections.ObjectModel;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Components;
//重命名OPCDAAuto.dll中类名，禁止删除；
using NativeOpcServer = OPCAutomation.OPCServer;

namespace Nutshell.Automation.Opc
{
        public class OpcRuntime : Runtime
        {
                protected OpcRuntime()
                {
                        DispatchWorker = new OpcRuntimeDispatchWorker(this);
                }

                #region 单例

                /// <summary>
                ///         单例
                /// </summary>
                public static readonly OpcRuntime Instance = new OpcRuntime();

                #endregion

                [MustNotEqualNull]
                public ReadOnlyCollection<string> OpcServerNames { get; private set; }

	        /// <summary>
                ///         Starts this instance.
                /// </summary>
                public override sealed IResult Start()
                {
                        var result = base.Start();

	                if (result.IsSuccess)
	                {

                                var opcResult = result as OpcRuntimeDispatchResult;
                                if (result.IsSuccess)
                                {
                                        OpcServerNames = opcResult.OpcServerNames;
                                        RuntimeInformation = new RuntimeInformation(opcResult.OpcVersion);
                                }
                        }

		        return result;
                }
        }
}
