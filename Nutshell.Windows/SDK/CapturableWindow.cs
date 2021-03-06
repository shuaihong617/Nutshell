﻿using System;
using System.Diagnostics;
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
                        Trace.Assert(_windowDC == IntPtr.Zero);
                        Trace.Assert(_memoryDC == IntPtr.Zero);
                        Trace.Assert(MemoryBitmapHandle == IntPtr.Zero);
                        
                        _windowDC = WindowApi.GetWindowDC(Handle);
                        _memoryDC = GdiApi.CreateCompatibleDC(_windowDC);

                        var rect = GetWindowRectangle();
                        MemoryBitmapHandle = GdiApi.CreateCompatibleBitmap(_windowDC, rect.Width,
                                        rect.Height);

                        GdiApi.SelectObject(_memoryDC, MemoryBitmapHandle);

                        IsCaptureEnable = true;
                }


                public virtual void Caputre()
                {
                        if (!IsCaptureEnable)
                        {
                                return;
                        }

                        //UpdateRectangle();

                        WindowApi.PrintWindow(Handle, _memoryDC, 0);
                }

                public void ClearCaptureEnvironment()
                {
                        IsCaptureEnable = false;

                        GdiApi.DeleteObject(MemoryBitmapHandle);

                        GdiApi.DeleteDC(_memoryDC);

                        GdiApi.ReleaseDC(Handle, _windowDC);
                        GdiApi.DeleteDC(_windowDC);
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
                        CursorApi.SetCursorPos(x, y);
                        //Win32API.mouse_event(MouseEventFlag.Move  | MouseEventFlag.Absolute, x * 65535 / r.Width, y * 65535 / r.Height, 0, 0);//移动到需要点击的位置
                        MouseAPI.mouse_event(MouseEventFlag.LeftDown | MouseEventFlag.Absolute, 0, 0, 0, 0); //点击
                        MouseAPI.mouse_event(MouseEventFlag.LeftUp | MouseEventFlag.Absolute, 0, 0, 0, 0); //抬起
                }

                public void SendLeftMouseClick(Point point)
                {
                        WindowApi.SetForegroundWindow(Handle);
                        SendLeftMouseClick(point.X, point.Y);
                }

                //public void PostLeftMouseClick(int x, int y)
                //{
                //        Win32API.PostMessage(WindowHandle, Win32API.WM_LBUTTONDOWN, Win32API.MK_LBUTTON,
                //                Win32API.MAKELONG(x, y));

                //        Win32API.PostMessage(WindowHandle, Win32API.WM_LBUTTONUP, Win32API.MK_LBUTTON,
                //                Win32API.MAKELONG(x, y));
                //}
        }
}