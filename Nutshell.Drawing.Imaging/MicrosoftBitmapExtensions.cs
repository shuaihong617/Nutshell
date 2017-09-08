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

using System;
using System.Diagnostics;
using System.Drawing;
using Nutshell.Collections;

using MicrosoftBitmap = System.Drawing.Bitmap;
using MicrosoftPixelFormat = System.Drawing.Imaging.PixelFormat;

namespace Nutshell.Drawing.Imaging
{
        /// <summary>
        ///         微软位图扩展
        /// </summary>
        public static class MicrosoftBitmapExtensions
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
                /// Clears the specified r.
                /// </summary>
                /// <param name="r">The r.</param>
                /// <param name="g">The g.</param>
                /// <param name="b">The b.</param>
                public static void  Clear(this MicrosoftBitmap bitmap, Color color)
                {
                        switch (bitmap.PixelFormat)
                        {
                                case MicrosoftPixelFormat.Format24bppRgb:
                                        RgbClear(bitmap, color);
                                        break;

                                case MicrosoftPixelFormat.Format32bppArgb:
                                        RgbClear(bitmap, color);
                                        break;

                                case MicrosoftPixelFormat.Format32bppRgb:
                                        RgbClear(bitmap, color);
                                        break;

                                default:
                                        throw new Exception("不支持的像素格式");
                        }
                }

                public static void FastClear(this MicrosoftBitmap bitmap, Color color)
                {
                        
                }

                private static void RgbClear(MicrosoftBitmap bitmap, Color color)
                {
                        Debug.Assert(bitmap.PixelFormat == MicrosoftPixelFormat.Format24bppRgb
                                || bitmap.PixelFormat == MicrosoftPixelFormat.Format32bppArgb
                                || bitmap.PixelFormat == MicrosoftPixelFormat.Format32bppRgb);

                        for (int x = 0; x < bitmap.Width; x++)
                        {
                                for (int y = 0; x < bitmap.Height; x++)
                                {
                                        bitmap.SetPixel(x, y, color);
                                }
                        }
                }
        }
}