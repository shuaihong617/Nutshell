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

using System.Runtime.InteropServices;

namespace Nutshell.Windows.Win32API
{
        /// <summary>
        /// 鼠标API.
        /// </summary>
        public static class MouseAPI
        {
                /// <summary>
                ///         Mouse_events the specified dw flags.
                /// </summary>
                /// <param name="dwFlags">The dw flags.</param>
                /// <param name="dx">The dx.</param>
                /// <param name="dy">The dy.</param>
                /// <param name="cButtons">The c buttons.</param>
                /// <param name="dwExtraInfo">The dw extra information.</param>
                /// <returns>System.Int32.</returns>
                [DllImport("user32")]
                public static extern int mouse_event(MouseEventFlag dwFlags, int dx, int dy, int cButtons,
                        int dwExtraInfo);
        }
}
