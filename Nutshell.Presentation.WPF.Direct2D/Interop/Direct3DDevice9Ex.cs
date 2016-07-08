using System;
using System.Runtime.InteropServices;

namespace Nutshell.Presentation.Direct2D1.Interop
{
        internal sealed class Direct3DDevice9Ex : IDisposable
        {
                private ComInterface.IDirect3DDevice9Ex _comObject;
                private ComInterface.CreateTexture _createTexture;

                internal Direct3DDevice9Ex(ComInterface.IDirect3DDevice9Ex obj)
                {
                        _comObject = obj;
                        ComInterface.GetComMethod(_comObject, 23, out _createTexture);
                }

                ~Direct3DDevice9Ex()
                {
                        Release();
                }

                public void Dispose()
                {
                        Release();
                        GC.SuppressFinalize(this);
                }

                public Direct3DTexture9 CreateTexture(uint width, uint height, uint levels, int usage, int format,
                        int pool, ref IntPtr sharedHandle)
                {
                        ComInterface.IDirect3DTexture9 obj = null;
                        int result = _createTexture(_comObject, width, height, levels, usage, format, pool, out obj,
                                ref sharedHandle);
                        Marshal.ThrowExceptionForHR(result);

                        return new Direct3DTexture9(obj);
                }

                private void Release()
                {
                        if (_comObject != null)
                        {
                                Marshal.ReleaseComObject(_comObject);
                                _comObject = null;
                                _createTexture = null;
                        }
                }
        }
}
