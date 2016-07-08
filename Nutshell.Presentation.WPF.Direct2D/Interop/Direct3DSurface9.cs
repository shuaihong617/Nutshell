using System;
using System.Runtime.InteropServices;

namespace Nutshell.Presentation.Direct2D1.Interop
{
        internal sealed class Direct3DSurface9 : IDisposable
        {
                private ComInterface.IDirect3DSurface9 _comObject;
                private IntPtr _native;

                internal Direct3DSurface9(ComInterface.IDirect3DSurface9 obj)
                {
                        _comObject = obj;
                        _native = Marshal.GetIUnknownForObject(_comObject);
                }

                ~Direct3DSurface9()
                {
                        Release();
                }

                public IntPtr NativeInterface
                {
                        get { return _native; }
                }

                public void Dispose()
                {
                        Release();
                        GC.SuppressFinalize(this);
                }

                private void Release()
                {
                        if (_comObject != null)
                        {
                                Marshal.Release(_native);
                                _native = IntPtr.Zero;

                                Marshal.ReleaseComObject(_comObject);
                                _comObject = null;
                        }
                }
        }
}
