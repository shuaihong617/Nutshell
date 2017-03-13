using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Components;
using Nutshell.Extensions;
using OPCAutomation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Nutshell.Automation.Opc
{
        public class OpcRuntime : Runtime
        {
                private OpcRuntime()
                        : base("Opc运行环境")
                {
                        InstalledOpcServers = new ReadOnlyCollection<InstalledOpcServer>(new List<InstalledOpcServer>());
                }

                #region 属性

                /// <summary>
                ///         单例
                /// </summary>
                public static readonly OpcRuntime Instance = new OpcRuntime();

                [MustNotEqualNull]
                public ReadOnlyCollection<InstalledOpcServer> InstalledOpcServers { get; private set; }

                #endregion 属性

                /// <summary>
                ///         执行启动过程的具体步骤.
                /// </summary>
                /// <returns>成功返回True, 否则返回False.</returns>
                /// <remarks>
                ///         若启动过程有多个步骤, 遇到返回错误的步骤立即停止向下执行.
                /// </remarks>
                protected override Result StartCore()
                {
                        var baseResult = base.StartCore();
                        if (!baseResult.IsSuccessed)
                        {
                                return baseResult;
                        }

                        var server = new OPCServer();

                        //此处必须为object类型，使用var自动推导将导致后续转换失败
                        object addresses = server.GetOPCServers();

                        var addressList = ((Array)addresses).Cast<string>().ToList();
                        List<InstalledOpcServer> installedOpcServers = new List<InstalledOpcServer>(addressList.Count);

                        foreach (var address in addressList)
                        {
                                InstalledOpcServer installedOpcServer = new InstalledOpcServer(address);
                                installedOpcServer.Parent = this;
                                installedOpcServers.Add(installedOpcServer);
                        }

                        InstalledOpcServers = installedOpcServers.ToReadOnlyCollection();

                        return Result.Successed;
                }
        }
}