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
using Nutshell.Drawing.Imaging;
using Nutshell.Hardware.Vision;

namespace Nutshell.Presentation.Direct2D.WinForm.Hardware.Vision
{
        /// <summary>
        ///         Class CameraRender.
        /// </summary>
        public class CameraRenderer : CameraConsumer
        {
                /// <summary>
                ///         初始化<see cref="CameraRenderer" />的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">The key.</param>
                /// <param name="camera">The camera.</param>
                /// <param name="sence">The sence.</param>
                public CameraRenderer(IdentityObject parent, string id, Camera camera, CameraSence sence)
                        : base(parent, id, camera, PixelFormat.Bgra32)
                {
                        sence.MustNotNull();
                        Sence = sence;
                }

                private CameraSence Sence { get; set; }

                public bool IsRenderStarted
                {
                        get { return _isRenderStarted; }
                        private set
                        {
                                _isRenderStarted = value;
                                RaisePropertyChanged();
                        }
                }

                protected static Font YaHei40Font = new Font("Microsoft YaHei", 40);
                private bool _isRenderStarted;

                protected override void ProcessCore()
                {
                        lock (ProcessBitmap)
                        {
                                Sence.UpdateBufferBitmap(ProcessBitmap);
                        }
                        
                        //Sence.Render();
                }


                public void StartCycle()
                {
                        Sence.Start();
                        IsRenderStarted = true;
                }

                public void StopCycle()
                {
                        Sence.Stop();
                        IsRenderStarted = false;
                }
        }
}