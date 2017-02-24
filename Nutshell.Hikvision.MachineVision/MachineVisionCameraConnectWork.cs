using System;
using System.Collections.Generic;
using System.Diagnostics;
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

			var camera = runableObject as MachineVisionCamera;
			Debug.Assert(camera != null);

			

			//_deviceInfo =
   //                             MachineVisionRuntime.Itance.DeviceInfos.FirstOrDefault(
   //                                     i => Equals(i.GigeDeviceInfo.GetCurrentIpAddress(), IPAddress));

   //                     if (_deviceInfo.MajorVer == 0)
   //                     {
   //                             this.WarnFail("枚举摄像机", "未枚举到摄像机信息");
   //                             return false;
   //                     }

   //                     MVErrorCode mvError = MVOfficialAPI.CreateHandle(ref _handle, ref _deviceInfo);
   //                     if (mvError != MVErrorCode.MV_OK)
   //                     {
   //                             this.WarnFail("CreateHandle", mvError);
   //                             return false;
   //                     }
   //                     this.InfoSuccess("CreateHandle");

   //                     if (!MVOfficialAPI.RegisterExceptionCallBack(_handle, _exceptionCallback, IntPtr.Zero))
   //                     {
   //                             this.WarnFail("RegisterExceptionCallBack", mvError);
   //                             return false;
   //                     }
                        

   //                     mvError = MVOfficialAPI.OpenDevice(_handle, AccessMode.控制权限);
   //                     if (mvError != MVErrorCode.MV_OK)
   //                     {
   //                             this.WarnFail("OpenDevice", mvError);
   //                             return false;
   //                     }
   //                     this.InfoSuccess("OpenDevice");

   //                     return true;

			return Result.Successed;
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

			//MVErrorCode mvError = MVOfficialAPI.CloseDevice(_handle);
			//if (mvError != MVErrorCode.MV_OK)
			//{
			//	this.WarnFail("CloseDevice", mvError);
			//	return false;
			//}
			//this.InfoSuccess("CloseDevice");

			//mvError = MVOfficialAPI.DestroyHandle(_handle);
			//if (mvError != MVErrorCode.MV_OK)
			//{
			//	this.WarnFail("DestroyHandle", mvError);
			//	return false;
			//}
			//this.InfoSuccess("DestroyHandle");

			//return true;

			return Result.Successed;
		}
	}
}
