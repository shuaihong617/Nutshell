﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Nutshell.Windows.Win32API;

namespace Nutshell.Windows.SDK.APIs
{
        public static class GDIAPI
        {
                [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
                public static extern IntPtr CreatePen(int nPenStyle, int nWidth, int crColor);

                [DllImport("gdi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
                public static extern int BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC,
                        int xSrc, int ySrc, CopyPixelOperation operation);

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

                [DllImport("gdi32.dll")]
                public static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest,
                        int nWidthDest, int nHeightDest,
                        IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc,
                        CopyPixelOperation code);

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

                [DllImport("user32.dll")]
                public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

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
