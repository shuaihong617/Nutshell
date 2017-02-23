using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Opc;
using Nutshell.Components;

namespace Nutshell.Automation.Opc
{
	public class OpcRuntime : Runtime
	{
		public OpcRuntime(IIdentityObject parent)
			: base(parent, "Opc运行环境")
		{
			InstalledOpcServers = new ReadOnlyCollection<InstalledOpcServer>(new List<InstalledOpcServer>());
			DispatchWorker = new OpcRuntimeDispatchWorker(this);
		}


		[MustNotEqualNull]
		public ReadOnlyCollection<InstalledOpcServer> InstalledOpcServers { get; private set; }

		/// <summary>
		///         Starts this instance.
		/// </summary>
		public override sealed IResult Start()
		{
			var baseResult = base.Start();
			if (!baseResult.IsSuccessed)
			{
				return baseResult;
			}

			var opcResult = baseResult as OpcRuntimeDispatchResult;
			Trace.Assert(opcResult != null);

			InstalledOpcServers = opcResult.InstalledOpcServers;
			RuntimeInformation = new RuntimeInformation(opcResult.OpcVersion);

			return baseResult;
		}
	}
}
