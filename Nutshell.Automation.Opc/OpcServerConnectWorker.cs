using System;
using System.Diagnostics;
using Nutshell.Automation.Opc;
using Nutshell.Components;
using Nutshell.Extensions;
using Nutshell.Logging.KernelLogging;

namespace Nutshell.Automation.Opc
{
        public class OpcServerConnectWorker : ConnectWorker
        {
                public OpcServerConnectWorker(OpcServer parent)
                        : base(parent, "Opc服务器连接工作者")
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
                        var opcServer = runableObject as IOpcServer;
			Trace.Assert(opcServer != null);

                        try
                        {
                                opcServer.NativeOpcServer.Connect(opcServer.Address);
                        }
                        catch (Exception ex)
                        {
                                this.Error(Id + " " + opcServer.Address + "  连接失败," + ex);
	                        return Result.Failed;
                        }

                        this.InfoSuccess("连接" + opcServer.Address);

                        return Result.Successed;
                }

                /// <summary>
                ///         执行退出过程的具体步骤.
                /// </summary>
                /// <returns>成功返回True, 否则返回False.</returns>
                /// <remarks>
                ///         若退出过程有多个步骤,执行尽可能多的步骤, 以保证尽量清理现场.
                /// </remarks>
                protected override sealed IResult Clean(IRunableObject runableObject)
                {
                        var opcServer = runableObject as IOpcServer;
			Trace.Assert(opcServer !=null);

                        try
                        {
                                opcServer.NativeOpcServer.Disconnect();
                        }
                        catch (Exception ex)
                        {
                                this.Error(Id + " " + opcServer.Address + "  断开失败," + ex);
				return Result.Failed;
			}

                        this.InfoSuccess("断开" + opcServer.Address);

                        return Result.Successed;
                }
        }
}
