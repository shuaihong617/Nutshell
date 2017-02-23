using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutshell.Components;

namespace Nutshell.Hardware.Vision.Hikvision.MachineVision
{
	public class MachineVisionCameraConnectWork:ConnectWorker
	{
		public MachineVisionCameraConnectWork(string id) 
			: base(id)
		{
		}

		/// <summary>
		///         执行启动过程的具体步骤.
		/// </summary>
		/// <returns>成功返回True, 否则返回False.</returns>
		/// <remarks>
		///         若启动过程有多个步骤, 遇到返回错误的步骤立即停止向下执行.
		/// </remarks>
		protected override IResult Starup(IRunableObject runableObject)
		{
			var result = base.Starup(runableObject);
			if (!result.IsSuccessed)
			{
				return result;
			}


			return Result.Successed;
		}
	}
}
