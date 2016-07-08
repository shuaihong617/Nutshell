#include "stdafx.h"
#include "RuntimeCore.h"

namespace Nutshell
{
	namespace Hikvision
	{
		namespace Mvision
		{
			
			unsigned int RuntimeCore::GetSDKVersion()
			{
				return MV_CC_GetSDKVersion();
			}

			bool RuntimeCore::IsEnableGigeDevices()
			{
				unsigned int nTransLayers = MV_CC_EnumerateTls();
				return nTransLayers & MV_GIGE_DEVICE;
			}

			int RuntimeCore::EnumDevices()
			{
				unsigned int nTLayerType = MV_GIGE_DEVICE;

				DeviceInfoList = new MV_CC_DEVICE_INFO_LIST;
				return MV_CC_EnumDevices(nTLayerType, DeviceInfoList);
			}

			bool RuntimeCore::FindDevice(IPAddress^ ipAddress, MV_CC_DEVICE_INFO* deviceInfo)
			{

			}
		
		}
	}
}