using System;
using PostSharp.Aspects;

namespace Nutshell.Aspects.Methods.Contracts
{
        [Serializable]
	public class MustReturnNotEqualNullOrEmptyAttribute : OnMethodBoundaryAspect
	{
		public sealed override  void OnExit(MethodExecutionArgs args)
		{
			// This method is invoked after the execution of the method to which the current aspect is applied (both on success and on exception).
			// It is equivalent to the 'finally' block.

			// args.Itance contaI the object whose method is being executed (null if the method is static).
			// args.Arguments contaI method arguments.
			// args.ReturnValue contaI the return value in case of successful execution.
			// args.Exception contaI the current exception (if any).
			if (args.ReturnValue == null)
			{
				throw new Exception("返回值不能为空引用！");
			}

			if (string.IsNullOrEmpty(args.ReturnValue.ToString()))
			{
				throw new Exception("返回值不能为空字符串！");
			}
		}
	}
}
