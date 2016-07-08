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
using System.Drawing;
using System.Drawing.Imaging;
using Nutshell.Windows;

namespace Nutshell.Media.Imaging
{
        /// <summary>
        ///         DateTime struce extensions
        /// </summary>
        public static class BitmapStatisticsExtensions
        {
                /// <summary>
                /// Musts the specified value.
                /// </summary>
                /// <param name="sourceBitmap">The target bitmap.</param>
                /// <param name="result">The result.</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                /// <exception cref="System.ArgumentException">值必须为 + condition</exception>
                public static unsafe void HorizontalAverageStatistics(this Bitmap sourceBitmap,byte[] result)
                {
                        sourceBitmap.Width.MustEqual(result.Length);
                        sourceBitmap.PixelFormat.MustEqual(PixelFormat.Format8bppIndexed);


                        var rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);

                        BitmapData sourceData = sourceBitmap.LockBits(rect, ImageLockMode.ReadOnly,
                                sourceBitmap.PixelFormat);
                        var sourcePtr =(byte*) sourceData.Scan0.ToPointer();

                        for (int x = 0; x < sourceData.Width; x++)
                        {
                                uint total = 0;

                                byte* tempStart = sourcePtr + x;
                                for (int y = 0; y < sourceData.Height; y++)
                                {
                                        total += *tempStart;
                                        tempStart += sourceData.Width;
                                }
                                result[x] = (byte) (total/sourceData.Height);
                        }

                        sourceBitmap.UnlockBits(sourceData);
                }
        }
}