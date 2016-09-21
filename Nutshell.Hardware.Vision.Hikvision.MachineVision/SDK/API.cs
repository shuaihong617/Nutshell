using System;
using System.Runtime.InteropServices;

namespace Nutshell.Hardware.Vision.Hikvision.MachineVision.SDK
{
        public static class API
        {
                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_EnumDevices")]
                public static extern ErrorCode EnumDevices(DeviceType nTLayerType, ref DeviceInformationList deviceInfoList);

                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_IsDeviceAccessible")]
                public static extern bool IsDeviceAccessible(IntPtr handle, ref DeviceInformation pstDevInfo,
                        AccessMode accessMode);

                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_CreateHandle")]
                public static extern ErrorCode CreateHandle(ref IntPtr handle, ref DeviceInformation pstDevInfo);

                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_DestroyHandle")]
                public static extern ErrorCode DestroyHandle(IntPtr handle);


                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_OpenDevice")]
                public static extern ErrorCode OpenDevice(IntPtr handle, AccessMode accessMode, ushort switchoverKey = 0);

                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_CloseDevice")]
                public static extern ErrorCode CloseDevice(IntPtr handle);

                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_StartGrabbing")]
                public static extern ErrorCode StartGrabbing(IntPtr handle);

                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_StopGrabbing")]
                public static extern ErrorCode StopGrabbing(IntPtr handle);

                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_GetOneFrame")]
                public static extern ErrorCode GetOneFrame(IntPtr handle, IntPtr pData, int nDataSize,
                        ref FrameOutInformation pFrameInfo);

                #region 异常处理

                public delegate void ExceptionCallbackFunction(ExceptionType exceptionType, IntPtr user);

                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                public static extern bool RegisterExceptionCallBack(IntPtr handle,
                        ExceptionCallbackFunction callBack,
                        IntPtr user);

                #endregion

                #region 寄存器读写

                /// <summary>
                /// 读取寄存器数据
                /// </summary>
                /// <param name="handle">设备句柄</param>
                /// <param name="buffer">缓冲区指针</param>
                /// <param name="address">寄存器地址</param>
                /// <param name="length">读取长度（字节）</param>
                /// <returns>错误码，成功返回MV_OK</returns>
                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_ReadMemory")]
                public static extern ErrorCode ReadMemory(IntPtr handle,
                        IntPtr buffer,
                        long address,
                        long length);

                /// <summary>
                /// 写入寄存器数据
                /// </summary>
                /// <param name="handle">设备句柄</param>
                /// <param name="buffer">缓冲区指针</param>
                /// <param name="address">寄存器地址</param>
                /// <param name="length">写入长度（字节）</param>
                /// <returns>错误码，成功返回MV_OK</returns>
                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_WriteMemory")]
                public static extern ErrorCode WriteMemory(IntPtr handle,
                        IntPtr buffer,
                        long address,
                        long length);

                #endregion
        }
}
