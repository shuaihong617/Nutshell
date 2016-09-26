using System;
using System.Threading;
using System.Windows.Forms;
using Nutshell.Drawing.Imaging;
using Nutshell.Windows;

namespace Nutshell.Presentation.GDI
{
        public abstract class BufferSence : Sence
        {
                protected BufferSence(IdentityObject parent, string id = "", Control control = null)
                        : base(parent, id, control)
                {
                        BufferDC = Win32GDIAPI.CreateCompatibleDC(SurfaceDC);
                        BufferBitmap = Win32GDIAPI.CreateCompatibleBitmap(BufferDC, Width, Height);

                        Win32GDIAPI.SelectObject(BufferDC, BufferBitmap);
                }

                private IntPtr BufferDC { get; set; }

                private IntPtr BufferBitmap { get; set; }

                private readonly ReaderWriterLockSlim _bitmapLock = new ReaderWriterLockSlim();

                public void UpdateBufferBitmap(NSBitmap bitmap)
                {
                        if (_bitmapLock.TryEnterWriteLock(16))
                        {
                                Win32GDIAPI.BitBlt(BufferBitmap, 0, 0, Width, Height, bitmap.Buffer, 0, 0,
                                        RasterOperationCode.SRCCOPY);

                                _bitmapLock.ExitWriteLock();
                        }
                }

                public override sealed void Render()
                {
                        if (_bitmapLock.TryEnterReadLock(16))
                        {
                                Render(BufferDC);

                                Win32GDIAPI.BitBlt(SurfaceDC, 0, 0, Width, Height,
                                        BufferDC, 0, 0, RasterOperationCode.SRCCOPY);

                                _bitmapLock.ExitReadLock();
                        }
                }

                protected abstract void Render(IntPtr hdc);
        }
}