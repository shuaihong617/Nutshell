// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-08-02
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-08-04
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Nutshell.Drawing.Imaging
{
        /// <summary>
        /// Class NSBitmap.
        /// </summary>
        public unsafe class Bitmap : IdentityObject
        {
                /// <summary>
                /// 初始化<see cref="Bitmap"/>的新实例.
                /// </summary>
                /// <param name="parent">The parent.</param>
                /// <param name="id">The identifier.</param>
                /// <param name="width">The width.</param>
                /// <param name="height">The height.</param>
                /// <param name="format">The format.</param>
                /// <param name="timeStamp">The time stamp.</param>
                public Bitmap(IdentityObject parent, String id, int width, int height, PixelFormat format, NSTimeStamp timeStamp = null)
                        : base(parent, id)
                {
                        width.MustGreaterThan(0);
                        Width = width;

                        height.MustGreaterThan(0);
                        Height = height;

                        PixelFormat = format;

                        Stride = Width*PixelFormat.GetBytes();

                        BufferLength = Width*Height*PixelFormat.GetBytes();

                        Buffer = Marshal.AllocHGlobal(BufferLength);

                        TimeStamp = timeStamp;
                }

                /// <summary>
                /// Gets the width.
                /// </summary>
                /// <value>The width.</value>
                public int Width { get; private set; }

                /// <summary>
                /// Gets the height.
                /// </summary>
                /// <value>The height.</value>
                public int Height { get; private set; }

                /// <summary>
                /// Gets the pixel format.
                /// </summary>
                /// <value>The pixel format.</value>
                public PixelFormat PixelFormat { get; private set; }

                /// <summary>
                /// Gets the stride.
                /// </summary>
                /// <value>The stride.</value>
                public int Stride { get; private set; }

                /// <summary>
                /// Gets the buffer.
                /// </summary>
                /// <value>The buffer.</value>
                public IntPtr Buffer { get; private set; }

                /// <summary>
                /// Gets the length of the buffer.
                /// </summary>
                /// <value>The length of the buffer.</value>
                public int BufferLength { get; private set; }

                /// <summary>
                /// Gets the time stamp.
                /// </summary>
                /// <value>The time stamp.</value>
                public NSTimeStamp TimeStamp { get; private set; }

                /// <summary>
                /// Translates to.
                /// </summary>
                /// <param name="target">The target.</param>
                /// <exception cref="System.Exception">
                /// </exception>
                public void TranslateTo(Bitmap target)
                {
                        target.NotNull();
                        target.Width.MustEqual(Width);
                        target.Height.MustEqual(Height);

                        if (target.PixelFormat == PixelFormat)
                        {
                                CopyTo(target);
                                return;
                        }

                        switch (PixelFormat)
                        {
                                case PixelFormat.Rgb24:
                                        switch (target.PixelFormat)
                                        {
                                                case PixelFormat.Bgra32:
                                                        ConvertRgb24ToBgra32(this, target);
                                                        break;

                                                default:
                                                        throw new Exception();
                                        }
                                        break;

                                case PixelFormat.Bgr24:
                                        switch (target.PixelFormat)
                                        {
                                                case PixelFormat.Bgra32:
                                                        ConvertBgr24ToBgra32(this, target);
                                                        break;

                                                default:
                                                        throw new Exception();
                                        }
                                        break;

                                default:
                                        throw new Exception();
                        }
                }

                /// <summary>
                /// Copies to.
                /// </summary>
                /// <param name="target">The target.</param>
                private void CopyTo(Bitmap target)
                {
                        target.NotNull();
                        target.Width.MustEqual(Width);
                        target.Height.MustEqual(Height);
                        target.PixelFormat.MustEqual(PixelFormat);

                        var sourcePtr = (byte*) Buffer.ToPointer();
                        var targetPtr = (byte*) target.Buffer.ToPointer();

                        int length = target.BufferLength;

                        for (int i = 0; i < length; i++)
                        {
                                *targetPtr++ = *sourcePtr++;
                        }
                }

                /// <summary>
                /// Copies from.
                /// </summary>
                /// <param name="souceIntPtr">The souce int PTR.</param>
                public void CopyFrom(IntPtr souceIntPtr)
                {
                        Trace.Assert(souceIntPtr != IntPtr.Zero);

                        var sourcePtr = (byte*) souceIntPtr.ToPointer();
                        var targetPtr = (byte*) Buffer.ToPointer();

                        int length = BufferLength;

                        for (int i = 0; i < length; i++)
                        {
                                *targetPtr++ = *sourcePtr++;
                        }
                }

                /// <summary>
                /// Converts the RGB24 to bgra32.
                /// </summary>
                /// <param name="source">The source.</param>
                /// <param name="target">The target.</param>
                private static void ConvertRgb24ToBgra32(Bitmap source, Bitmap target)
                {
                        source.NotNull();
                        source.PixelFormat.MustEqual(PixelFormat.Rgb24);

                        target.NotNull();
                        target.Width.MustEqual(source.Width);
                        target.Height.MustEqual(source.Height);
                        target.PixelFormat.MustEqual(PixelFormat.Bgra32);

                        //逐字节复制
                        var sourcePtr = (byte*) source.Buffer.ToPointer();
                        var targetPtr = (byte*) target.Buffer.ToPointer();

                        int length = source.BufferLength/3;

                        for (int i = 0; i < length; i++)
                        {
                                byte r = *sourcePtr++;
                                byte g = *sourcePtr++;
                                byte b = *sourcePtr++;

                                *targetPtr++ = b;
                                *targetPtr++ = g;
                                *targetPtr++ = r;
                                *targetPtr++ = 255;
                        }

                        //Parallel.For(0, length, i =>
                        //{
                        //        byte* s = sourcePtr + i*3;
                        //        byte r = *s;
                        //        byte g = *(s + 1);
                        //        byte b = *(s + 2);

                        //        byte* t = targetPtr + i*4;
                        //        *t = b;
                        //        *(t + 1) = g;
                        //        *(t + 2) = r;
                        //        *(t + 3) = 255;
                        //});

                        //王喜 2016.7.8 算法，测试未通过
                        //var sourcePtr = (uint*)source.Buffer.ToPointer();
                        //var targetPtr = (uint*)target.Buffer.ToPointer();

                        //int length = source.BufferLength / 12;

                        //for (int i = 0; i < length; i++)
                        //{
                        //        uint a0 = *sourcePtr++;
                        //        uint a1 = *sourcePtr++;
                        //        uint a2 = *sourcePtr++;

                        //        uint b0 = (uint) (((a0 << 16) & 0xff000000)
                        //                          | (a0 & 0xff0000)
                        //                          | ((a0 >> 16) & 0xff00)
                        //                          | 0xff);

                        //        uint b1 = (uint) (((a1 << 8) & 0xff000000)
                        //                          | ((a1 >> 8) & 0xff0000)
                        //                          | ((a0 << 8) & 0xff00)
                        //                          | 0xff);

                        //        uint b2 = (uint) ((a2 & 0xff000000)
                        //                          | ((a1 << 16) & 0xff0000)
                        //                          | (a1 & 0xff00)
                        //                          | 0xff);

                        //        uint b3 = (uint) (((a2 << 24) & 0xff000000)
                        //                          | ((a2 << 8) & 0xff0000)
                        //                          | ((a2 >> 8) & 0xff00)
                        //                          | 0xff);

                        //        *targetPtr++ = b0;
                        //        *targetPtr++ = b1;
                        //        *targetPtr++ = b2;
                        //        *targetPtr++ = b3;
                        //        if (a0> 0)
                        //        {
                        //                Trace.WriteLine("a0:" + a0);
                        //                Trace.WriteLine("a1:" + a1);
                        //                Trace.WriteLine("a2:" + a2);

                        //                Trace.WriteLine("b0:" + b0);
                        //                Trace.WriteLine("b1:" + b1);
                        //                Trace.WriteLine("b2:" + b2);
                        //                Trace.WriteLine("b3:" + b3);
                        //        }

                        //}
                }

                /// <summary>
                /// Converts the BGR24 to bgra32.
                /// </summary>
                /// <param name="source">The source.</param>
                /// <param name="target">The target.</param>
                private static void ConvertBgr24ToBgra32(Bitmap source, Bitmap target)
                {
                        source.NotNull();
                        source.PixelFormat.MustEqual(PixelFormat.Bgr24);

                        target.NotNull();
                        target.Width.MustEqual(source.Width);
                        target.Height.MustEqual(source.Height);
                        target.PixelFormat.MustEqual(PixelFormat.Bgra32);

                        var sourcePtr = (byte*) source.Buffer.ToPointer();
                        var targetPtr = (byte*) target.Buffer.ToPointer();

                        int length = source.BufferLength/3;

                        for (int i = 0; i < length; i++)
                        {
                                *targetPtr++ = *sourcePtr++;
                                *targetPtr++ = *sourcePtr++;
                                *targetPtr++ = *sourcePtr++;
                                *targetPtr++ = 255;
                        }
                }

                /// <summary>
                /// Saves the specified file path.
                /// </summary>
                /// <param name="filePath">The file path.</param>
                /// <exception cref="System.Exception"></exception>
                public void Save(string filePath)
                {
                        switch (PixelFormat)
                        {
                                case PixelFormat.Rgb24:
                                        SaveRgb24(filePath);
                                        break;

                                case PixelFormat.Bgr24:
                                        SaveBgr24(filePath);
                                        break;

                                case PixelFormat.Bgra32:
                                        SaveBgra32(filePath);
                                        break;

                                default:
                                        throw new Exception();
                        }
                }

                /// <summary>
                /// Saves the RGB24.
                /// </summary>
                /// <param name="filePath">The file path.</param>
                public void SaveRgb24(string filePath)
                {
                        PixelFormat.MustEqual(PixelFormat.Rgb24);

                        var sourcePtr = (byte*) Buffer.ToPointer();

                        var bitmap = new System.Drawing.Bitmap(Width, Height,
                                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                        for (int x = 0; x < Width; x++)
                        {
                                for (int y = 0; y < Height; y++)
                                {
                                        byte r = *sourcePtr++;
                                        byte g = *sourcePtr++;
                                        byte b = *sourcePtr++;
                                        bitmap.SetPixel(x, y, Color.FromArgb(255, r, g, b));
                                }
                        }

                        bitmap.Save(filePath);
                }

                /// <summary>
                /// Saves the BGR24.
                /// </summary>
                /// <param name="filePath">The file path.</param>
                public void SaveBgr24(string filePath)
                {
                        PixelFormat.MustEqual(PixelFormat.Bgr24);

                        var sourcePtr = (byte*) Buffer.ToPointer();

                        var bitmap = new System.Drawing.Bitmap(Width, Height,
                                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                        for (int x = 0; x < Width; x++)
                        {
                                for (int y = 0; y < Height; y++)
                                {
                                        byte b = *sourcePtr++;
                                        byte g = *sourcePtr++;
                                        byte r = *sourcePtr++;
                                        bitmap.SetPixel(x, y, Color.FromArgb(255, r, g, b));
                                }
                        }

                        bitmap.Save(filePath);
                }

                /// <summary>
                /// Saves the bgra32.
                /// </summary>
                /// <param name="filePath">The file path.</param>
                public void SaveBgra32(string filePath)
                {
                        PixelFormat.MustEqual(PixelFormat.Bgra32);

                        var sourcePtr = (byte*) Buffer.ToPointer();

                        var bitmap = new System.Drawing.Bitmap(Width, Height,
                                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                        for (int i = 0; i < Width; i++)
                        {
                                for (int j = 0; j < Height; j++)
                                {
                                        byte b = *sourcePtr++;
                                        byte g = *sourcePtr++;
                                        byte r = *sourcePtr++;
                                        byte a = *sourcePtr++;
                                        bitmap.SetPixel(i, j, Color.FromArgb(a, r, g, b));
                                }
                        }

                        bitmap.Save(filePath);
                }


                /// <summary>
                /// Clears the specified r.
                /// </summary>
                /// <param name="r">The r.</param>
                /// <param name="g">The g.</param>
                /// <param name="b">The b.</param>
                public void Clear(byte r = 0, byte g = 0, byte b = 0)
                {
                        PixelFormat.MustEqual(PixelFormat.Rgb24);

                        var sourcePtr = (byte*) Buffer.ToPointer();

                        for (int i = 0; i < Width; i++)
                        {
                                for (int j = 0; j < Height; j++)
                                {
                                        *sourcePtr++ = r;
                                        *sourcePtr++ = g;
                                        *sourcePtr++ = b;
                                }
                        }
                }

                /// <summary>
                /// Returns a <see cref="System.String" /> that represents this Itance.
                /// </summary>
                /// <returns>A <see cref="System.String" /> that represents this Itance.</returns>
                public override string ToString()
                {
                        return string.Format("{0}", GlobalId);
                }
        }
}
