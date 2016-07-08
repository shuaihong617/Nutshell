// Nutshell.Hikvision.Mvision.h

#pragma once

#include "Stdafx.h"
#include"MvCameraControl.h"
#include"RuntimeCore.h"

namespace Nutshell
{
	namespace Hikvision
	{
		namespace Mvision
		{
			public ref class CameraCore
			{
			private:
				void** handle;
				MV_CC_DEVICE_INFO* deviceInfo;

			public:
				 int  OpenDevice(IPAddress^ ipAddress);
				 int  CloseDevice();

				 /************************************************************************/
				 /* 相机采集                                                 */
				 /************************************************************************/

				 int  StartGrabbing();
				 int  StopGrabbing();
				 int  GetOneFrame(Bitmap^ bitmap);

				/************************************************************************/
				/* 相机参数获取和设置                                                   */
				/************************************************************************/

				// 获取和设置图像宽度
				// int  GetWidth(IN OUT MVCC_INTVALUE* pstValue);
				// int  SetWidth(IN const unsigned int nValue);

				//// 获取和设置图像高度
				// int  GetHeight(IN OUT MVCC_INTVALUE* pstValue);
				// int  SetHeight(IN const unsigned int nValue);

				//// 获取和设置AOI的偏移
				// int  GetAOIoffsetX(IN OUT MVCC_INTVALUE* pstValue);
				// int  SetAOIoffsetX(IN const unsigned int nValue);

				//// 获取和设置AOI的偏移
				// int  GetAOIoffsetY(IN OUT MVCC_INTVALUE* pstValue);
				// int  SetAOIoffsetY(IN const unsigned int nValue);

				//// 调整自动曝光值下限
				// int  GetAutoExposureTimeLower(IN OUT MVCC_INTVALUE* pstValue);
				// int  SetAutoExposureTimeLower(IN const unsigned int nValue);

				////调整自动曝光值上限
				// int  GetAutoExposureTimeUpper(IN OUT MVCC_INTVALUE* pstValue);
				// int  SetAutoExposureTimeUpper(IN const unsigned int nValue);

				//// 明亮度调整
				// int  GetBrightness(IN OUT MVCC_INTVALUE* pstValue);
				// int  SetBrightness(IN const unsigned int nValue);

				//// 获取和设置帧率
				// int  GetFrameRate(IN OUT MVCC_FLOATVALUE* pstValue);
				// int  SetFrameRate(IN const float fValue);

				//
				//// 调整当前曝光值
				// int  GetExposureTime(IN OUT MVCC_FLOATVALUE* pstValue);
				// int  SetExposureTime(IN const float fValue);

				//// 获取和设置像素格式
				// int  GetPixelFormat(IN OUT MVCC_ENUMVALUE* pstValue);
				// int  SetPixelFormat(IN const unsigned int nValue);

				//// 采集模式
				// int  GetAcquisitionMode(IN OUT MVCC_ENUMVALUE* pstValue);
				// int  SetAcquisitionMode(IN const unsigned int nValue);
				//
				//// 获取图像基本信息
				// int  GetImageInfo(IN OUT MV_IMAGE_BASIC_INFO* pstInfo);
				// int  GetDeviceInfo(IN void * handle, IN OUT MV_CC_DEVICE_INFO* pstDevInfo);
			};
		}
	}
}
