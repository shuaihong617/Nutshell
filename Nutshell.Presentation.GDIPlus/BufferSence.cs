using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;

namespace Nutshell.Presentation.GDIPlus
{
        public abstract unsafe class BufferSence : Sence
        {
                protected BufferSence(IdentityObject parent, string id = "", Control control = null)
                        : base(parent, id, control)
                {
                        BufferBitmap = new Bitmap(control.Width, control.Height, PixelFormat.Format32bppRgb);

                        BufferGraphics = Graphics.FromImage(BufferBitmap);
                        BufferGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                }

                private Graphics BufferGraphics { get; set; }

                private Bitmap BufferBitmap { get; set; }

                private readonly ReaderWriterLockSlim _bitmapLock = new ReaderWriterLockSlim();

                public void UpdateBufferBitmap(Drawing.Imaging.Bitmap bitmap)
                {
                        if (_bitmapLock.TryEnterWriteLock(16))
                        {
                                bitmap.Width.MustEqual(BufferBitmap.Width);
                                bitmap.Height.MustEqual(BufferBitmap.Height);

                                var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

                                BitmapData targetData = BufferBitmap.LockBits(rect, ImageLockMode.WriteOnly,
                                        BufferBitmap.PixelFormat);

                                var sourcePtr = (byte*) bitmap.Buffer.ToPointer();
                                var targetPtr = (byte*) targetData.Scan0.ToPointer();

                                for (int i = 0; i < bitmap.BufferLength; i++)
                                {
                                        *targetPtr++ = *sourcePtr++;
                                }

                                BufferBitmap.UnlockBits(targetData);

                                _bitmapLock.ExitWriteLock();
                        }
                }

                public override sealed void Render()
                {
                        if (_bitmapLock.TryEnterReadLock(16))
                        {
                                Render(BufferGraphics);

                                SurfaceGraphics.DrawImageUnscaled(BufferBitmap, 0, 0);

                                _bitmapLock.ExitReadLock();
                        }
                }

                protected abstract void Render(Graphics graphics);
        }
}