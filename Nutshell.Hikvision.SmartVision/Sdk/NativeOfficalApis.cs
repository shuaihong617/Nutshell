// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-11-22
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-11-25
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Runtime.InteropServices;

namespace Nutshell.Hikvision.SmartVision.Sdk
{
        /// <summary>
        /// Class NativeOfficalApis.
        /// </summary>
        internal static class NativeOfficalApis
        {
                // 回调函数声明
                /// <summary>
                /// Delegate OutputDelegate
                /// </summary>
                /// <param name="pData">The p data.</param>
                /// <param name="pFrameInfo">The p frame information.</param>
                /// <param name="pUser">The p user.</param>
                public delegate void OutputDelegate(IntPtr pData, ref FrameOutInformation pFrameInfo, IntPtr pUser);
                /// <summary>
                /// Delegate ExceptionDelegate
                /// </summary>
                /// <param name="nMsgType">Type of the n MSG.</param>
                /// <param name="pUser">The p user.</param>
                public delegate void ExceptionDelegate(uint nMsgType, IntPtr pUser);

                /// <summary>
                /// 获取当前的SDK版本
                /// </summary>
                /// <returns>SDK版本号</returns>
                /// <remarks>返回值格式   |主   |次   |修正  | 测试
                /// |8bits|8bits|8bits|8bits
                /// 比如返回值为0x01000001，即SDK版本号为V1.0.0.1。</remarks>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern int GetSDKVersion();

                /// <summary>
                /// 枚举设备
                /// </summary>
                /// <param name="deviceInformationCollection">设备信息集合</param>
                /// <returns>错误代码</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern ErrorCode Discovery(ref DeviceInformationCollection deviceInformationCollection);

                /// <summary>
                /// 获取设备信息
                /// </summary>
                /// <param name="deviceIpAddress">设备IP地址</param>
                /// <param name="deviceInfomation">设备信息结构体</param>
                /// <returns>错误代码</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern ErrorCode GetDeviceInfo(uint deviceIpAddress, ref DeviceInfomation deviceInfomation);


                /*@fn       MV_SC_CreateHandle
                **@brief    创建设备句柄
                **@param    handle          设备句柄
                **@param    pstDevInfo      设备信息结构体指针
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                /// <summary>
                /// 创建设备句柄
                /// </summary>
                /// <param name="handle">设备句柄</param>
                /// <param name="deviceInfomation">设备信息结构体</param>
                /// <returns>错误代码</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_SC_CreateHandle")]
                internal static extern ErrorCode CreateHandle(ref IntPtr handle,ref DeviceInfomation deviceInfomation);

                /// <summary>
                /// 创建设备句柄，扩展接口，可以指定创建设备句柄的端口号
                /// </summary>
                /// <param name="handle">设备句柄</param>
                /// <param name="pstDevInfo">设备信息结构体</param>
                /// <param name="nDevPort">指定设备端口号</param>
                /// <param name="bLogEnable">是否创建Log文件</param>
                /// <returns>错误代码</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_SC_CreateHandleEx")]
                internal static extern ErrorCode CreateHandleEx(ref IntPtr handle
                                                                      , ref DeviceInfomation pstDevInfo
                                                                      , ushort nDevPort
                                                                      , bool bLogEnable);

                /// <summary>
                /// 销毁设备句柄
                /// </summary>
                /// <param name="handle">要销毁的设备句柄</param>
                /// <returns>错误代码</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_SC_DestroyHandle")]
                internal static extern ErrorCode DestroyHandle(IntPtr handle);

                /// <summary>
                /// 连接设备
                /// </summary>
                /// <param name="handle">设备句柄</param>
                /// <returns>错误代码</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_SC_Connect")]
                internal static extern ErrorCode Connect(IntPtr handle);

                /// <summary>
                /// 断开连接
                /// </summary>
                /// <param name="handle">设备句柄</param>
                /// <returns>错误代码</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_SC_Disconnect")]
                internal static extern ErrorCode Disconnect(IntPtr handle);

                
                /*@fn       MV_SC_StartJob
                **@brief    开始工作流程
                **@param    handle          设备句柄
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                /// <summary>
                /// ms the v_ s c_ start job.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <returns>System.Int32.</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_SC_StartJob")]
                internal static extern int MV_SC_StartJob(IntPtr handle);

                /*@fn       MV_SC_StopJob
                **@brief    停止工作流程
                **@param    handle          设备句柄
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                /// <summary>
                /// ms the v_ s c_ stop job.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <returns>System.Int32.</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_SC_StopJob")]
                internal static extern int MV_SC_StopJob(IntPtr handle);

                /*@fn       MV_SC_GetJobState
                **@brief    获取相机当前的工作状态，pbWorking返回值为1，表示处于工作状态，为0表示非工作状态
                **@param    handle          设备句柄
                **@param    pbWorking       工作状态指针
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                /// <summary>
                /// ms the state of the v_ s c_ get job.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="pbWorking">The pb working.</param>
                /// <returns>System.Int32.</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_SC_GetJobState")]
                internal static extern int MV_SC_GetJobState(IntPtr handle, ref int pbWorking);



                /*@fn       MV_SC_GetOneFrame
                **@brief    获取一帧图像数据
                **@param    handle          设备句柄
                **@param    pData           获取的图像数据指针
                **@param    pData           图像数据缓存区大小
                **@param    pstImageInfo    图像帧信息结构体指针
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                /// <summary>
                /// ms the v_ s c_ get one frame.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="pData">The p data.</param>
                /// <param name="nDataSize">Size of the n data.</param>
                /// <param name="pstImageInfo">The PST image information.</param>
                /// <returns>System.Int32.</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern ErrorCode MV_SC_GetOneFrame(IntPtr handle,
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
                /// <summary>
                /// ms the v_ s c_ register output call back.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="outputDelegate">The output delegate.</param>
                /// <param name="pUser">The p user.</param>
                /// <returns>System.Int32.</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_SC_RegisterOutputCallBack")]
                internal static extern ErrorCode MV_SC_RegisterOutputCallBack(IntPtr handle,OutputDelegate outputDelegate,IntPtr pUser);

                /*@fn       MV_SC_RegisterExceptionCallBack
                **@brief    注册异常回调函数
                **@param    handle          设备句柄
                **@param    cbOutput        回调函数指针
                **@param    pUser           类指针
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                /// <summary>
                /// Registers the exception call back.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="exceptionDelegate">The exception delegate.</param>
                /// <param name="pUser">The p user.</param>
                /// <returns>System.Int32.</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                internal static extern ErrorCode RegisterExceptionCallBack(IntPtr handle,
                                                                 ExceptionDelegate exceptionDelegate,                
                                                                 IntPtr pUser);



                /*@fn       MV_SC_CommandExecute
                **@brief    执行命令
                **@param    handle          设备句柄
                **@param    strName         命令对应的XML节点名称
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                /// <summary>
                /// ms the v_ s c_ command execute.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="strName">Name of the string.</param>
                /// <returns>System.Int32.</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_SC_CommandExecute")]
                internal static extern ErrorCode MV_SC_CommandExecute(IntPtr handle, string strName);

                /*@fn       MV_SC_GetBooleanValue
                **@brief    获取Boolean型参数值
                **@param    handle          设备句柄
                **@param    strName         参数对应的XML节点名称
                **@param    pbValue         返回的参数值指针
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                /// <summary>
                /// ms the v_ s c_ get boolean value.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="strName">Name of the string.</param>
                /// <param name="pbValue">if set to <c>true</c> [pb value].</param>
                /// <returns>System.Int32.</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_SC_GetBooleanValue")]
                internal static extern ErrorCode MV_SC_GetBooleanValue(IntPtr handle, string strName, ref bool pbValue);

                /*@fn       MV_SC_SetBooleanValue
                **@brief    设置Boolean型参数值
                **@param    handle          设备句柄
                **@param    strName         参数对应的XML节点名称
                **@param    bValue          要设置的参数值
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                /// <summary>
                /// ms the v_ s c_ set boolean value.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="strName">Name of the string.</param>
                /// <param name="bValue">if set to <c>true</c> [b value].</param>
                /// <returns>System.Int32.</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_SC_SetBooleanValue")]
                internal static extern ErrorCode MV_SC_SetBooleanValue(IntPtr handle, string strName, bool bValue);

                /*@fn       MV_SC_GetIntegerValue
                **@brief    获取Integer型参数值
                **@param    handle          设备句柄
                **@param    strName         参数对应的XML节点名称
                **@param    pnValue         返回的参数值指针
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                /// <summary>
                /// ms the v_ s c_ get integer value.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="strName">Name of the string.</param>
                /// <param name="pnValue">The pn value.</param>
                /// <returns>System.Int32.</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_SC_GetIntegerValue")]
                internal static extern ErrorCode MV_SC_GetIntegerValue(IntPtr handle, string strName, ref uint pnValue);

                /*@fn       MV_SC_SetIntegerValue
                **@brief    设置Integer型参数值
                **@param    handle          设备句柄
                **@param    strName         参数对应的XML节点名称
                **@param    nValue          要设置的参数值
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                /// <summary>
                /// ms the v_ s c_ set integer value.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="strName">Name of the string.</param>
                /// <param name="nValue">The n value.</param>
                /// <returns>System.Int32.</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_SC_SetIntegerValue")]
                internal static extern ErrorCode MV_SC_SetIntegerValue(IntPtr handle, string strName, uint nValue);

                /*@fn       MV_SC_GetFloatValue
                **@brief    获取Float型参数值
                **@param    handle          设备句柄
                **@param    strName         参数对应的XML节点名称
                **@param    pfValue         返回的参数值指针
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                /// <summary>
                /// ms the v_ s c_ get float value.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="strName">Name of the string.</param>
                /// <param name="pfValue">The pf value.</param>
                /// <returns>System.Int32.</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_SC_GetFloatValue")]
                internal static extern ErrorCode MV_SC_GetFloatValue(IntPtr handle, string strName, ref float pfValue);

                /*@fn       MV_SC_SetFloatValue
                **@brief    设置Float型参数值
                **@param    handle          设备句柄
                **@param    strName         参数对应的XML节点名称
                **@param    fValue          要设置的参数值
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                /// <summary>
                /// ms the v_ s c_ set float value.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="strName">Name of the string.</param>
                /// <param name="fValue">The f value.</param>
                /// <returns>System.Int32.</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_SC_SetFloatValue")]
                internal static extern ErrorCode MV_SC_SetFloatValue(IntPtr handle, string strName, float fValue);

                /*@fn       MV_SC_GetStringValue
                **@brief    获取String型参数值
                **@param    handle          设备句柄
                **@param    strName         参数对应的XML节点名称
                **@param    strValue        返回的参数值指针
                **@param    nSize           参数值指针指向的缓存区长度
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                /// <summary>
                /// ms the v_ s c_ get string value.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="strName">Name of the string.</param>
                /// <param name="strValue">The string value.</param>
                /// <param name="nSize">Size of the n.</param>
                /// <returns>System.Int32.</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_SC_GetStringValue")]
                internal static extern ErrorCode MV_SC_GetStringValue(IntPtr handle, string strName, ref string strValue, uint nSize);

                /*@fn       MV_SC_SetStringValue
                **@brief    设置String型参数值
                **@param    handle          设备句柄
                **@param    strName         参数对应的XML节点名称
                **@param    strValue        要设置的参数值
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                /// <summary>
                /// ms the v_ s c_ set string value.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="strName">Name of the string.</param>
                /// <param name="strValue">The string value.</param>
                /// <returns>System.Int32.</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_SC_SetStringValue")]
                internal static extern ErrorCode MV_SC_SetStringValue(IntPtr handle, string strName, ref string strValue);

                /*@fn       MV_SC_GetEnumerationValue
                **@brief    获取Enumeration型参数值
                **@param    handle          设备句柄
                **@param    strName         参数对应的XML节点名称
                **@param    pnValue         返回的参数值指针
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                /// <summary>
                /// ms the v_ s c_ get enumeration value.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="strName">Name of the string.</param>
                /// <param name="pnValue">The pn value.</param>
                /// <returns>System.Int32.</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_SC_GetEnumerationValue")]
                internal static extern ErrorCode MV_SC_GetEnumerationValue(IntPtr handle, string strName, ref uint pnValue);

                /*@fn       MV_SC_SetEnumerationValue
                **@brief    设置Enumeration型参数值
                **@param    handle          设备句柄
                **@param    strName         参数对应的XML节点名称
                **@param    nValue          要设置的参数值
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                /// <summary>
                /// ms the v_ s c_ set enumeration value.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="strName">Name of the string.</param>
                /// <param name="nValue">The n value.</param>
                /// <returns>System.Int32.</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_SC_SetEnumerationValue")]
                internal static extern ErrorCode MV_SC_SetEnumerationValue(IntPtr handle, string strName, uint nValue);

                /*@fn       MV_SC_GetNetTransInfo
                **@brief    获取网络传输信息
                **@param    handle          设备句柄
                **@param    pstNetTransInfo 网络传输信息结构体指针
                **@return   成功：返回MV_OK;失败：返回错误码
                */
                /// <summary>
                /// ms the v_ s c_ get net trans information.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="pstNetTransInfo">The PST net trans information.</param>
                /// <returns>System.Int32.</returns>
                [DllImport(@"MvCameraControl.dll", EntryPoint = "MV_SC_GetNetTransInfo")]
                internal static extern ErrorCode MV_SC_GetNetTransInfo(IntPtr handle, ref NetTranslationInformation pstNetTransInfo);
        }
}
