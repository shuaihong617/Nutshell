// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-09-04
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-09-04
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Runtime.InteropServices;
using Nutshell.Windows.SDK.APIs;

namespace Nutshell.Windows.SDK
{
        /// <summary>
        /// 窗体API.
        /// </summary>
        public static class WindowApi
        {
                /// <summary>
                /// Finds the window.
                /// </summary>
                /// <param name="ipClassName">Name of the ip class.</param>
                /// <param name="ipWindowName">Name of the ip window.</param>
                /// <returns>IntPtr.</returns>
                [DllImport("user32.dll", EntryPoint = "FindWindow")]
                public static extern IntPtr FindWindow(string ipClassName, string ipWindowName);

                /// <summary>
                /// Finds the window ex.
                /// </summary>
                /// <param name="hwndParent">The HWND parent.</param>
                /// <param name="hwndChildAfter">The HWND child after.</param>
                /// <param name="lpszClass">The LPSZ class.</param>
                /// <param name="lpszWindow">The LPSZ window.</param>
                /// <returns>IntPtr.</returns>
                [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
                public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass,
                        string lpszWindow);

                /// <summary>
                /// Gets the window rect.
                /// </summary>
                /// <param name="hWnd">The h WND.</param>
                /// <param name="rect">The rect.</param>
                /// <returns>IntPtr.</returns>
                [DllImport("user32.dll")]
                public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

                /// <summary>
                /// Sets the foreground window.
                /// </summary>
                /// <param name="hWnd">The h WND.</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                [DllImport("user32.DLL")]
                public static extern bool SetForegroundWindow(IntPtr hWnd);

                [DllImport("user32.dll")]
                public static extern IntPtr GetWindowDC(
                        IntPtr hwnd
                        );

                [DllImport("user32.dll")]
                public static extern bool PrintWindow(
                        IntPtr hwnd, // Window to copy,Handle to the window that will be copied.  
                        IntPtr hdcBlt, // HDC to print into,Handle to the device context.  
                        UInt32 nFlags // Optional flags,Specifies the drawing options. It can be one of the following values.  
                        );
        }
}
