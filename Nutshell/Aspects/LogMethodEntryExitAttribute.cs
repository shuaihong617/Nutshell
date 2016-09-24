using System;
using Nutshell.Data;
using Nutshell.Log;
using PostSharp.Aspects;

namespace Nutshell.Aspects
{
        [Serializable]
        public sealed class LogMethodEntryExitAttribute : OnMethodBoundaryAspect
        {
                public override void OnEntry(MethodExecutionArgs args)
                {
                        //  This method is invoked before the execution of the method to which the current aspect is applied.

                        // args.Instance contains the object whose method is being executed (null if the method is static).
                        // args.Arguments contains method arguments.

                        // Set args.FlowBehavior = FlowBehavior.Return to return to the caller without executing the intercepted method.
                        // In this case, set args.ReturnValue to a value that is compatible to the return type of the method (null for void methods).
                        var i = args.Instance as IdentityObject;
                        if (i == null)
                        {
                                return;
                        }
                        i.Info(i.Id + " " + args.Method.Name + " entry.");
                }

                public override void OnExit(MethodExecutionArgs args)
                {
                        // This method is invoked after the execution of the method to which the current aspect is applied (both on success and on exception).
                        // It is equivalent to the 'finally' block.

                        // args.Instance contains the object whose method is being executed (null if the method is static).
                        // args.Arguments contains method arguments.
                        // args.ReturnValue contains the return value in case of successful execution.
                        // args.Exception contains the current exception (if any).

                        var i = args.Instance as IdentityObject;
                        if (i == null)
                        {
                                return;
                        }
                        i.Info(i.Id + " "  +  args.Method.Name + " exit.");
                }
        }
}
