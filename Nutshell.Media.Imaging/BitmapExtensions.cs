// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-12-15
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-12-12
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Diagnostics;
using System.Drawing;

namespace Nutshell.Media.Imaging
{
        /// <summary>
        ///         DateTime struce extensions
        /// </summary>
        public static class BitmapExtensions
        {
                /// <summary>
                ///         BMP文件头节大小（字节）
                /// </summary>
                public const int FileHeaderTotalBytes = 14;

                /// <summary>
                ///         BMP文件信息节大小（字节）
                /// </summary>
                public const int InfoHeaderTotalBytes = 40;

                /// <summary>
                ///         Musts the specified value.
                /// </summary>
                /// <param name="bitmap">The target bitmap.</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                /// <exception cref="System.ArgumentException">值必须为 + condition</exception>
                public static int GetTotalBytes(this Bitmap bitmap)
                {
                        bitmap.MustNotNull();

                        return bitmap.Width*bitmap.Height*bitmap.PixelFormat.GetTotalBytes();
                }

                /// <summary>
                ///         Musts the specified value.
                /// </summary>
                /// <param name="bitmap">The target bitmap.</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                /// <exception cref="System.ArgumentException">值必须为 + condition</exception>
                public static int GetTotalLineBytes(this Bitmap bitmap)
                {
                        bitmap.MustNotNull();

                        return bitmap.Width*bitmap.PixelFormat.GetTotalBits();
                }
        }
}