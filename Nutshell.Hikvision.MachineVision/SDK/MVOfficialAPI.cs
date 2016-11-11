using System;
using System.Runtime.InteropServices;

namespace Nutshell.Hardware.Vision.Hikvision.MachineVision.SDK
{
        public static class MVOfficialAPI
        {
                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_EnumDevices")]
                public static extern MVErrorCode EnumDevices(MVDeviceType nTLayerType, ref MVDeviceInformationList mvDeviceInfoList);

                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_IsDeviceAccessible")]
                public static extern bool IsDeviceAccessible(IntPtr handle, ref MVDeviceInformation pstDevInfo,
                        AccessMode accessMode);

                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_CreateHandle")]
                public static extern MVErrorCode CreateHandle(ref IntPtr handle, ref MVDeviceInformation pstDevInfo);

                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_DestroyHandle")]
                public static extern MVErrorCode DestroyHandle(IntPtr handle);


                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_OpenDevice")]
                public static extern MVErrorCode OpenDevice(IntPtr handle, AccessMode accessMode, ushort switchoverKey = 0);

                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_CloseDevice")]
                public static extern MVErrorCode CloseDevice(IntPtr handle);

                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_StartGrabbing")]
                public static extern MVErrorCode StartGrabbing(IntPtr handle);

                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_StopGrabbing")]
                public static extern MVErrorCode StopGrabbing(IntPtr handle);

                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_GetOneFrame")]
                public static extern MVErrorCode GetOneFrame(IntPtr handle, IntPtr pData, int nDataSize,
                        ref MVFrameOutInformation pMVFrameInfo);

                #region 异常处理

                public delegate void ExceptionCallbackFunction(MVExceptionType mvExceptionType, IntPtr user);

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
                public static extern MVErrorCode ReadMemory(IntPtr handle,
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
                public static extern MVErrorCode WriteMemory(IntPtr handle,
                        IntPtr buffer,
                        long address,
                        long length);

                #endregion
        }
}
