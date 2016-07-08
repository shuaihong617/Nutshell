using System.Runtime.InteropServices;

namespace Nutshell.Windows
{
        [StructLayout(LayoutKind.Sequential)]
        public struct Win32RECT
        {
                public int left;
                public int top;
                public int right;
                public int bottom;
        }
}