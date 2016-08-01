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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Nutshell.Components;
using Nutshell.Drawing.Imaging;
using Nutshell.Hardware.Vision;
using Nutshell.Log;

namespace Nutshell.Presentation.Direct2D.WinForm.Hardware.Vision
{
        /// <summary>
        ///         Class CameraRender.
        /// </summary>
        public class CameraRenderer : CycleRenderer
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
                        //Sence = sence;
                }

                private CameraDecoder _decoder;

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
                        CameraSence sence = _sencePool.Dequeue();
                        if (sence == null)
                        {
                                this.WarnFail("EnterWrite");
                                return;
                        }

                        sence.Update(ProcessBitmap);

                        if (_lock.TryEnterWriteLock(5))
                        {
                                _displaySence = sence;
                                _lock.EnterWriteLock();
                        }
                        else
                        {
                                _sencePool.Enqueue(sence);
                        }
                }

                protected override void Render()
                {
                        var source = _decoder.Buffer.Dequeue();
                        if (source == null)
                        {
                                throw new InvalidOperationException();
                        }

                        Bitmap = source.Value;
                        base.Render();

                        source.ExitWrite();
                }


                

                

                private void Render()
                {
                        if (_lock.TryEnterReadLock(5))
                        {
                                if (_displaySence != null)
                                {
                                        _displaySence.Render();
                                        _sencePool.Enqueue(_displaySence);
                                }

                                _lock.ExitReadLock();
                        }
                }
        }
}