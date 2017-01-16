using System.Globalization;
using Nutshell.Components;
using NativeSynthesizer = System.Speech.Synthesis.SpeechSynthesizer;

namespace Nutshell.Speech.Microsoft
{
	public class MicrosoftSynthesisRuntimeDispatchWorker : Worker
	{
		public MicrosoftSynthesisRuntimeDispatchWorker(IIdentityObject parent)
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
			var synthesizer = new NativeSynthesizer();

			var chinese = synthesizer.GetInstalledVoices(new CultureInfo("zh-CN"));
			var english = synthesizer.GetInstalledVoices(new CultureInfo("en-US"));

			return new MicrosoftSynthesisRuntimeDispatchResult(chinese, english);
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
	}
}
