using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nutshell.Automation;
using Nutshell.Automation.Vision;
using Nutshell.Drawing.Imaging;
using Nutshell.Hardware.Vision.Hikvision.MachineVision.SDK;

namespace Nutshell.Hardware.Vision.Hikvision.MachineVision
{
	public class MachineVisionCameraCaptureLooper:CaptureLooper
	{
		public MachineVisionCameraCaptureLooper(string id) 
			: base(id)
		{
		}

		public MachineVisionCameraCaptureLooper(string id, int interval) 
			: base(id, interval)
		{
		}

		public MachineVisionCameraCaptureLooper(string id, ThreadPriority priority, int interval) 
			: base(id, priority, interval)
		{
		}

		protected override IResult RepeatWork()
		{
			//return base.RepeatWork();

			throw new NotImplementedException();
			//
			//if (!IsEnable || !IsStarted || !IsConnected || !IsStartCaptured)
			//                     {
			//                             Trace.WriteLine("!IsEnable || !IsStarted || !IsConnected || !IsStartCaptured Failed");
			//                             return null;
			//                     }

			//Bitmap bitmap = Buffers.WriteLock();

			//MVErrorCode mvError = MVOfficialAPI.GetOneFrame(_handle, bitmap.Buffer, bitmap.BufferLength,
			//	ref _mvFrameOutInfo);
			//if (mvError != MVErrorCode.MV_OK)
			//{
			//	//this.WarnFail("GetOneFrame", error);
			//	Buffers.WriteUnlock(bitmap);
			//	return null;
			//}
			////this.InfoSuccess("GetOneFrame");
			//Buffers.WriteUnlock(bitmap);

			//var stamp = bitmap.TimeStampChain as CaptureTimeStampChain;
			//if (stamp != null)
			//{
			//	stamp.CaptureTime = DateTime.Now;
			//}

			//return bitmap;
		}
	}
}
