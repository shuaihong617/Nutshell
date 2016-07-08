using System;
using System.Runtime.InteropServices;

namespace Nutshell.Presentation.Direct2D1.Interop
{
        internal sealed class Direct3D9Ex : IDisposable
        {
                private ComInterface.IDirect3D9Ex _comObject;
                private ComInterface.CreateDeviceEx _createDeviceEx;

                private Direct3D9Ex(ComInterface.IDirect3D9Ex obj)
                {
                        _comObject = obj;
                        ComInterface.GetComMethod(_comObject, 20, out _createDeviceEx);
                }

                ~Direct3D9Ex()
                {
                        Release();
                }

                public void Dispose()
                {
                        Release();
                        GC.SuppressFinalize(this);
                }

                public static Direct3D9Ex Create(int sdkVersion)
                {
                        ComInterface.IDirect3D9Ex obj;
                        Marshal.ThrowExceptionForHR(NativeMethods.Direct3DCreate9Ex(sdkVersion, out obj));

                        return new Direct3D9Ex(obj);
                }

                public Direct3DDevice9Ex CreateDeviceEx(uint adapter, int deviceType, IntPtr focusWindow,
                        int behaviorFlags,
                        NativeStructs.D3DPRESENT_PARAMETERS pPresentationParameters,
                        NativeStructs.D3DDISPLAYMODEEX pFullscreenDisplayMode)
                {
                        ComInterface.IDirect3DDevice9Ex obj = null;
                        int result = _createDeviceEx(_comObject, adapter, deviceType, focusWindow, behaviorFlags,
                                pPresentationParameters, pFullscreenDisplayMode, out obj);
                        Marshal.ThrowExceptionForHR(result);

                        return new Direct3DDevice9Ex(obj);
                }

                private void Release()
                {
                        if (_comObject == null)
                        {
                                return;
                        }

                        Marshal.ReleaseComObject(_comObject);
                        _comObject = null;
                        _createDeviceEx = null;
                }
        }
}
