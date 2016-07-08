using System;
using System.Drawing;

namespace Nutshell.Windows
{
        public class Win32Window
        {
                private Win32RECT _rect;

                public Win32Window(IntPtr handle)
                {
                        WindowHandle = handle;
                }

                public IntPtr WindowHandle { get; private set; }

                public Rectangle Rectangle { get; private set; }

                #region 截图

                private IntPtr _memoryDCHandle;
                private IntPtr _windowDCHandle;
                public bool IsCaptureEnable { get; private set; }

                public IntPtr MemoryBitmapHandle { get; private set; }

                #endregion

                public void UpdateRectangle()
                {
                        Win32API.GetWindowRect(WindowHandle, ref _rect);
                        Rectangle = _rect.ToRectangle();
                }

                public void CreateCaptureEnvironment()
                {
                        if (_windowDCHandle == IntPtr.Zero)
                        {
                                _windowDCHandle = Win32API.GetWindowDC(WindowHandle);
                        }

                        if (_memoryDCHandle == IntPtr.Zero)
                        {
                                _memoryDCHandle = Win32API.CreateCompatibleDC(_windowDCHandle);
                        }

                        if (MemoryBitmapHandle == IntPtr.Zero)
                        {
                                Win32API.GetWindowRect(WindowHandle, ref _rect);
                                Rectangle = _rect.ToRectangle();

                                MemoryBitmapHandle = Win32API.CreateCompatibleBitmap(_windowDCHandle, Rectangle.Width,
                                        Rectangle.Height);
                        }


                        Win32API.SelectObject(_memoryDCHandle, MemoryBitmapHandle);

                        IsCaptureEnable = true;
                }


                public virtual void Caputre()
                {
                        if (!IsCaptureEnable)
                        {
                                return;
                        }

                        UpdateRectangle();

                        Win32API.PrintWindow(WindowHandle, _memoryDCHandle, 0);
                }

                public void ClearCaptureEnvironment()
                {
                        IsCaptureEnable = false;

                        Win32API.DeleteObject(MemoryBitmapHandle);

                        Win32API.DeleteDC(_memoryDCHandle);

                        Win32API.ReleaseDC(WindowHandle, _windowDCHandle);
                        Win32API.DeleteDC(_windowDCHandle);
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
                        Win32API.SetCursorPos(x, y);
                        //Win32API.mouse_event(MouseEventFlag.Move  | MouseEventFlag.Absolute, x * 65535 / r.Width, y * 65535 / r.Height, 0, 0);//移动到需要点击的位置
                        Win32API.mouse_event(MouseEventFlag.LeftDown | MouseEventFlag.Absolute, 0, 0, 0, 0); //点击
                        Win32API.mouse_event(MouseEventFlag.LeftUp | MouseEventFlag.Absolute, 0, 0, 0, 0); //抬起
                }

                public void SendLeftMouseClick(Point point)
                {
                        Win32API.SetForegroundWindow(WindowHandle);
                        SendLeftMouseClick(point.X, point.Y);
                }

                //public void PostLeftMouseClick(int x, int y)
                //{
                //        Win32API.PostMessage(WindowHandle, Win32API.WM_LBUTTONDOWN, Win32API.MK_LBUTTON,
                //                Win32API.MAKELONG(x, y));

                //        Win32API.PostMessage(WindowHandle, Win32API.WM_LBUTTONUP, Win32API.MK_LBUTTON,
                //                Win32API.MAKELONG(x, y));
                //}

                public static Win32Window FindWindow(string title)
                {
                        IntPtr handle = Win32API.FindWindow(null, title);
                        return handle == IntPtr.Zero ? null : new Win32Window(handle);
                }

                public Win32Window FindChildWindow()
                {
                        IntPtr handle = Win32API.FindWindowEx(WindowHandle, IntPtr.Zero, null, null);
                        return handle == IntPtr.Zero ? null : new Win32Window(handle);
                }
        }
}