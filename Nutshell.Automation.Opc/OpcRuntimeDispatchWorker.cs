using System;
using System.Collections.ObjectModel;
using System.Linq;
using Nutshell.Components;
//重命名OPCDAAuto.dll中类名，禁止删除；
using NativeOpcServer = OPCAutomation.OPCServer;

namespace Nutshell.Automation.Opc
{
        public class OpcRuntimeDispatchWorker : Worker
        {
                public OpcRuntimeDispatchWorker(IIdentityObject parent)
                        : base(parent, "Opc运行环境工作者")
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
                        var version = new Version(3, 6);
                        ReadOnlyCollection<string> names;
                        try
                        {
                                names = GetAllOpcServerNames();
                        }
                        catch (Exception ex)
                        {
                                return new Result(ex);
                        }
                        return new OpcRuntimeDispatchResult(version, names);
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
                        return Result.Successed;
                }


                private ReadOnlyCollection<string> GetAllOpcServerNames()
                {
                        var server = new NativeOpcServer();

                        //此处必须为object类型，使用var自动推导将导致后续转换失败
                        object names = server.GetOPCServers();

                        var result = ((Array) names).Cast<string>().ToList();

                        return new ReadOnlyCollection<string>(result);
                }
        }
}
