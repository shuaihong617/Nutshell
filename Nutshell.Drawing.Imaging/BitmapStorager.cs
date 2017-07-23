using Nutshell.Aspects.Locations.Contracts;
using System;
using System.Drawing;
using NativeBitmap = System.Drawing.Bitmap;

namespace Nutshell.Drawing.Imaging
{
        public unsafe static class BitmapStorager
        {
                public static void Save([MustNotEqualNull]Bitmap bitmap, string fileName)
                {
                        switch (bitmap.PixelFormat)
                        {
                                case PixelFormat.Mono8:
                                        SaveMono8(bitmap, fileName);
                                        break;

                                case PixelFormat.Rgb24:
                                        SaveRgb24(bitmap, fileName);
                                        break;

                                case PixelFormat.Bgr24:
                                        SaveBgr24(bitmap, fileName);
                                        break;

                                case PixelFormat.Bgra32:
                                        SaveBgra32(bitmap, fileName);
                                        break;

                                default:
                                        throw new InvalidOperationException();
                        }
                }

                /// <summary>
                /// Saves the RGB24.
                /// </summary>
                /// <param name="bitmap">The bitmap.</param>
                /// <param name="fileName">The file path.</param>
                private static void SaveMono8(Bitmap bitmap, string fileName)
                {
                        bitmap.PixelFormat.MustEqual(PixelFormat.Mono8);

                        var sourcePtr = (byte*)bitmap.Buffer.ToPointer();

                        var nativeBitmap = new NativeBitmap(bitmap.Width, bitmap.Height,
                                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                        for (int y = 0; y < bitmap.Height; y++)
                        {
                                for (int x = 0; x < bitmap.Width; x++)
                                {
                                        byte g = *sourcePtr++;
                                        nativeBitmap.SetPixel(x, y, Color.FromArgb(255, g, g, g));
                                }
                        }

                        nativeBitmap.Save(fileName);
                }

                /// <summary>
                /// Saves the RGB24.
                /// </summary>
                /// <param name="bitmap">The bitmap.</param>
                /// <param name="fileName">The file path.</param>
                private static void SaveRgb24(Bitmap bitmap, string fileName)
                {
                        bitmap.PixelFormat.MustEqual(PixelFormat.Rgb24);

                        var sourcePtr = (byte*)bitmap.Buffer.ToPointer();

                        var nativeBitmap = new NativeBitmap(bitmap.Width, bitmap.Height,
                                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                        Rectangle rect = new Rectangle(0, 0, nativeBitmap.Width, nativeBitmap.Height);
                        System.Drawing.Imaging.BitmapData bmpData =
                            nativeBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                            nativeBitmap.PixelFormat);

                        // Get the address of the first line.
                        var targetPtr = (byte*)bmpData.Scan0.ToPointer();

                        for (int y = 0; y < bitmap.Height; y++)
                        {
                                for (int x = 0; x < bitmap.Width; x++)
                                {
                                        *targetPtr++ = 255;
                                        *targetPtr++ = *sourcePtr++;
                                        *targetPtr++ = *sourcePtr++;
                                        *targetPtr++ = *sourcePtr++;
                                }
                        }

                        // Unlock the bits.
                        nativeBitmap.UnlockBits(bmpData);

                        nativeBitmap.Save(fileName);
                }

                /// <summary>
                /// Saves the BGR24.
                /// </summary>
                /// <param name="bitmap">The bitmap.</param>
                /// <param name="filePath">The file path.</param>
                private static void SaveBgr24(Bitmap bitmap, string filePath)
                {
                        bitmap.PixelFormat.MustEqual(PixelFormat.Bgr24);

                        var sourcePtr = (byte*)bitmap.Buffer.ToPointer();

                        var nativeBitmap = new NativeBitmap(bitmap.Width, bitmap.Height,
                                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                        for (int y = 0; y < bitmap.Height; y++)
                        {
                                for (int x = 0; x < bitmap.Width; x++)
                                {
                                        byte b = *sourcePtr++;
                                        byte g = *sourcePtr++;
                                        byte r = *sourcePtr++;
                                        nativeBitmap.SetPixel(x, y, Color.FromArgb(255, r, g, b));
                                }
                        }

                        nativeBitmap.Save(filePath);
                }

                /// <summary>
                /// Saves the bgra32.
                /// </summary>
                /// <param name="bitmap">The bitmap.</param>
                /// <param name="filePath">The file path.</param>
                private static void SaveBgra32(Bitmap bitmap, string filePath)
                {
                        bitmap.PixelFormat.MustEqual(PixelFormat.Bgra32);

                        var sourcePtr = (byte*)bitmap.Buffer.ToPointer();

                        var nativeBitmap = new NativeBitmap(bitmap.Width, bitmap.Height,
                                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                        for (int y = 0; y < bitmap.Height; y++)
                        {
                                for (int x = 0; x < bitmap.Width; x++)
                                {
                                        byte b = *sourcePtr++;
                                        byte g = *sourcePtr++;
                                        byte r = *sourcePtr++;
                                        byte a = *sourcePtr++;
                                        nativeBitmap.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                                }
                        }

                        nativeBitmap.Save(filePath);
                }
        }
}