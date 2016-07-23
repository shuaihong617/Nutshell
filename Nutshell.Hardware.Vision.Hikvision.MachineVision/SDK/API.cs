using System;
using System.Runtime.InteropServices;

namespace Nutshell.Hardware.Vision.Hikvision.MachineVision.SDK
{
        public static class API
        {
                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_EnumDevices")]
                public static extern ErrorCode EnumDevices(DeviceType nTLayerType, ref DeviceInfoList deviceInfoList);

                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_IsDeviceAccessible")]
                public static extern bool IsDeviceAccessible(IntPtr handle, ref DeviceInfo pstDevInfo,AccessMode accessMode);

                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_CreateHandle")]
                public static extern ErrorCode CreateHandle(ref IntPtr handle, ref DeviceInfo pstDevInfo);

                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_DestroyHandle")]
                public static extern ErrorCode DestroyHandle(IntPtr handle);


                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_OpenDevice")]
                public static extern ErrorCode OpenDevice(IntPtr handle,AccessMode accessMode ,ushort switchoverKey = 0);

                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_CloseDevice")]
                public static extern ErrorCode CloseDevice(IntPtr handle);

                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_StartGrabbing")]
                public static extern ErrorCode StartGrabbing(IntPtr handle);

                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_StopGrabbing")]
                public static extern ErrorCode StopGrabbing(IntPtr handle);

                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_GetOneFrame")]
                public static extern ErrorCode GetOneFrame(IntPtr handle, IntPtr pData, int nDataSize, ref FrameOutInfo pFrameInfo);


                #region 异常处理

                public delegate void ExceptionCallbackFunction(ExceptionType exceptionType, IntPtr user);

                [DllImport(@"MachineVision\MvCameraControl.dll", EntryPoint = "MV_CC_RegisterExceptionCallBack")]
                public static extern bool RegisterExceptionCallBack(IntPtr handle, 
                        ExceptionCallbackFunction callBack,
                        IntPtr user);

                #endregion

        }
}
