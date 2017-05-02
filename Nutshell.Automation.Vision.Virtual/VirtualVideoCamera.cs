// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-07-30
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-07-30
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Diagnostics;
using Nutshell.Drawing;
using Nutshell.Components;
using Nutshell.Automation;
using Nutshell.Automation.Vision;
using AForge.Video.FFMPEG;
using Nutshell.Drawing.Imaging;
using Nutshell.Data;
using Nutshell.Automation.Vision.Virtual.Models;
using System;
using Nutshell.Serializing.Xml;
using Nutshell.Storaging;
using Nutshell.Storaging.Xml;

namespace Nutshell.Automation.Vision.Virtual
{
        /// <summary>
        ///         Class AVTCamera.
        /// </summary>
        public class VirtualVideoCamera : Camera,IStorable<VirtualVideoCameraModel>
        {
                /// <summary>
                ///         初始化<see cref="VirtualVideoCamera" />的新实例.
                /// </summary>
                /// <param name="parent">The parent.</param>
                /// <param name="id">The identifier.</param>
                /// <param name="width">The width.</param>
                /// <param name="height">The height.</param>
                public VirtualVideoCamera()
                        : base("虚拟摄像机", 2048, 1536, PixelFormat.Mono8)
                {
                }

                private readonly VideoFileReader reader = new VideoFileReader();


                public string FileName { get; private set; }

                public static VirtualVideoCamera Load(string fileName)
                {
                        var bytes = XmlStorager.Instance.Load(fileName);
                        var model = XmlSerializer<VirtualVideoCameraModel>.Instance.Deserialize(bytes);

                        var camera = new VirtualVideoCamera();

                        camera.Load(model);

                        return camera;
                }


                public void Load(VirtualVideoCameraModel model)
                {
                        base.Load(model);

                        FileName = model.FileName;
                }

                public void Save(VirtualVideoCameraModel model)
                {
                        throw new NotImplementedException();
                }

                protected override bool StartConnectCore()
                {
                        reader.Open(FileName);
                        return true;
                }

                protected override bool StopConnectCore()
                {
                        reader.Close();
                        return true;
                }

                //protected override bool StartCaptureCore()
                //{
                //        BitmapPool.Instance.Create(InterestRegion.Width, InterestRegion.Height, PixelFormat);

                //        return playLooper.Start();
                //}

                //protected override bool StopCaptureCore()
                //{
                //        return playLooper.Stop();
                //}

                protected override sealed ValueResult<Bitmap> CaptureCore()
                {

                        if (ConnectState != ConnectState.Connected
                                || DispatchState != DispatchState.Established)
                        {
                                return ValueResult<Bitmap>.Failed;
                        }

                        var bitmap = Pool.WriteLock();

                        var frame = reader.ReadVideoFrame();

                        BitmapConverter.ConvertTo(frame, bitmap);

                        Pool.WriteUnlock(bitmap);

                        //BitmapStorager.Save(bitmap, DateTime.Now.ToChineseLongFileName() + ".bmp");

                        bitmap.TimeStamps["CaptureTime"] = DateTime.Now;

                        var result = new ValueResult<Bitmap>(bitmap);

                        OnCaptureSuccessed(new ValueEventArgs<Bitmap>(bitmap));

                        return result;                       
                }
        }
}
