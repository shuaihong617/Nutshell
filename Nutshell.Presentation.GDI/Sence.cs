// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-07-06
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-07-06
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Drawing;
using System.Windows.Forms;
using Nutshell.Windows;

namespace Nutshell.Presentation.GDI
{
        /// <summary>
        /// 基于GDIPlus的渲染场景
        /// </summary>
        /// <remarks>
        /// 仅适用于WinForm控件
        /// </remarks>
        public abstract class Sence:IdentityObject
        {
                /// <summary>
                /// 初始化<see cref="Sence" />的新实例.
                /// </summary>
                /// <param name="parent">The parent.</param>
                /// <param name="id">The identifier.</param>
                /// <param name="control">The control.</param>
                protected Sence(IdentityObject parent, string id = "", Control control = null)
                        :base(parent, id)
                {
                        if (control == null)
                        {
                                throw new ArgumentNullException();
                        }

                        var graphics = control.CreateGraphics();
                        SurfaceDC = graphics.GetHdc();

                        Width = control.Width;
                        Height = control.Height;
                }

                protected IntPtr SurfaceDC { get; private set; }

                protected int Width { get; private set; }

                protected int Height { get; private set; }

                public abstract void Render();
        }
}