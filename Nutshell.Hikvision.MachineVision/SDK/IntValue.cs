using System;
using System.Runtime.InteropServices;

namespace Nutshell.Hikvision.MachineVision.SDK
{
        // 整形变量结构体
        [StructLayout(LayoutKind.Sequential)]
        public struct IntValue
        {
                public uint Current; // 当前值
                public uint Maximum; // 最大值
                public uint Minimum; // 最小值
                public uint Increase; // 增量

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] 
                public uint[] Reserved; // 保留


                public override string ToString()
                {
                        return String.Format("当前值：{0}，最大值：{1}，最小值：{2}，增量：{3}", Current,Maximum, Minimum, Increase);
                }
        }
}
