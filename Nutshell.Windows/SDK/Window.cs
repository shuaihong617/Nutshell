﻿using System;
using System.Drawing;
using Nutshell.Windows.SDK.APIs;

namespace Nutshell.Windows.SDK
{
        public class Window
        {
                public Window(IntPtr handle)
                {
                        Handle = handle;
                }

                protected IntPtr Handle { get; private set; }

                public static IntPtr FindWindow(string title)
                {
                        return WindowApi.FindWindow(null, title);
                }

                public Window FindChildWindow()
                {
                        IntPtr handle = WindowApi.FindWindowEx(Handle, IntPtr.Zero, null, null);
                        return handle == IntPtr.Zero ? null : new Window(handle);
                }

                public Rectangle GetWindowRectangle()
                {
                        Rect rect = new Rect();
                        WindowApi.GetWindowRect(Handle, ref rect);
                        return rect.ToRectangle();
                }
        }
}