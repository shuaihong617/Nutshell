﻿using System;
using System.Runtime.InteropServices;

namespace Nutshell.Hikvision.SmartVision.Sdk
{
        public static class OfficalApis
        {
                /// <summary>
                /// 获取当前的SDK版本
                /// </summary>
                ///<returns>
                ///SDK版本号
                /// </returns>
                public static Version GetSdkVersion()
                {
                        var version = NativeOfficalApis.GetSDKVersion();
                        var bytes = BitConverter.GetBytes(version);
                        return new Version(bytes[0], bytes[1], bytes[2], bytes[3]);
                }

                /*@fn       MV_SC_Discovery
                **@brief    枚举设备
                **@param    pstDevList      设备信息列表结构体指针
                **@return   成功：返回MV_OK;失败：返回错误码
                */

                public static ErrorCode Discovery(ref DeviceInformationCollection deviceInformationCollection)
                {
                        return NativeOfficalApis.Discovery(ref deviceInformationCollection);
                }

                /*@fn       MV_SC_DiscoveryEx
                **@brief    枚举设备，扩展接口，可以指定枚举端口号
                **@param    pstDevList      设备信息列表结构体指针
                **@param    nDevPort        指定设备端口号
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern ErrorCode DiscoveryEx(ref DeviceInformationCollection pstDevList, ushort nDevPort);

                /*@fn       MV_SC_GetDeviceInfo
                **@brief    获取设备信息
                **@param    nDeviceIp       设备IP地址
                **@param    pstDeviceInfo   设备信息结构体指针
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern ErrorCode GetDeviceInfo(uint nDeviceIp, ref DeviceInfomation pstDeviceInfo);

                /*@fn       MV_SC_GetDeviceInfoEx
                **@brief    获取设备信息，扩展接口，可指定端口号
                **@param    nDeviceIp       设备IP地址
                **@param    pstDeviceInfo   设备信息结构体指针
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_GetDeviceInfoEx(uint nDeviceIp, ushort nDevPort, ref DeviceInformationCollection pstDeviceInfo);

                /*@fn       MV_SC_CreateHandle
                **@brief    创建设备句柄
                **@param    handle          设备句柄
                **@param    pstDevInfo      设备信息结构体指针
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_CreateHandle(ref IntPtr handle, ref DeviceInfomation pstDevInfo);

                /*@fn       MV_SC_CreateHandleEx
                **@brief    创建设备句柄，扩展接口，可以指定创建设备句柄的端口号
                **@param    handle          设备句柄
                **@param    pstDevInfo      设备信息结构体指针
                **@param    nDevPort        指定设备端口号
                **@param    bLogEnable      是否创建Log文件
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_CreateHandleEx(ref IntPtr handle
                                                                      , ref DeviceInfomation pstDevInfo
                                                                      , ushort nDevPort
                                                                      , bool bLogEnable);

                /*@fn       MV_SC_DestroyHandle
                **@brief    销毁设备句柄
                **@param    handle          要销毁的设备句柄
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_DestroyHandle(IntPtr handle);

                /*@fn       MV_SC_ForceIp
                **@brief    
                **@param    handle          设备句柄
                **@param    nNewIp          
                **@param    nNewSubNet      
                **@param    nNewGateWay     
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int ForceIpAddress(IntPtr handle, uint nNewIp);



                /* 3种状态：Offline、Online、NotConnected
                   异常：CvsInSightLockedException、CvsSensorAlreadyConnectedException、
                         CvsInvalidLogonException、CvsNetworkException
                */

                /*@fn       MV_SC_Connect
                **@brief    连接设备
                **@param    handle          设备句柄
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_Connect(IntPtr handle);

                /*@fn       MV_SC_Disconnect
                **@brief    断开连接
                **@param    handle          设备句柄
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_Disconnect(IntPtr handle);

                /*@fn       MV_SC_SaveJob
                **@brief    保存当前工作流程到第n组（n取值范围1-3）
                **@param    handle          设备句柄
                **@param    nIndex          
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_SaveJob(IntPtr handle, int nIndex);




                /*@fn       MV_SC_StartJob
                **@brief    开始工作流程
                **@param    handle          设备句柄
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_StartJob(IntPtr handle);

                /*@fn       MV_SC_StopJob
                **@brief    停止工作流程
                **@param    handle          设备句柄
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_StopJob(IntPtr handle);

                /*@fn       MV_SC_GetJobState
                **@brief    获取相机当前的工作状态，pbWorking返回值为1，表示处于工作状态，为0表示非工作状态
                **@param    handle          设备句柄
                **@param    pbWorking       工作状态指针
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_GetJobState(IntPtr handle, ref int pbWorking);



                /*@fn       MV_SC_GetOneFrame
                **@brief    获取一帧图像数据
                **@param    handle          设备句柄
                **@param    pData           获取的图像数据指针
                **@param    pData           图像数据缓存区大小
                **@param    pstImageInfo    图像帧信息结构体指针
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_GetOneFrame(IntPtr handle,
                                                                  IntPtr pData,
                                                                  uint nDataSize,
                                                                  ref FrameOutInformation pstImageInfo);



                /*@fn       MV_SC_RegisterOutputCallBack
                **@brief    注册图像数据回调函数
                **@param    handle          设备句柄
                **@param    cbOutput        回调函数指针
                **@param    pUser           类指针
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_RegisterOutputCallBack(IntPtr handle, NativeOfficalApis.OutputDelegate outputDelegate, IntPtr pUser);

                /*@fn       MV_SC_RegisterExceptionCallBack
                **@brief    注册异常回调函数
                **@param    handle          设备句柄
                **@param    cbOutput        回调函数指针
                **@param    pUser           类指针
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int RegisterExceptionCallBack(IntPtr handle,
                                                                 NativeOfficalApis.ExceptionDelegate exceptionDelegate,
                                                                 IntPtr pUser);



                /*@fn       MV_SC_CommandExecute
                **@brief    执行命令
                **@param    handle          设备句柄
                **@param    strName         命令对应的XML节点名称
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_CommandExecute(IntPtr handle, string strName);

                /*@fn       MV_SC_GetBooleanValue
                **@brief    获取Boolean型参数值
                **@param    handle          设备句柄
                **@param    strName         参数对应的XML节点名称
                **@param    pbValue         返回的参数值指针
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_GetBooleanValue(IntPtr handle, string strName, ref bool pbValue);

                /*@fn       MV_SC_SetBooleanValue
                **@brief    设置Boolean型参数值
                **@param    handle          设备句柄
                **@param    strName         参数对应的XML节点名称
                **@param    bValue          要设置的参数值
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_SetBooleanValue(IntPtr handle, string strName, bool bValue);

                /*@fn       MV_SC_GetIntegerValue
                **@brief    获取Integer型参数值
                **@param    handle          设备句柄
                **@param    strName         参数对应的XML节点名称
                **@param    pnValue         返回的参数值指针
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_GetIntegerValue(IntPtr handle, string strName, ref uint pnValue);

                /*@fn       MV_SC_SetIntegerValue
                **@brief    设置Integer型参数值
                **@param    handle          设备句柄
                **@param    strName         参数对应的XML节点名称
                **@param    nValue          要设置的参数值
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_SetIntegerValue(IntPtr handle, string strName, uint nValue);

                /*@fn       MV_SC_GetFloatValue
                **@brief    获取Float型参数值
                **@param    handle          设备句柄
                **@param    strName         参数对应的XML节点名称
                **@param    pfValue         返回的参数值指针
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_GetFloatValue(IntPtr handle, string strName, ref float pfValue);

                /*@fn       MV_SC_SetFloatValue
                **@brief    设置Float型参数值
                **@param    handle          设备句柄
                **@param    strName         参数对应的XML节点名称
                **@param    fValue          要设置的参数值
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_SetFloatValue(IntPtr handle, string strName, float fValue);

                /*@fn       MV_SC_GetStringValue
                **@brief    获取String型参数值
                **@param    handle          设备句柄
                **@param    strName         参数对应的XML节点名称
                **@param    strValue        返回的参数值指针
                **@param    nSize           参数值指针指向的缓存区长度
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_GetStringValue(IntPtr handle, string strName, ref string strValue, uint nSize);

                /*@fn       MV_SC_SetStringValue
                **@brief    设置String型参数值
                **@param    handle          设备句柄
                **@param    strName         参数对应的XML节点名称
                **@param    strValue        要设置的参数值
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_SetStringValue(IntPtr handle, string strName, ref string strValue);

                /*@fn       MV_SC_GetEnumerationValue
                **@brief    获取Enumeration型参数值
                **@param    handle          设备句柄
                **@param    strName         参数对应的XML节点名称
                **@param    pnValue         返回的参数值指针
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_GetEnumerationValue(IntPtr handle, string strName, ref uint pnValue);

                /*@fn       MV_SC_SetEnumerationValue
                **@brief    设置Enumeration型参数值
                **@param    handle          设备句柄
                **@param    strName         参数对应的XML节点名称
                **@param    nValue          要设置的参数值
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_SetEnumerationValue(IntPtr handle, string strName, uint nValue);

                /*@fn       MV_SC_GetNetTransInfo
                **@brief    获取网络传输信息
                **@param    handle          设备句柄
                **@param    pstNetTransInfo 网络传输信息结构体指针
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_GetNetTransInfo(IntPtr handle, ref NetTranslationInformation pstNetTransInfo);

                /*@fn       MV_SC_GetOptimalPacketSize
                **@brief    获取最优的数据包大小
                **@param    handle          设备句柄
                **@param    pstNetTransInfo 网络传输信息结构体指针
                **@return   返回值小于0，表示错误码；大于0，表示推荐使用的packetsize
                */
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int MV_SC_GetOptimalPacketSize(IntPtr handle);
        }
}
