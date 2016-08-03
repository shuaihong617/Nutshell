using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Nutshell.Drawing.Imaging
{
        public unsafe class Bitmap : IdentityObject
        {
                public Bitmap(IdentityObject parent, String id, int width, int height, PixelFormat format)
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
                }

                public int Width { get; private set; }

                public int Height { get; private set; }

                public PixelFormat PixelFormat { get; private set; }

                public int Stride { get; private set; }

                public IntPtr Buffer { get; private set; }

                public int BufferLength { get; private set; }

                public DateTime TimeStamp { get; private set; }

                public void UpdateTimeStamp()
                {
                        TimeStamp = DateTime.Now;
                }

                public void TranslateTo(Bitmap target)
                {
                        target.MustNotNull();
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

                private void CopyTo(Bitmap target)
                {
                        target.MustNotNull();
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

                        TimeStamp = DateTime.Now;
                }

                private static void ConvertRgb24ToBgra32(Bitmap source, Bitmap target)
                {
                        source.MustNotNull();
                        source.PixelFormat.MustEqual(PixelFormat.Rgb24);

                        target.MustNotNull();
                        target.Width.MustEqual(source.Width);
                        target.Height.MustEqual(source.Height);
                        target.PixelFormat.MustEqual(PixelFormat.Bgra32);

                        //逐字节复制
                        var sourcePtr = (byte*) source.Buffer.ToPointer();
                        var targetPtr = (byte*) target.Buffer.ToPointer();

                        int length = source.BufferLength/3;

                        //for(int i = 0; i < length; i++)
                        //{
                        //        byte r = *sourcePtr++;
                        //        byte g = *sourcePtr++;
                        //        byte b = *sourcePtr++;

                        //        *targetPtr++ = b;
                        //        *targetPtr++ = g;
                        //        *targetPtr++ = r;
                        //        *targetPtr++ = 255;
                        //}

                        Parallel.For(0, length, i =>
                        {
                                byte* s = sourcePtr + i*3;
                                byte r = *s;
                                byte g = *(s + 1);
                                byte b = *(s + 2);

                                byte* t = targetPtr + i*4;
                                *t = b;
                                *(t + 1) = g;
                                *(t + 2) = r;
                                *(t + 3) = 255;
                        });

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

                private static void ConvertBgr24ToBgra32(Bitmap source, Bitmap target)
                {
                        source.MustNotNull();
                        source.PixelFormat.MustEqual(PixelFormat.Bgr24);

                        target.MustNotNull();
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

                public override string ToString()
                {
                        return string.Format("{0}:{1}", GlobalId, TimeStamp.ToChineseLongMillisecondString());
                }
        }
}
