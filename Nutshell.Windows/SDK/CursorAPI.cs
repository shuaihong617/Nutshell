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

using System.Drawing;
using System.Runtime.InteropServices;

namespace Nutshell.Windows.SDK
{
        /// <summary>
        /// 光标API.
        /// </summary>
        public static class CursorApi
        {
                /// <summary>
                /// Gets the cursor position.
                /// </summary>
                /// <param name="pt">The pt.</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                [DllImport("user32.dll")]
                public static extern bool GetCursorPos(out Point pt);

                /// <summary>
                /// Sets the cursor position.
                /// </summary>
                /// <param name="x">The x.</param>
                /// <param name="y">The y.</param>
                /// <returns>System.Int32.</returns>
                [DllImport("user32.dll")]
                public static extern int SetCursorPos(int x, int y);
        }
}
