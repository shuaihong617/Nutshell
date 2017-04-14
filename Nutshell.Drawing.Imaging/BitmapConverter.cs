using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Extensions;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using NativeBitmap = System.Drawing.Bitmap;
using NativePixelFormat = System.Drawing.Imaging.PixelFormat;

namespace Nutshell.Drawing.Imaging
{
        public static unsafe class BitmapConverter
        {
                /// <summary>
                ///         Translates to.
                /// </summary>
                /// <param name="source">The source.</param>
                /// <param name="target">The target.</param>
                /// <exception cref="System.InvalidOperationException">
                /// </exception>
                /// <exception cref="System.Exception"></exception>
                public static void ConvertTo([MustNotEqualNull] Bitmap source, [MustNotEqualNull] Bitmap target)
                {
                        target.Width.MustEqual(source.Width);
                        target.Height.MustEqual(source.Height);

                        if (target.PixelFormat == source.PixelFormat)
                        {
                                source.CopyTo(target);
                                return;
                        }

                        switch (source.PixelFormat)
                        {
                                case PixelFormat.Mono8:
                                        switch (target.PixelFormat)
                                        {
                                                case PixelFormat.Bgra32:
                                                        ConvertMono8ToBgra32(source, target);
                                                        break;

                                                default:
                                                        throw new InvalidOperationException();
                                        }
                                        break;

                                case PixelFormat.Rgb24:
                                        switch (target.PixelFormat)
                                        {
                                                case PixelFormat.Bgra32:
                                                        ConvertRgb24ToBgra32(source, target);
                                                        break;

                                                default:
                                                        throw new InvalidOperationException();
                                        }
                                        break;

                                case PixelFormat.Bgr24:
                                        switch (target.PixelFormat)
                                        {
                                                case PixelFormat.Bgra32:
                                                        ConvertBgr24ToBgra32(source, target);
                                                        break;

                                                default:
                                                        throw new InvalidOperationException();
                                        }
                                        break;

                                default:
                                        throw new Exception();
                        }
                }

                /// <summary>
                ///         Converts the RGB24 to bgra32.
                /// </summary>
                /// <param name="source">The source.</param>
                /// <param name="target">The target.</param>
                private static void ConvertMono8ToBgra32(Bitmap source, Bitmap target)
                {
                        source.NotNull();
                        source.PixelFormat.MustEqual(PixelFormat.Mono8);

                        target.NotNull();
                        target.Width.MustEqual(source.Width);
                        target.Height.MustEqual(source.Height);
                        target.PixelFormat.MustEqual(PixelFormat.Bgra32);

                        //逐字节扩展复制
                        var sourcePtr = (byte*)source.Buffer.ToPointer();
                        var targetPtr = (byte*)target.Buffer.ToPointer();

                        var length = source.BufferLength;

                        for (var i = 0; i < length; i++)
                        {
                                var s = *sourcePtr++;

                                *targetPtr++ = s;
                                *targetPtr++ = s;
                                *targetPtr++ = s;
                                *targetPtr++ = 255;
                        }
                }

                /// <summary>
                ///         Converts the RGB24 to bgra32.
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
                        var sourcePtr = (byte*)source.Buffer.ToPointer();
                        var targetPtr = (byte*)target.Buffer.ToPointer();

                        var length = source.BufferLength / 3;

                        for (var i = 0; i < length; i++)
                        {
                                var r = *sourcePtr++;
                                var g = *sourcePtr++;
                                var b = *sourcePtr++;

                                *targetPtr++ = b;
                                *targetPtr++ = g;
                                *targetPtr++ = r;
                                *targetPtr++ = 255;
                        }
                }

                /// <summary>
                ///         Converts the BGR24 to bgra32.
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

                        var sourcePtr = (byte*)source.Buffer.ToPointer();
                        var targetPtr = (byte*)target.Buffer.ToPointer();

                        var length = source.BufferLength / 3;

                        for (var i = 0; i < length; i++)
                        {
                                *targetPtr++ = *sourcePtr++;
                                *targetPtr++ = *sourcePtr++;
                                *targetPtr++ = *sourcePtr++;
                                *targetPtr++ = 255;
                        }
                }

                /// <summary>
                ///         Translates to.
                /// </summary>
                /// <param name="source">The source.</param>
                /// <param name="target">The target.</param>
                /// <exception cref="System.InvalidOperationException">
                /// </exception>
                /// <exception cref="System.Exception"></exception>
                public static void ConvertTo([MustNotEqualNull] NativeBitmap source, [MustNotEqualNull] Bitmap target)
                {
                        target.Width.MustEqual(source.Width);
                        target.Height.MustEqual(source.Height);

                        switch (source.PixelFormat)
                        {
                                case NativePixelFormat.Format8bppIndexed:
                                        switch (target.PixelFormat)
                                        {
                                                case PixelFormat.Mono8:
                                                        ConvertFormat8bppIndexedToMono8(source, target);
                                                        break;

                                                default:
                                                        throw new InvalidOperationException();
                                        }
                                        break;

                                case NativePixelFormat.Format24bppRgb:
                                        switch (target.PixelFormat)
                                        {
                                                case PixelFormat.Mono8:
                                                        ConvertFormat24bppRgbToMono8(source, target);
                                                        break;

                                                default:
                                                        throw new InvalidOperationException();
                                        }
                                        break;

                                default:
                                        throw new Exception();
                        }
                }


                /// <summary>
                ///         Converts the BGR24 to bgra32.
                /// </summary>
                /// <param name="source">The source.</param>
                /// <param name="target">The target.</param>
                private static void ConvertFormat8bppIndexedToMono8([MustNotEqualNull]NativeBitmap source, Bitmap target)
                {
                        Trace.Assert(source.PixelFormat == NativePixelFormat.Format8bppIndexed);

                        target.NotNull();
                        target.Width.MustEqual(source.Width);
                        target.Height.MustEqual(source.Height);
                        target.PixelFormat.MustEqual(PixelFormat.Mono8);

                        //var sourcePtr = (byte*)source.Buffer.ToPointer();
                        //var targetPtr = (byte*)target.Buffer.ToPointer();

                        //var length = source.BufferLength / 3;

                        //for (var i = 0; i < length; i++)
                        //{
                        //        *targetPtr++ = *sourcePtr++;
                        //        *targetPtr++ = *sourcePtr++;
                        //        *targetPtr++ = *sourcePtr++;
                        //        *targetPtr++ = 255;
                        //}
                }

                /// <summary>
                ///         Converts the BGR24 to bgra32.
                /// </summary>
                /// <param name="source">The source.</param>
                /// <param name="target">The target.</param>
                private static void ConvertFormat24bppRgbToMono8([MustNotEqualNull]NativeBitmap source, Bitmap target)
                {
                        Trace.Assert(source.PixelFormat == NativePixelFormat.Format24bppRgb);

                        target.NotNull();
                        target.Width.MustEqual(source.Width);
                        target.Height.MustEqual(source.Height);
                        target.PixelFormat.MustEqual(PixelFormat.Mono8);

                        var rect = new Rectangle(0, 0, source.Width, source.Height);

                        BitmapData sourceData = source.LockBits(rect, ImageLockMode.ReadOnly,
                                source.PixelFormat);
                       
                        var sourcePtr = (byte*)sourceData.Scan0.ToPointer();
                        var targetPtr = (byte*)target.Buffer.ToPointer();

                        var length = target.BufferLength;

                        for (var i = 0; i < length; i++)
                        {
                                *targetPtr++ = *sourcePtr++;
                                sourcePtr+=2;
                        }

                        source.UnlockBits(sourceData);
                }
        }
}