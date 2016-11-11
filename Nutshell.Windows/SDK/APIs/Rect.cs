using System.Runtime.InteropServices;

namespace Nutshell.Windows.SDK.APIs
{
        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
                public int left;
                public int top;
                public int right;
                public int bottom;
        }
}