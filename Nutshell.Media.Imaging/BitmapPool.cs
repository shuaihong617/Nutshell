using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;

namespace Nutshell.Media.Imaging
{
        public class BitmapPool
        {
                public BitmapPool(int width, int height, PixelFormat pixelFormat, int count=7)
                {
                        
                        for (int i = 0; i < count; i++)
                        {
                                var bitmap = new Bitmap(width, height, pixelFormat);
                                _usage[bitmap] = new ReaderWriterLockSlim();
                        }
                }

                private readonly Dictionary<Bitmap, ReaderWriterLockSlim> _usage =
                        new Dictionary<Bitmap, ReaderWriterLockSlim>();

                public bool EnterRead(Bitmap bitmap)
                {
                        return _usage[bitmap].TryEnterReadLock(0);
                }

                public void ExitRead(Bitmap bitmap)
                {
                        _usage[bitmap].ExitReadLock();
                }

                public Bitmap EnterWrite()
                {
                        foreach (var pair in _usage)
                        {
                                if (pair.Value.TryEnterWriteLock(0))
                                {
                                        return pair.Key;
                                }
                        }
                        return null;
                }

                public void ExitWrite(Bitmap bitmap)
                {
                        _usage[bitmap].ExitWriteLock();
                }
        }
}
