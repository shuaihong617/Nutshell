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

namespace Nutshell.Windows.Win32API
{
        /// <summary>
        /// 消息API.
        /// </summary>
        public static class MessageAPI
        {
                /// <summary>
                /// Makes the long.
                /// </summary>
                /// <param name="x">The x.</param>
                /// <param name="y">The y.</param>
                /// <returns>System.Int32.</returns>
                public static int MakeLong(int x, int y)
                {
                        return ((x << 16) | y); //low order WORD 是指标的x位置； high order WORD是y位置.
                }

                /// <summary>
                /// Sends the message.
                /// </summary>
                /// <param name="hwnd">The HWND.</param>
                /// <param name="msg">The MSG.</param>
                /// <param name="wParam">The w parameter.</param>
                /// <param name="lParam">The l parameter.</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                [DllImport("user32.dll")]
                public static extern bool SendMessage(IntPtr hwnd, int msg, int wParam, int lParam);

                /// <summary>
                /// Sends the message.
                /// </summary>
                /// <param name="hwnd">The HWND.</param>
                /// <param name="msg">The MSG.</param>
                /// <param name="wParam">The w parameter.</param>
                /// <param name="lParam">The l parameter.</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                [DllImport("user32.dll")]
                public static extern bool SendMessage(IntPtr hwnd, int msg, IntPtr wParam, int lParam);

                /// <summary>
                /// Posts the message.
                /// </summary>
                /// <param name="hwnd">The HWND.</param>
                /// <param name="msg">The MSG.</param>
                /// <param name="wParam">The w parameter.</param>
                /// <param name="lParam">The l parameter.</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                [DllImport("user32.dll")]
                public static extern bool PostMessage(IntPtr hwnd, int msg, int wParam, int lParam);
        }
}
