using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Nutshell.Automation.Opc;
using Nutshell.Components;
//重命名OpcDAAuto.dll中类名，禁止删除；
using NativeOpcServer = OPCAutomation.OPCServer;

namespace Nutshell.Automation.Opc
{
        public class OpcRuntimeDispatchWorker : Worker
        {
                public OpcRuntimeDispatchWorker(OpcRuntime parent)
                        : base( "Opc运行环境工作者")
                {
                }

                /// <summary>
                ///         执行启动过程的具体步骤.
                /// </summary>
                /// <returns>成功返回True, 否则返回False.</returns>
                /// <remarks>
                ///         若启动过程有多个步骤, 遇到返回错误的步骤立即停止向下执行.
                /// </remarks>
                protected override sealed IResult Starup(IRunableObject runableObject)
                {
                        var version = new Version(3, 6);
                        ReadOnlyCollection<InstalledOpcServer> installedOpcServers;
                        try
                        {
                                installedOpcServers = GetInstalledOpcServers();
                        }
                        catch (Exception ex)
                        {
                                return new ExceptionResult(ex);
                        }
                        return new OpcRuntimeDispatchResult(version, installedOpcServers);
                }

                private ReadOnlyCollection<InstalledOpcServer> GetInstalledOpcServers()
                {
                        var server = new NativeOpcServer();

                        //此处必须为object类型，使用var自动推导将导致后续转换失败
                        object addresses = server.GetOPCServers();

                        var addressList = ((Array) addresses).Cast<string>().ToList();
			List<InstalledOpcServer> installedOpcServers = new List<InstalledOpcServer>(addressList.Count);

	                var runtime = Parent as OpcRuntime;
			Trace.Assert(runtime != null);

	                installedOpcServers.AddRange(addressList.Select(address => new InstalledOpcServer(runtime, address)));

	                return new ReadOnlyCollection<InstalledOpcServer>(installedOpcServers);
                }
        }
}
