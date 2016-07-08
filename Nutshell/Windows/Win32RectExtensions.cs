// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-01-18
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-01-16
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Drawing;

namespace Nutshell.Windows
{
        /// <summary>
        ///         WIN32API矩形扩展方法
        /// </summary>
        public static class Win32RectExtensions
        {
                public static Rectangle ToRectangle(this Win32RECT rect)
                {
                        return new Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top);
                }
        }
}