using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Nutshell.Windows
{
        /// <summary>
        ///         Win32 API 封装
        /// </summary>
        public static class Win32API
        {
                public const int WM_PRINT = 0x317;

                public const int SRCCOPY = 0x00CC0020;

                //移动鼠标时发生, 同WM_MOUSEFIRST   
                public const int WM_MOUSEMOVE = 0x200;
                //按下鼠标左键   
                public const int WM_LBUTTONDOWN = 0x201;
                //释放鼠标左键   
                public const int WM_LBUTTONUP = 0x202;

                public const int MK_LBUTTON = 0x0001;

                public static int MAKELONG(int x, int y)
                {
                        return ((x << 16) | y); //low order WORD 是指标的x位置； high order WORD是y位置.
                }

                [DllImport("user32.dll")]
                public static extern bool SendMessage(IntPtr hwnd, int msg, int wParam, int lParam);

                [DllImport("user32.dll")]
                public static extern bool SendMessage(IntPtr hwnd, int msg, IntPtr wParam, int lParam);

                [DllImport("user32.dll")]
                public static extern bool PostMessage(IntPtr hwnd, int msg, int wParam, int lParam);

                [DllImport("user32.dll", EntryPoint = "FindWindow")]
                public static extern IntPtr FindWindow(string ipClassName, string ipWindowName);

                [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
                public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass,
                        string lpszWindow);

                [DllImport("user32.dll")]
                public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Win32RECT rect);

                [DllImport("USER32.DLL")]
                public static extern bool SetForegroundWindow(IntPtr hWnd);

                [DllImport("user32.dll")]
                public static extern bool GetCursorPos(out Point pt);

                [DllImport("user32.dll")]
                public static extern int SetCursorPos(int x, int y);

                [DllImport("user32")]
                public static extern int mouse_event(MouseEventFlag dwFlags, int dx, int dy, int cButtons,
                        int dwExtraInfo);

                #region GDI32

                [DllImport("gdi32.dll")]
                public static extern IntPtr CreateCompatibleDC(
                        IntPtr hdc // handle to DC  
                        );

                [DllImport("gdi32.dll")]
                public static extern IntPtr CreateCompatibleBitmap(
                        IntPtr hdc, // handle to DC  
                        int nWidth, // width of bitmap, in pixels  
                        int nHeight // height of bitmap, in pixels  
                        );

                [DllImport("gdi32.dll")]
                public static extern IntPtr SelectObject(
                        IntPtr hdc, // handle to DC  
                        IntPtr hgdiobj // handle to object  
                        );

                [DllImport("user32.dll")]
                public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

                [DllImport("gdi32.dll")]
                public static extern int DeleteDC(
                        IntPtr hdc // handle to DC  
                        );

                [DllImport("user32.dll")]
                public static extern bool PrintWindow(
                        IntPtr hwnd, // Window to copy,Handle to the window that will be copied.  
                        IntPtr hdcBlt, // HDC to print into,Handle to the device context.  
                        UInt32 nFlags
                        // Optional flags,Specifies the drawing options. It can be one of the following values.  
                        );

                [DllImport("user32.dll")]
                public static extern IntPtr GetWindowDC(
                        IntPtr hwnd
                        );

                [DllImport("gdi32.dll")]
                public static extern int BitBlt(
                        IntPtr hdcDest, // handle to destination DC目标设备的句柄  
                        int nXDest, // x-coord of destination upper-left corner目标对象的左上角的X坐标  
                        int nYDest, // y-coord of destination upper-left corner目标对象的左上角的Y坐标  
                        int nWidth, // width of destination rectangle目标对象的矩形宽度  
                        int nHeight, // height of destination rectangle目标对象的矩形长度  
                        IntPtr hdcSrc, // handle to source DC源设备的句柄  
                        int nXSrc, // x-coordinate of source upper-left corner源对象的左上角的X坐标  
                        int nYSrc, // y-coordinate of source upper-left corner源对象的左上角的Y坐标  
                        UInt32 dwRop // raster operation code光栅的操作值  
                        );

                /// <summary>
                ///         Delete a GDI object
                /// </summary>
                /// <param name="o">The poniter to the GDI object to be deleted</param>
                /// <returns></returns>
                [DllImport("gdi32")]
                public static extern int DeleteObject(IntPtr o);

                #endregion

                [DllImport("kernel32.dll")]
                public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);
        }
}