using System;
using System.Runtime.InteropServices;

namespace Nutshell.Windows
{
        public static class Win32GDIAPI
        {
                [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
                public static extern IntPtr CreatePen(int nPenStyle, int nWidth, int crColor);

                [DllImport("gdi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
                public static extern int BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC,
                        int xSrc, int ySrc, RasterOperationCode code);

                [DllImport("gdi32.dll")]
                public static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest,
                        int nWidthDest, int nHeightDest,
                        IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc,
                        RasterOperationCode code);

                [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
                public static extern IntPtr CreateSolidBrush(int crColor);


                [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
                public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);

                [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
                public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

                [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
                public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

                [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
                public static extern IntPtr DeleteObject(IntPtr hObject);

                [DllImport("gdi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
                public static extern int SetTextColor(IntPtr hDC, int crColor);

                [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
                public static extern IntPtr DeleteDC(IntPtr hDC);

                [DllImport("gdi32.dll")]
                public static extern IntPtr CreateFont(int nHeight, int nWidth, int nEscapement,
                        int nOrientation, int fnWeight, uint fdwItalic, uint fdwUnderline, uint
                                fdwStrikeOut, uint fdwCharSet, uint fdwOutputPrecision, uint
                                        fdwClipPrecision, uint fdwQuality, uint fdwPitchAndFamily, string lpszFace);

                [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
                public static extern bool TextOut(IntPtr hdc, int nXStart, int nYStart,
                        string lpString, int cbString);
        }
}
