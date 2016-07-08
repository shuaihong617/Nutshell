// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-11-19
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-11-19
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Drawing;
using System.Windows.Forms;
using Nutshell.Hardware.Vision;

namespace Nutshell.Presentation.GDIPlus.Hardware.Vision
{
        /// <summary>
        ///         Class CameraRender.
        /// </summary>
        public abstract class CameraSence : CycleSence
        {
                /// <summary>
                /// 初始化<see cref="CameraRenderer" />的新实例.
                /// </summary>
                /// <param name="parent">The parent.</param>
                /// <param name="id">The key.</param>
                /// <param name="control">The image.</param>
                /// <param name="camera">The camera.</param>
                protected CameraSence(IdentityObject parent, string id, Control control, Camera camera)
                        : base(parent, id, control)
                {
                        camera.MustNotNull();
                        Camera = camera;
                }

                private Camera Camera { get;  set; }

                protected static Font YaHei36Font = new Font("Microsoft YaHei", 36);

                protected override void Render(Graphics graphics)
                {               
                        graphics.DrawString(Camera.Id, YaHei36Font, Brushes.LawnGreen, 20, 20);
                }                
        }
}