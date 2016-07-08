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

using System.Drawing;
using System.Windows.Forms;

namespace Nutshell.Presentation.GDIPlus
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
                        control.MustNotNull();
                        SurfaceGraphics = control.CreateGraphics();
                }

                /// <summary>
                /// Gets the graphics.
                /// </summary>
                /// <value>The graphics.</value>
                protected Graphics SurfaceGraphics { get; private set; }

                public abstract void Render();
        }
}