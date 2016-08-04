using System.Collections.Generic;
using System.Threading;

namespace Nutshell.Drawing.Imaging
{
        public class NSBitmapPool:IdentityObject
        {
                public NSBitmapPool(IdentityObject parent, int width, int height, NSPixelFormat pixelFormat, int count=7)
                        :base(parent, "位图池")
                {
                        
                        for (int i  = 1; i < count + 1; i++)
                        {
                                var bitmap = new NSBitmap(this, i + "号位图", width, height, pixelFormat);
                                _usage[bitmap] = new ReaderWriterLockSlim();
                        }
                }

                private readonly Dictionary<NSBitmap, ReaderWriterLockSlim> _usage =
                        new Dictionary<NSBitmap, ReaderWriterLockSlim>();

                public bool EnterRead(NSBitmap nsBitmap)
                {
                        return _usage[nsBitmap].TryEnterReadLock(0);
                }

                public void ExitRead(NSBitmap nsBitmap)
                {
                        _usage[nsBitmap].ExitReadLock();
                }

                public NSBitmap EnterWrite()
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

                public void ExitWrite(NSBitmap nsBitmap)
                {
                        _usage[nsBitmap].ExitWriteLock();
                }
        }
}
