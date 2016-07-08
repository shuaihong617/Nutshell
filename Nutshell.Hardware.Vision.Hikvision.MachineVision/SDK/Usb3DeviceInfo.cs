using System.Runtime.InteropServices;

namespace Nutshell.Hardware.Vision.Mvsion.SDK
{
        public struct Usb3DeviceInfo
        {
                public byte CrtlInEndPoint ;//控制输入端点
                public byte CrtlOutEndPoint ;//控制输出端点
                public byte StreamEndPoint ;//流端点
                public byte EventEndPoint ;//事件端点
                public ushort idVendor ;//供应商ID号
                public ushort idProduct ;//产品ID号
                public uint nDeviceNumber ;//设备序列号 

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
                public byte chDeviceGUID ;//设备GUID号

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
                public byte[] chVendorName ;//供应商名字

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
                public byte[] chModelName ;//型号名字

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
                public byte[] chFamilyName ;//家族名字

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
                public byte[] chDeviceVersion ;//设备版本号

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
                public byte[] chManufacturerName ;//制造商名字

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
                public byte[] chSerialNumber ;//序列号

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
                public byte[] chUserDefinedName ;//用户自定义名字
                public uint nbcdUSB ;//支持的USB协议

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
                public uint[] nReserved ;//保留字节
        }
}
