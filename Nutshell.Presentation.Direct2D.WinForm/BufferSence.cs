using System.Threading;
using System.Windows.Forms;
using SharpDX.Direct2D1;

namespace Nutshell.Presentation.Direct2D.WinForm
{
        public abstract class BufferSence : Sence
        {
                protected BufferSence(IdentityObject parent, string id = "", Control control = null)
                        : base(parent, id, control)
                {
                        BufferBitmapRenderTarget = new BitmapRenderTarget(SurfaceRenderTarget,
                                CompatibleRenderTargetOptions.None);
                }

                protected BitmapRenderTarget BufferBitmapRenderTarget { get; private set; }

                private readonly ReaderWriterLockSlim _bitmapLock = new ReaderWriterLockSlim();

                
                public void UpdateBufferBitmap(Drawing.Imaging.Bitmap bitmap)
                {
                        if (_bitmapLock.TryEnterWriteLock(20))
                        {
                                bitmap.Width.MustEqual(BufferBitmapRenderTarget.Bitmap.PixelSize.Width);
                                bitmap.Height.MustEqual(BufferBitmapRenderTarget.Bitmap.PixelSize.Height);

                                BufferBitmapRenderTarget.Bitmap.CopyFromMemory(bitmap.Buffer, bitmap.Stride);

                                _bitmapLock.ExitWriteLock();
                        }
                }

                public override sealed void Render()
                {
                        if (_bitmapLock.TryEnterReadLock(20))
                        {
                                //绘制缓冲图像
                                BufferBitmapRenderTarget.BeginDraw();
                                Render(BufferBitmapRenderTarget);
                                BufferBitmapRenderTarget.EndDraw();

                                SurfaceRenderTarget.BeginDraw();
                                SurfaceRenderTarget.DrawBitmap(BufferBitmapRenderTarget.Bitmap, 1,
                                        BitmapInterpolationMode.Linear);
                                SurfaceRenderTarget.EndDraw();

                                _bitmapLock.ExitReadLock();
                        }
                }

                protected abstract void Render(RenderTarget target);
        }
}