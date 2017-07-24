using System;
using System.Runtime.InteropServices;

namespace Nutshell.Fyying.SDK
{
	public class OfficalAPI
	{
		//函数体的声明
		[DllImport("FY6400.dll")]
		public static extern IntPtr FY6400_OpenDevice(int devnum);

		[DllImport("FY6400.DLL")]
		public static extern int FY6400_CloseDevice(IntPtr hDevice);

		[DllImport("FY6400.DLL")]
		public static extern int FY6400_DI(IntPtr hDevice);

		[DllImport("FY6400.DLL")]
		public static extern int FY6400_DI_Bit(IntPtr hDevice, int dich);

		[DllImport("FY6400.DLL")]
		public static extern int FY6400_DO(IntPtr hDevice, int dodata);

		[DllImport("FY6400.DLL")]
		public static extern int FY6400_DO_Bit(IntPtr hDevice, int dochdata, int doch);

                [DllImport("FY6400.DLL")]
                public static extern int FY6400_RDO_Bit(IntPtr hDevice, int doch);
        }
}
