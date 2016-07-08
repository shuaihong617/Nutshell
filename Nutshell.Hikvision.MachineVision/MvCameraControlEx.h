/***************************************************************************************************
* 
* 版权信息：版权所有 (c) 2015, 杭州海康威视数字技术股份有限公司, 保留所有权利
* 
* 文件名称：MvCameraControl.h
* 摘    要：相机控制SDK的C接口类
*
* 当前版本：1.0.0.0
* 作    者：张建明
* 日    期：2015-01-28
* 备    注：仅对部门内部开放的接口定义
***************************************************************************************************/
#ifndef _MV_CAMERA_CTRL_EX_H_
#define _MV_CAMERA_CTRL_EX_H_

#include "MvCameraControl.h"

#ifdef __cplusplus
extern "C" {
#endif 

//调试信息
MV_CAMCTRL_API int __stdcall MV_CC_ReadDebugInfo(void* handle, int nMsgType, char* pBuffer, unsigned int nSize);
MV_CAMCTRL_API int __stdcall MV_CC_WriteDebugInfo(void* handle, int nMsgType, char* pBuffer, unsigned int nLen);
MV_CAMCTRL_API int __stdcall MV_CC_OpenDeviceForUpgrade(IN void* handle,
                                              IN unsigned int nAccessMode = MV_ACCESS_Exclusive, 
                                              IN unsigned short nSwitchoverKey = 0);


MV_CAMCTRL_API int __stdcall MV_CC_SetWaterMarkEnable(bool bEnable = true);

MV_CAMCTRL_API int __stdcall MV_CC_IsDriverWorking(void* handle);

// 0：不丢弃；1：丢弃
MV_CAMCTRL_API int __stdcall MV_CC_SetThrowAbnormalImage(void * handle, int bThrow);

#ifdef __cplusplus
}
#endif 

#endif //_MV_CAMERA_CTRL_EX_H_
