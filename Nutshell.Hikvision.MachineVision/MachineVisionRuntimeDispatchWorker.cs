using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Nutshell.Components;
using Nutshell.Extensions;
using Nutshell.Hardware.Vision.Hikvision.MachineVision.SDK;

namespace Nutshell.Hardware.Vision.Hikvision.MachineVision
{
	public class MachineVisionRuntimeDispatchWorker:DispatchWorker
	{
		public MachineVisionRuntimeDispatchWorker(string id) 
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
			var baseResult = base.Starup(runableObject);
			if (!baseResult.IsSuccessed)
			{
				return baseResult;
			}

			var runtime = runableObject as MachineVisionRuntime;
			Trace.Assert(runtime != null);

			if (runtime.DeviceInfos != null)
			{
				return Result.Successed;
			}

			var deviceInfoList = new MVDeviceInformationList();
			var errorCode = MVOfficialAPI.EnumDevices(MVDeviceType.GigeDevice, ref deviceInfoList);

			if (errorCode != MVErrorCode.MV_OK)
			{
				this.WarnFail("摄像机枚举", errorCode);
				return false;
			}

			var deviceInfos = new List<MVDeviceInformation>();

			var deviceInfoType = typeof(MVDeviceInformation);
			foreach (var deviceInfoPtr in deviceInfoList.DeviceInfoPtrs)
			{
				if (deviceInfoPtr != IntPtr.Zero)
				{
					var di = (MVDeviceInformation)Marshal.PtrToStructure(deviceInfoPtr, deviceInfoType);
					deviceInfos.Add(di);

					this.Info("检测到摄像机：IP" + di.GigeDeviceInfo.GetCurrentIpAddress());
				}
			}

			DeviceInfos = new ReadOnlyCollection<MVDeviceInformation>(deviceInfos);

			return true;
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
			var baseResult = base.Clean(runableObject);
			if (!baseResult.IsSuccessed)
			{
				return baseResult;
			}
		}
	}
}
