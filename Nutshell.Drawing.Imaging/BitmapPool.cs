using System.Collections.Generic;
using System.Threading;

namespace Nutshell.Drawing.Imaging
{
        public class BitmapPool:IdentityObject
        {
                public BitmapPool(IdentityObject parent, int width, int height, PixelFormat pixelFormat, int count=7)
                        :base(parent, "位图池")
                {
                        
                        for (int i  = 1; i < count + 1; i++)
                        {
                                var bitmap = new Bitmap(this, i + "号位图", width, height, pixelFormat);
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
