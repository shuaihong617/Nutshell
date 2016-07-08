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
using System.Drawing.Imaging;
using Emgu.CV;
using Emgu.CV.Structure;
using Nutshell.Windows;

namespace Nutshell.Media.Imaging
{
        /// <summary>
        ///         DateTime struce extensions
        /// </summary>
        public static unsafe class BitmapCopyExtensions
        {
                /// <summary>
                ///         Musts the specified value.
                /// </summary>
                /// <param name="targetBitmap">The target bitmap.</param>
                /// <param name="sourceBitmap">The source bitmap.</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                /// <exception cref="System.ArgumentException">值必须为 + condition</exception>
                public static void CopyTo(this Bitmap sourceBitmap, Bitmap targetBitmap)
                {
                        targetBitmap.Width.MustEqual(sourceBitmap.Width);
                        targetBitmap.Height.MustEqual(sourceBitmap.Height);

                        switch (sourceBitmap.PixelFormat)
                        {
                                case PixelFormat.Format8bppIndexed:
                                        switch (targetBitmap.PixelFormat)
                                        {
                                                case PixelFormat.Format8bppIndexed:
                                                        CopyWithSamePixelFormat(sourceBitmap, targetBitmap);
                                                        break;

                                                case PixelFormat.Format32bppRgb:
                                                        CopyGray8ToRgb32(sourceBitmap, targetBitmap);
                                                        break;
                                        }
                                        break;

                                case PixelFormat.Format24bppRgb:
                                        switch (targetBitmap.PixelFormat)
                                        {
                                                case PixelFormat.Format32bppRgb:
                                                        CopyRgb24ToRgb32(sourceBitmap, targetBitmap);
                                                        break;
                                        }
                                        break;

                                case PixelFormat.Format32bppRgb:
                                        switch (targetBitmap.PixelFormat)
                                        {
                                                case PixelFormat.Format8bppIndexed:
                                                        CopyRgb32ToGray8(sourceBitmap, targetBitmap);
                                                        break;

                                                case PixelFormat.Format32bppRgb:
                                                        CopyWithSamePixelFormat(sourceBitmap, targetBitmap);
                                                        break;
                                        }
                                        break;
                        }
                }

                private static unsafe void CopyWithSamePixelFormat(Bitmap sourceBitmap, Bitmap targetBitmap)
                {
                        targetBitmap.Width.MustEqual(sourceBitmap.Width);
                        targetBitmap.Height.MustEqual(sourceBitmap.Height);
                        targetBitmap.PixelFormat.MustEqual(sourceBitmap.PixelFormat);

                        var rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);

                        BitmapData sourceData = sourceBitmap.LockBits(rect, ImageLockMode.ReadOnly,
                                sourceBitmap.PixelFormat);
                        BitmapData targetData = targetBitmap.LockBits(rect, ImageLockMode.WriteOnly,
                                targetBitmap.PixelFormat);


                        var sourcePtr = (byte*) sourceData.Scan0.ToPointer();
                        var targetPtr = (byte*) targetData.Scan0.ToPointer();

                        int length = targetBitmap.Width*targetBitmap.Height*targetBitmap.PixelFormat.GetTotalBits()/8;

                        for (int i = 0; i < length; i++)
                        {
                                *targetPtr++ = *sourcePtr++;
                        }

                        targetBitmap.UnlockBits(targetData);
                        sourceBitmap.UnlockBits(sourceData);
                }

                private static void CopyRgb32ToGray8(Bitmap sourceBitmap, Bitmap targetBitmap)
                {
                        targetBitmap.Width.MustEqual(sourceBitmap.Width);
                        targetBitmap.Height.MustEqual(sourceBitmap.Height);
                        targetBitmap.PixelFormat.MustEqual(PixelFormat.Format8bppIndexed);

                        sourceBitmap.PixelFormat.MustEqual(PixelFormat.Format32bppRgb);


                        var rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);

                        BitmapData sourceData = sourceBitmap.LockBits(rect, ImageLockMode.ReadOnly,
                                sourceBitmap.PixelFormat);
                        BitmapData targetData = targetBitmap.LockBits(rect, ImageLockMode.WriteOnly,
                                targetBitmap.PixelFormat);


                        var sourcePtr = (byte*) sourceData.Scan0.ToPointer();
                        var targetPtr = (byte*) targetData.Scan0.ToPointer();

                        int length = targetBitmap.GetTotalBytes();

                        for (int i = 0; i < length; i++)
                        {
                                *targetPtr++ = *(sourcePtr += 4);
                        }

                        targetBitmap.UnlockBits(targetData);
                        sourceBitmap.UnlockBits(sourceData);
                }

                private static unsafe void CopyGray8ToRgb32(Bitmap sourceBitmap, Bitmap targetBitmap)
                {
                        targetBitmap.Width.MustEqual(sourceBitmap.Width);
                        targetBitmap.Height.MustEqual(sourceBitmap.Height);
                        targetBitmap.PixelFormat.MustEqual(PixelFormat.Format32bppRgb);

                        sourceBitmap.PixelFormat.MustEqual(PixelFormat.Format8bppIndexed);


                        var rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);

                        BitmapData sourceData = sourceBitmap.LockBits(rect, ImageLockMode.ReadOnly,
                                sourceBitmap.PixelFormat);
                        BitmapData targetData = targetBitmap.LockBits(rect, ImageLockMode.WriteOnly,
                                targetBitmap.PixelFormat);


                        var sourcePtr = (byte*) sourceData.Scan0.ToPointer();
                        var targetPtr = (byte*) targetData.Scan0.ToPointer();

                        int length = targetBitmap.Width*targetBitmap.Height;

                        for (int i = 0; i < length; i++)
                        {
                                byte t = *sourcePtr++;
                                *targetPtr++ = t; //r
                                *targetPtr++ = t; //g
                                *targetPtr++ = t; //b
                                *targetPtr++ = 0; //a
                        }

                        targetBitmap.UnlockBits(targetData);
                        sourceBitmap.UnlockBits(sourceData);
                }

                private static unsafe void CopyRgb24ToRgb32(Bitmap sourceBitmap, Bitmap targetBitmap)
                {
                        targetBitmap.Width.MustEqual(sourceBitmap.Width);
                        targetBitmap.Height.MustEqual(sourceBitmap.Height);
                        targetBitmap.PixelFormat.MustEqual(PixelFormat.Format32bppRgb);

                        sourceBitmap.PixelFormat.MustEqual(PixelFormat.Format24bppRgb);


                        var rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);

                        BitmapData sourceData = sourceBitmap.LockBits(rect, ImageLockMode.ReadOnly,
                                sourceBitmap.PixelFormat);
                        BitmapData targetData = targetBitmap.LockBits(rect, ImageLockMode.WriteOnly,
                                targetBitmap.PixelFormat);


                        var sourcePtr = (byte*)sourceData.Scan0.ToPointer();
                        var targetPtr = (byte*)targetData.Scan0.ToPointer();

                        int length = targetBitmap.Width * targetBitmap.Height;

                        for (int i = 0; i < length; i++)
                        {
                                *targetPtr++ = *sourcePtr++;
                                *targetPtr++ = *sourcePtr++;
                                *targetPtr++ = *sourcePtr++;
                                *targetPtr++ = 0;
                        }

                        targetBitmap.UnlockBits(targetData);
                        sourceBitmap.UnlockBits(sourceData);
                }

                /// <summary>
                /// Musts the specified value.
                /// </summary>
                /// <param name="sourceBitmap">The target bitmap.</param>
                /// <param name="targetBitmap">The source bitmap.</param>
                /// <param name="region">The region.</param>
                /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
                /// <exception cref="System.ArgumentException">值必须为 + condition</exception>
                public static void CopyTo(this Bitmap sourceBitmap, Bitmap targetBitmap, Region region)
                {
                        Debug.Assert(sourceBitmap != null);

                        Debug.Assert(targetBitmap != null);
                        Debug.Assert(targetBitmap.Width <= sourceBitmap.Width);
                        Debug.Assert(targetBitmap.Height <= sourceBitmap.Height);
                        Debug.Assert(targetBitmap.PixelFormat == sourceBitmap.PixelFormat);

                        Debug.Assert(region != null);
                        Debug.Assert(region.Width == targetBitmap.Width);
                        Debug.Assert(region.Height == targetBitmap.Height);


                        var sourceRect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);
                        BitmapData sourceData = sourceBitmap.LockBits(sourceRect, ImageLockMode.ReadOnly,
                                sourceBitmap.PixelFormat);

                        var targetRect = new Rectangle(0, 0, targetBitmap.Width, targetBitmap.Height);
                        BitmapData targetData = targetBitmap.LockBits(targetRect, ImageLockMode.WriteOnly,
                                targetBitmap.PixelFormat);

                        var sourcePtr = (byte*)sourceData.Scan0.ToPointer();
                        var targetPtr = (byte*)targetData.Scan0.ToPointer();

                        int factor = sourceBitmap.PixelFormat.GetTotalBits()/8;

                        sourcePtr = sourcePtr + (region.Top * sourceBitmap.Width + region.Left)*factor;
                        for (int y = 0; y < region.Height; y++)
                        {
                                int length = region.Width * factor;

                                for (int x = 0; x < length; x++)
                                {
                                        *targetPtr++ = *sourcePtr++;
                                }
                                sourcePtr += (sourceBitmap.Width - region.Width)* factor;
                        }             

                        sourceBitmap.UnlockBits(targetData);

                        targetBitmap.UnlockBits(sourceData);
                }

                public static unsafe void CopyTo(this Bitmap sourceBitmap, Image<Gray, Byte> targetImage)
                {
                        Debug.Assert(sourceBitmap.PixelFormat == PixelFormat.Format8bppIndexed);

                        Debug.Assert(targetImage != null);
                        Debug.Assert(targetImage.Width == sourceBitmap.Width);
                        Debug.Assert(targetImage.Height == sourceBitmap.Height);

                        var rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);

                        BitmapData sourceData = sourceBitmap.LockBits(rect, ImageLockMode.ReadOnly,
                                sourceBitmap.PixelFormat);
                        var sourcePtr = (byte*)sourceData.Scan0.ToPointer();

                        int xmax = targetImage.Width;
                        int ymax = targetImage.Height;


                        byte[, ,] destData = targetImage.Data;

                        for (int y = 0; y < ymax; y++)
                        {
                                for (int x = 0; x < xmax; x++)
                                {
                                        destData[y, x, 0] = *sourcePtr++;
                                }
                        }

                        sourceBitmap.UnlockBits(sourceData);
                }

                public static unsafe void CopyTo(this Bitmap sourceBitmap, Image<Gray, Byte> targetImage,
                        Region rectangle)
                {
                        Debug.Assert(sourceBitmap.PixelFormat == PixelFormat.Format8bppIndexed);

                        Debug.Assert(targetImage != null);
                        Debug.Assert(targetImage.Width == rectangle.Width);
                        Debug.Assert(targetImage.Height == rectangle.Height);

                        var rect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);

                        BitmapData sourceData = sourceBitmap.LockBits(rect, ImageLockMode.ReadOnly,
                                sourceBitmap.PixelFormat);
                        var sourcePtr = (byte*) sourceData.Scan0.ToPointer();

                        sourcePtr = sourcePtr + (rectangle.Top*sourceBitmap.Width + rectangle.Left);
                        int lineStepWidth = (sourceBitmap.Width - rectangle.Width);
                        int xmax = targetImage.Width;
                        int ymax = targetImage.Height;

                        byte[,,] destData = targetImage.Data;

                        for (int y = 0; y < ymax; y++)
                        {
                                for (int x = 0; x < xmax; x++)
                                {
                                        destData[y, x, 0] = *sourcePtr++;
                                }
                                sourcePtr += lineStepWidth;
                        }
                }

                /// <summary>
                /// Gray8s the copy to gray8.
                /// </summary>
                /// <param name="targetBitmap"></param>
                /// <param name="souceArray">The target image.</param>
                /// <param name="region">The copy region.</param>
                /// <exception cref="System.NotImplementedException"></exception>
                public static void CopyFrom(this Bitmap targetBitmap, byte[] souceArray, int sourceWidth, Region region)
                {
                        Debug.Assert(targetBitmap != null);

                        Debug.Assert(souceArray!=null);
                        Debug.Assert(souceArray.Length >= targetBitmap.GetTotalBytes());


                        Debug.Assert(region != null);
                        Debug.Assert(region.Width == targetBitmap.Width);
                        Debug.Assert(region.Height == targetBitmap.Height);

                        var rect = new Rectangle(0, 0, targetBitmap.Width, targetBitmap.Height);
                        BitmapData targetData = targetBitmap.LockBits(rect, ImageLockMode.WriteOnly,
                                targetBitmap.PixelFormat);
                        var targetPtr = (byte*)targetData.Scan0.ToPointer();

                        int factor = targetBitmap.PixelFormat.GetTotalBytes();

                        var sourceIndex = (region.Top * sourceWidth + region.Left)* factor;

                        int copyLength = region.Width * factor;
                        int skipLength = (sourceWidth - region.Width) * factor;

                        for (int y = 0; y < region.Height; y++)
                        {
                                for (int x = 0; x < copyLength; x++)
                                {
                                        *targetPtr++ = souceArray[sourceIndex++];
                                }
                                sourceIndex += skipLength;
                        }

                        targetBitmap.UnlockBits(targetData);
                }

                public static void CopyFrom(this Bitmap targetBitmap, IntPtr souceIntPtr, int sourceWidth, Region region)
                {
                        Debug.Assert(targetBitmap != null);

                        Debug.Assert(souceIntPtr != IntPtr.Zero);

                        Debug.Assert(region != null);
                        Debug.Assert(region.Width == targetBitmap.Width);
                        Debug.Assert(region.Height == targetBitmap.Height);

                        var rect = new Rectangle(0, 0, targetBitmap.Width, targetBitmap.Height);
                        BitmapData targetData = targetBitmap.LockBits(rect, ImageLockMode.WriteOnly,
                                targetBitmap.PixelFormat);
                        var targetPtr = (byte*)targetData.Scan0.ToPointer();

                        int factor = targetBitmap.PixelFormat.GetTotalBytes();

                        var sourcePtr = ((byte*)souceIntPtr.ToPointer()) + (region.Top * sourceWidth + region.Left) * factor;

                        int copyLength = region.Width * factor;
                        int skipLength = (sourceWidth - region.Width) * factor;

                        for (int y = 0; y < region.Height; y++)
                        {
                                for (int x = 0; x < copyLength; x++)
                                {
                                        *targetPtr++ = *sourcePtr++;
                                }
                                sourcePtr += skipLength;
                        }

                        targetBitmap.UnlockBits(targetData);
                }

                public static void CopyFromVerticalMirror(this Bitmap targetBitmap, IntPtr souceIntPtr, int sourceWidth, int sourceHeight, Region region)
                {
                        Debug.Assert(targetBitmap != null);

                        Debug.Assert(souceIntPtr != IntPtr.Zero);

                        Debug.Assert(region != null);
                        Debug.Assert(region.Width == targetBitmap.Width);
                        Debug.Assert(region.Height == targetBitmap.Height);

                        var rect = new Rectangle(0, 0, targetBitmap.Width, targetBitmap.Height);
                        BitmapData targetData = targetBitmap.LockBits(rect, ImageLockMode.WriteOnly,
                                targetBitmap.PixelFormat);
                        var targetPtr = (byte*)targetData.Scan0.ToPointer();

                        int factor = targetBitmap.PixelFormat.GetTotalBytes();

                        var sourcePtr = ((byte*)souceIntPtr.ToPointer()) + (region.Bottom * sourceWidth + region.Left) * factor;

                        int copyLength = region.Width * factor;
                        int skipLength =-1* (region.Width + sourceWidth) * factor;

                        for (int y = 0; y < region.Height; y++)
                        {
                                for (int x = 0; x < copyLength; x++)
                                {
                                        *targetPtr++ = *sourcePtr++;
                                }
                                sourcePtr += skipLength;
                        }

                        targetBitmap.UnlockBits(targetData);
                }

                public static void Clear(this Bitmap bitmap)
                {
                        Debug.Assert(bitmap != null);
                        
                        var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

                        BitmapData data = bitmap.LockBits(rect, ImageLockMode.ReadOnly,
                                bitmap.PixelFormat);
                        var ptr = (byte*)data.Scan0.ToPointer();

                        int length = bitmap.GetTotalBytes();

                        for (int i = 0; i < length; i++)
                        {
                                *ptr++ = 0;
                        }

                        bitmap.UnlockBits(data);
                }
        }
}