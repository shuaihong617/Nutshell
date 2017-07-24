// ***********************************************************************
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

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Aspects.Locations.Propertys;
using Nutshell.Automation.Vision.Models;
using Nutshell.Drawing;
using Nutshell.Drawing.Imaging;
using Nutshell.Threading;
using System.Diagnostics;
using Nutshell.Components.Models;
using Nutshell.Data.Models;
using Nutshell.Storaging;

namespace Nutshell.Automation.Vision
{
        /// <summary>
        ///         摄像机
        /// </summary>
        public abstract class MediaCaptureDevice : CapturableDevice<Bitmap>
        {
                /// <summary>
                ///         初始化<see cref="MediaCaptureDevice" />的实例
                /// </summary>
                /// <param name="id">标识</param>
                /// <param name="width">水平采集分辨率</param>
                /// <param name="height">垂直采集分辨率</param>
                /// <param name="pixelFormat">采集图像像素格式</param>
                protected MediaCaptureDevice(string id = "", int width = 2, int height = 2,
                        PixelFormat pixelFormat = PixelFormat.Mono8)
                        : base(id)
                {
                        Region = new Region();
                        Region.Parent = this;

                        Width = width;
                        Height = height;
                        PixelFormat = pixelFormat;
                }

                #region 字段

                private int _width;
                private int _height;

                #endregion 字段

                #region 属性

                /// <summary>
                ///         水平采集分辨率, 单位为像素
                /// </summary>
                [MustGreaterThan(0)]
                [NotifyPropertyValueChanged]
                public int Width
                {
                        get { return _width; }
                        private set
                        {
                                _width = value;
                                Region.ContainerWidth = value;
                        }
                }

                /// <summary>
                ///         垂直采集分辨率, 单位为像素
                /// </summary>
                [MustGreaterThan(0)]
                [NotifyPropertyValueChanged]
                public int Height
                {
                        get { return _height; }
                        private set
                        {
                                _height = value;
                                Region.ContainerHeight = value;
                        }
                }

                /// <summary>
                ///         格式
                /// </summary>
                public PixelFormat PixelFormat { get; private set; }

                /// <summary>
                ///         获取有效图像ROI区域数据模型
                /// </summary>
                /// <value>有效图像ROI区域数据模型</value>
                public Region Region { get; private set; }

                #endregion 属性

                #region 存储

                /// <summary>
                /// 从数据模型加载数据
                /// </summary>
                /// <param name="model">读取数据的源数据模型，该数据模型不能为空引用.</param>
                public override void Load(IIdentityModel model)
                {
                        base.Load(model);

                        var subModel = model as MediaCaptureDeviceModel;
                        Trace.Assert(subModel != null);
                

                        Width = subModel.Width;
                        Height = subModel.Height;
                        PixelFormat = subModel.PixelFormat;

                        Region.Load(subModel.RegionModel);
                }

                /// <summary>
                /// 保存数据到数据模型
                /// </summary>
                /// <param name="model">写入数据的目的数据模型，该数据模型不能为空引用</param>
                public override void Save(IIdentityModel model)
                {
                        base.Save(model);

                        var subModel = model as MediaCaptureDeviceModel;
                        Trace.Assert(subModel != null);


                        subModel.Width = Width;
                        subModel.Height = Height;
                        subModel.PixelFormat = PixelFormat;

                        Region.Save(subModel.RegionModel);
                }

                #endregion 存储

                /// <summary>
                ///         创建图像缓冲池
                /// </summary>
                protected override ReadWritePool<Bitmap> CreatePool()
                {
                        Debug.Assert(Region.Width > 0);
                        Debug.Assert(Region.Height > 0);

                        var pool = new ReadWritePool<Bitmap>("采集图像缓冲池");
                        for (var i = 1; i < 5; i++)
                        {
                                var bitmap = new Bitmap(i + "号缓冲位图", Region.Width, Region.Height, PixelFormat);
                                pool.Add(bitmap);
                        }
                        return pool;
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