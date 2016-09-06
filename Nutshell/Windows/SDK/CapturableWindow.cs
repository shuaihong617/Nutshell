using System;
using System.Diagnostics.Contracts;
using System.Drawing;
using Nutshell.Windows.SDK.APIs;
using Nutshell.Windows.Win32API;

namespace Nutshell.Windows.SDK
{
        public class CapturableWindow:Window
        {
                public CapturableWindow(IntPtr handle)
                        :base(handle)
                {
                }

                #region 截图

                private IntPtr _memoryDC;
                private IntPtr _windowDC;
                public bool IsCaptureEnable { get; private set; }

                public IntPtr MemoryBitmapHandle { get; private set; }

                #endregion                

                public void CreateEnvironment()
                {
                        Contract.Requires(_windowDC == IntPtr.Zero);
                        Contract.Requires(_memoryDC == IntPtr.Zero);
                        Contract.Requires(MemoryBitmapHandle == IntPtr.Zero);
                        
                        _windowDC = WindowAPI.GetWindowDC(Handle);
                        _memoryDC = GDIAPI.CreateCompatibleDC(_windowDC);

                        var rect = GetWindowRectangle();
                        MemoryBitmapHandle = GDIAPI.CreateCompatibleBitmap(_windowDC, rect.Width,
                                        rect.Height);

                        GDIAPI.SelectObject(_memoryDC, MemoryBitmapHandle);

                        IsCaptureEnable = true;
                }


                public virtual void Caputre()
                {
                        if (!IsCaptureEnable)
                        {
                                return;
                        }

                        //UpdateRectangle();

                        WindowAPI.PrintWindow(Handle, _memoryDC, 0);
                }

                public void ClearCaptureEnvironment()
                {
                        IsCaptureEnable = false;

                        GDIAPI.DeleteObject(MemoryBitmapHandle);

                        GDIAPI.DeleteDC(_memoryDC);

                        GDIAPI.ReleaseDC(Handle, _windowDC);
                        GDIAPI.DeleteDC(_windowDC);
                }


                public void SendKeyboard()
                {
                }

                public void SendLeftMouseClick(int x, int y)
                {
                        //Win32API.SetForegroundWindow(WindowHandle);

                        //Win32API.SendMessage(WindowHandle, Win32API.WM_LBUTTONDOWN, Win32API.MK_LBUTTON,
                        //        Win32API.MAKELONG(x, y));

                        //Win32API.SendMessage(WindowHandle, Win32API.WM_LBUTTONUP, Win32API.MK_LBUTTON,
                        //        Win32API.MAKELONG(x, y));
                        //var r = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
                        CursorAPI.SetCursorPos(x, y);
                        //Win32API.mouse_event(MouseEventFlag.Move  | MouseEventFlag.Absolute, x * 65535 / r.Width, y * 65535 / r.Height, 0, 0);//移动到需要点击的位置
                        MouseAPI.mouse_event(MouseEventFlag.LeftDown | MouseEventFlag.Absolute, 0, 0, 0, 0); //点击
                        MouseAPI.mouse_event(MouseEventFlag.LeftUp | MouseEventFlag.Absolute, 0, 0, 0, 0); //抬起
                }

                public void SendLeftMouseClick(Point point)
                {
                        WindowAPI.SetForegroundWindow(Handle);
                        SendLeftMouseClick(point.X, point.Y);
                }

                //public void PostLeftMouseClick(int x, int y)
                //{
                //        Win32API.PostMessage(WindowHandle, Win32API.WM_LBUTTONDOWN, Win32API.MK_LBUTTON,
                //                Win32API.MAKELONG(x, y));

                //        Win32API.PostMessage(WindowHandle, Win32API.WM_LBUTTONUP, Win32API.MK_LBUTTON,
                //                Win32API.MAKELONG(x, y));
                //}

                public static Window FindWindow(string title)
                {
                        IntPtr handle = WindowAPI.FindWindow(null, title);
                        return handle == IntPtr.Zero ? null : new Window(handle);
                }

                public Window FindChildWindow()
                {
                        IntPtr handle = WindowAPI.FindWindowEx(Handle, IntPtr.Zero, null, null);
                        return handle == IntPtr.Zero ? null : new Window(handle);
                }
        }
}