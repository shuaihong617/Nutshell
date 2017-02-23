using System;
using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Opc;
using Nutshell.Components;
using Nutshell.Extensions;

namespace Nutshell.Automation.Opc
{
        public class OpcServerDispatchWorker : DispatchWorker
        {
                public OpcServerDispatchWorker(IIdentityObject parent)
                        : base(parent, "Opc服务器调度工作者")
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
			if (runableObject.RunMode == RunMode.Debug)
			{
				return Result.Successed;
			}

			var opcServer = runableObject as IOpcServer;
			Trace.Assert(opcServer != null);

                        try
                        {
				foreach (var group in opcServer.OpcGroups)
				{
					group.Attach(opcServer.NativeOpcServer, opcServer.Address);
				};
			}
			catch (Exception ex)
                        {
                                this.Error(opcServer.Address + "  操作失败," + ex);
                        }

                        foreach (var opcItem in opcServer.OpcItems)
                        {
                                opcItem.RemoteRead();
                        }

                        this.InfoSuccess("Attach" + opcServer.Address);

                        return Result.Successed;
                }

                /// <summary>
                ///         执行退出过程的具体步骤.
                /// </summary>
                /// <returns>成功返回True, 否则返回False.</returns>
                /// <remarks>
                ///         若退出过程有多个步骤,执行尽可能多的步骤, 以保证尽量清理现场.
                /// </remarks>
                protected override sealed IResult Clean([MustAssignableFrom(typeof(IOpcServer))]IRunableObject runableObject)
                {
                        var opcServer = runableObject as IOpcServer;
			Trace.Assert(opcServer != null);

			try
                        {
                                opcServer.NativeOpcServer.Disconnect();
                        }
                        catch (Exception ex)
                        {
                                this.Error(Id + " " + opcServer.Address + "  断开失败," + ex);
                        }

                        this.InfoSuccess("断开" + opcServer.Address);

                        return Result.Successed;
                }
	}
}
