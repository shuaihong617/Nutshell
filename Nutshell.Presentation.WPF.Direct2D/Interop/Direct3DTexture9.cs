using System;
using System.Runtime.InteropServices;

namespace Nutshell.Presentation.Direct2D1.Interop
{
        internal sealed class Direct3DTexture9 : IDisposable
        {
                private ComInterface.IDirect3DTexture9 _comObject;
                private ComInterface.GetSurfaceLevel _getSurfaceLevel;

                internal Direct3DTexture9(ComInterface.IDirect3DTexture9 obj)
                {
                        _comObject = obj;
                        ComInterface.GetComMethod(_comObject, 18, out _getSurfaceLevel);
                }

                ~Direct3DTexture9()
                {
                        Release();
                }

                public void Dispose()
                {
                        Release();
                        GC.SuppressFinalize(this);
                }

                public Direct3DSurface9 GetSurfaceLevel(uint Level)
                {
                        ComInterface.IDirect3DSurface9 surface = null;
                        Marshal.ThrowExceptionForHR(_getSurfaceLevel(_comObject, Level, out surface));

                        return new Direct3DSurface9(surface);
                }

                private void Release()
                {
                        if (_comObject != null)
                        {
                                Marshal.ReleaseComObject(_comObject);
                                _comObject = null;
                                _getSurfaceLevel = null;
                        }
                }
        }
}
