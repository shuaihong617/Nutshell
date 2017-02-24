using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutshell.Components;

namespace Nutshell.Hardware.Vision.Hikvision.MachineVision
{
	public class MachineVisionCameraDispatchWork:DispatchWorker
	{
		public MachineVisionCameraDispatchWork(string id) 
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
			//return base.Starup(runableObject);

			//CreatePool();

			//if (_captureBufferPtr == IntPtr.Zero)
			//{
			//	_captureBufferPtr = Marshal.AllocHGlobal(CaptureBufferBytesCount);
			//}

			//MVErrorCode mvError = MVOfficialAPI.StartGrabbing(_handle);
			//if (mvError != MVErrorCode.MV_OK)
			//{
			//	this.WarnFail("StartGrabbing", mvError);
			//	return false;
			//}
			//this.InfoSuccess("StartGrabbing");

			throw new NotImplementedException();
			//return _captureLooper.Start();
		}

		/// <summary>
		///         执行退出过程的具体步骤.
		/// </summary>
		/// <returns>成功返回True, 否则返回False.</returns>
		/// <remarks>
		///         若退出过程有多个步骤,执行尽可能多的步骤, 以保证尽量清理现场.
		/// </remarks>
		protected override IResult Clean(IRunableObject runableObject)
		{
			//return base.Clean(runableObject);

			throw new NotImplementedException();
			//_captureLooper.Stop();

			//MVOfficialAPI.StopGrabbing(_handle);

			//return true;
		}
	}
}
