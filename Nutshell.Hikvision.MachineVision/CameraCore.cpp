// 这是主 DLL 文件。

#include "stdafx.h"
#include "CameraCore.h"

namespace Nutshell
{
	namespace Hikvision
	{
		namespace Mvision
		{
			int  CameraCore::OpenDevice(IPAddress^ ipAddress)
			{
				RuntimeCore^ runtime = RuntimeCore::Instance;

				deviceInfo = new MV_CC_DEVICE_INFO();

				bool isSuccess = runtime->FindDevice(ipAddress, deviceInfo);

				if (!isSuccess)
				{
					return -1;
				}

				MV_CC_CreateHandle(handle, deviceInfo);

				unsigned int nAccessMode = MV_ACCESS_Exclusive;
				unsigned short nSwitchoverKey = 0;


				return MV_CC_OpenDevice(*handle, nAccessMode, nSwitchoverKey);


			}

			int  CameraCore::CloseDevice()
			{
				MV_CC_CloseDevice(*handle);
				MV_CC_DestroyHandle(*handle);
			}

			/************************************************************************/
			/* 相机采集                                                 */
			/************************************************************************/

			int  CameraCore::StartGrabbing()
			{
				MV_CC_StartGrabbing(*handle);

			}

			int  CameraCore::StopGrabbing()
			{
				MV_CC_StopGrabbing(*handle);
			}

			int  CameraCore::GetOneFrame(Bitmap^ bitmap)
			{
				//MV_CC_GetOneFrame(*handle, g_pFrameBuf, MAX_BUF_SIZE, &stInfo);
			}
		}
	}
}