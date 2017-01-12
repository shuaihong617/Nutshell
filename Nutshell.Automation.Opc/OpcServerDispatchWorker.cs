using System;
using Nutshell.Components;
using Nutshell.Log;

namespace Nutshell.Automation.Opc
{
        public class OpcServerDispatchWorker : Worker
        {
                public OpcServerDispatchWorker(IIdentityObject parent)
                        : base(parent, "Opc服务器控制工作者")
                {
                }

                /// <summary>
                ///         执行启动过程的具体步骤.
                /// </summary>
                /// <returns>成功返回True, 否则返回False.</returns>
                /// <remarks>
                ///         若启动过程有多个步骤, 遇到返回错误的步骤立即停止向下执行.
                /// </remarks>
                protected override sealed IResult Starup(IWorkContext context)
                {
			if (context.RunMode == RunMode.Debug)
			{
				return Result.Successed;
			}

			var opcContext = context as OpcServerDispatchContext;

                        try
                        {
				foreach (var group in opcContext.OpcGroups)
				{
					group.Attach(opcContext.NativeOpcServer, opcContext.Address);
				};
			}
			catch (Exception ex)
                        {
                                //this.Error(Id + " " + opcContext.Name + "  连接失败," + ex);
                                return new Result(ex);
                        }

                        //this.InfoSuccess("连接" + opcContext.Name);

                        return Result.Successed;
                }

                /// <summary>
                ///         执行退出过程的具体步骤.
                /// </summary>
                /// <returns>成功返回True, 否则返回False.</returns>
                /// <remarks>
                ///         若退出过程有多个步骤,执行尽可能多的步骤, 以保证尽量清理现场.
                /// </remarks>
                protected override sealed IResult Clean(IWorkContext context)
                {
                        var opcContext = context as OpcServerConnectContext;

                        try
                        {
                                opcContext.NativeOpcServer.Disconnect();
                        }
                        catch (Exception ex)
                        {
                                this.Error(Id + " " + opcContext.Name + "  断开失败," + ex);
                                return new Result(ex);
                        }

                        this.InfoSuccess("断开" + opcContext.Name);

                        return Result.Successed;
                }
	}
}
