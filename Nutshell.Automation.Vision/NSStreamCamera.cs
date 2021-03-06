﻿// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-03-24
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-03-19
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using Nutshell.Aspects.LocationContracts;
using Nutshell.Data.Models;
using Nutshell.Drawing;
using Nutshell.Drawing.Imaging;
using Nutshell.Hardware.Vision.Models;
using Nutshell.Threading;
using PostSharp.Patterns.Model;

namespace Nutshell.Hardware.Vision
{
        /// <summary>
        ///         流式摄像机
        /// </summary>
        [NotifyPropertyChanged]
        public abstract class NSStreamCamera : NSCaptureDevice<NSBitmap>
        {
                /// <summary>
                ///         初始化<see cref="NSCamera" />的实例
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">标识</param>
                /// <param name="width">水平采集分辨率</param>
                /// <param name="height">垂直采集分辨率</param>
                /// <param name="pixelFormat">采集图像像素格式</param>
                protected NSCamera(IdentityObject parent, string id = "", int width = 2, int height = 2,
                        NSPixelFormat pixelFormat = NSPixelFormat.Mono8)
                        : base(parent, id)
                {
                        Region = new NSRegion(this);

                        Width = width;
                        Height = height;
                        PixelFormat = pixelFormat;
                }

                #region 字段

                private int _width;
                private int _height;

                #endregion

                #region 属性


                public NSResolution CCDResolution { get; private set; }

                /// <summary>
                ///         水平采集分辨率, 单位为像素
                /// </summary>
                public int Width
                {
                        get { return _width; }
                        private set
                        {
                                value.MustGreaterThan(0);

                                _width = value;
                                RaisePropertyChanged();

                                Region.ContainerWidth = value;
                        }
                }

                /// <summary>
                ///         垂直采集分辨率, 单位为像素
                /// </summary>
                public int Height
                {
                        get { return _height; }
                        private set
                        {
                                value.MustGreaterThan(0);

                                _height = value;
                                RaisePropertyChanged();

                                Region.ContainerHeight = value;
                        }
                }

                /// <summary>
                ///         格式
                /// </summary>
                public NSPixelFormat PixelFormat { get; private set; }

                /// <summary>
                ///         获取有效图像ROI区域数据模型
                /// </summary>
                /// <value>有效图像ROI区域数据模型</value>
                public NSRegion Region { get; private set; }

                /// <summary>
                ///         图像池
                /// </summary>
                public NSReadWritePool<NSBitmap> Buffers { get; private set; }

                #endregion

                /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">数据模型</param>
                public override void Load([NSAssignableFromType(typeof (CameraModel))] IStorableModel model)
                {
                        base.Load(model);

                        var cameraModel = model as CameraModel;

                        Width = cameraModel.Width;
                        Height = cameraModel.Height;
                        PixelFormat = cameraModel.PixelFormat;

                        Region.Load(cameraModel.RegionModel);
                }

                /// <summary>
                ///         保存数据到数据模型
                /// </summary>
                /// <param name="model">数据模型</param>
                public override void Save([NSAssignableFromType(typeof (CameraModel))] IStorableModel model)
                {
                        base.Save(model);

                        var cameraModel = model as CameraModel;

                        cameraModel.Width = Width;
                        cameraModel.Height = Height;
                        cameraModel.PixelFormat = PixelFormat;

                        Region.Save(cameraModel.RegionModel);
                }

                /// <summary>
                ///         创建图像缓冲池
                /// </summary>
                public void CreateBitmapPool()
                {
                        if (Region.Width == 0 || Region.Height == 0)
                        {
                                throw new InvalidOperationException();
                        }

                        if (Buffers == null)
                        {
                                Buffers = new NSReadWritePool<NSBitmap>(this, "采集图像缓冲池");
                                for (var i = 1; i < 5; i++)
                                {
                                        var bitmap = new NSBitmap(Buffers, i + "号缓冲位图", Region.Width, Region.Height,
                                                PixelFormat, new NSCaptureTimeStamp());
                                        Buffers.Add(bitmap);
                                }
                        }
                }

                public void StartSimulate(string filePath)
                {
                        //var bitmap = new Bitmap(filePath);

                        //var b = bitmap.Clone(new Rectangle(94, 448, 1860, 640), PixelFormat.Format32bppRgb);

                        //Task.Run(() =>
                        //{
                        //        for (; ; )
                        //        {
                        //                OnCaptureSuccessed(new ValueEventArgs<Bitmap>(b));

                        //                Thread.Sleep(500);
                        //        }
                        //});
                }
        }
}
