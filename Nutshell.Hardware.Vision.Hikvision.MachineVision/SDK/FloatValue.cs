using System.Runtime.InteropServices;

namespace Nutshell.Hardware.Vision.Hikvision.MachineVision.SDK
{
        /// <summary>
        /// 设备信息结构体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct FloatValue
        {
                /// <summary>
                /// 主版本号
                /// </summary>
                public float Current;

                /// <summary>
                /// 次版本号
                /// </summary>
                public ushort Max;

                /// <summary>
                /// MAC地址高32位
                /// </summary>
                public uint Min;

                
                

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] 
                public uint[] Reserved;

                
        }
}
