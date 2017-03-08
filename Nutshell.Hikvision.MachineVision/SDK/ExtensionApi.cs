using System;
using System.Runtime.InteropServices;

namespace Nutshell.Hikvision.MachineVision.SDK
{
        public static class ExtensionApi
        {
                public static extern ErrorCode EnumDevices(DeviceType nTLayerType, ref DeviceInformationCollection deviceInfoCollection);

                public static extern bool IsDeviceAccessible(IntPtr handle, ref DeviceInformation pstDevInfo,
                        AccessMode accessMode);

                public static ErrorCode CreateHandle(ref IntPtr handle, ref DeviceInformation pstDevInfo)
                {
                        string operation = "创建句柄";

                        var errorCode = CreateHandle(ref handle, ref pstDevInfo);
                        if (errorCode != ErrorCode.MV_OK)
                        {
                                ErrorFailWithReason(operation, errorCode);
                        }
                        else
                        {
                                InfoSuccess(operation);
                        }
                }

                public static extern ErrorCode DestroyHandle(IntPtr handle);


                public static extern ErrorCode OpenDevice(IntPtr handle, AccessMode accessMode, ushort switchoverKey = 0);

                public static extern ErrorCode CloseDevice(IntPtr handle);

                public static extern ErrorCode StartGrabbing(IntPtr handle);

                public static extern ErrorCode StopGrabbing(IntPtr handle);

                public static extern ErrorCode GetOneFrame(IntPtr handle, IntPtr pData, int nDataSize,
                        ref FrameOutInformation pFrameInfo);

		#region 万能接口

		public static extern ErrorCode SetIntValue(IntPtr handle, string strValue, uint value);

		public static extern ErrorCode SetEnumValue(IntPtr handle, string strValue, uint value);

		public static extern ErrorCode SetCommandValue(IntPtr handle, string strValue);

		#endregion

		#region GIGE独有接口

		public static extern ErrorCode GetGevSCPSPacketSize(IntPtr handle, ref IntValue value);

		public static extern ErrorCode SetGevSCPSPacketSize(IntPtr handle, uint value);

		#endregion

		

               
        }
}
