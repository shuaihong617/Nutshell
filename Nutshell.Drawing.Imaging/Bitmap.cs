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
using Nutshell.Extensions;

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
                /// <param name="id">The identifier.</param>
                /// <param name="width">The width.</param>
                /// <param name="height">The height.</param>
                /// <param name="format">The format.</param>
                public Bitmap(String id, int width, int height, PixelFormat format)
                        : base(id)
                {
                        width.MustGreaterThan(0);
                        Width = width;

                        height.MustGreaterThan(0);
                        Height = height;

                        PixelFormat = format;

                        Stride = Width*PixelFormat.GetBytes();

                        BufferLength = Width*Height*PixelFormat.GetBytes();

                        Buffer = Marshal.AllocHGlobal(BufferLength);

			TimeStamps["CaptureTime"] =DateTime.Now;
			TimeStamps["DecodeTime"] = DateTime.Now;
			TimeStamps["SwapTime"] = DateTime.Now;

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
                /// Copies to.
                /// </summary>
                /// <param name="target">The target.</param>
                public void CopyTo(Bitmap target)
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
        }
}
