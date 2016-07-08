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

using System.Diagnostics;
using Nutshell.Data.Models;
using Nutshell.Drawing.Imaging;
using Nutshell.Drawing.Shapes;
using Nutshell.Hardware.Vision.Models;

namespace Nutshell.Hardware.Vision
{
        /// <summary>
        ///         摄像机
        /// </summary>
        public abstract class Camera : CaptureDevice<Bitmap>
        {
                /// <summary>
                /// Initializes a new instance of the <see cref="Camera" /> class.
                /// </summary>
                /// <param name="parent">The parent.</param>
                /// <param name="id">The identifier.</param>
                /// <param name="width">The width.</param>
                /// <param name="height">The height.</param>
                /// <param name="pixelFormat">The image format.</param>
                protected Camera(IdentityObject parent, string id = "", int width = 2, int height = 2,
                        PixelFormat pixelFormat = PixelFormat.Mono8)
                        : base( parent, id)
                {
                        Region = new Region(this);

                        Width = width;
                        Height = height;
                        PixelFormat = pixelFormat;
                }

                #region 字段

                private int _width;
                private int _height;

                #endregion

                #region 属性

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
                public PixelFormat PixelFormat { get; private set; }

                /// <summary>
                ///         获取有效图像ROI区域数据模型
                /// </summary>
                /// <value>有效图像ROI区域数据模型</value>
                public Region Region { get; private set; }

                /// <summary>
                ///         格式
                /// </summary>
                public BitmapPool BitmapPool { get; private set; }

                #endregion

                /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">数据模型</param>
                public override void Load(IStorableModel model)
                {
                        base.Load(model);
                        
                        var cameraModel = model as CameraModel;
                        Trace.Assert(cameraModel != null);

                        Width = cameraModel.Width;
                        Height = cameraModel.Height;
                        PixelFormat = cameraModel.PixelFormat;

                        Region.Load(cameraModel.RegionModel);
                }

                /// <summary>
                ///         保存数据到数据模型
                /// </summary>
                /// <param name="model">数据模型</param>
                public override void Save(IStorableModel model)
                {
                        base.Save(model);
                        

                        var cameraModel = model as CameraModel;
                        Trace.Assert(cameraModel != null);

                        cameraModel.Width = Width;
                        cameraModel.Height = Height;
                        cameraModel.PixelFormat = PixelFormat;

                        Region.Save(cameraModel.RegionModel);
                }

                /// <summary>
                /// 创建图像缓冲区
                /// </summary>
                public void CreateBitmapPool()
                {
                        if (BitmapPool == null)
                        {
                                BitmapPool = new BitmapPool(this, Region.Width, Region.Height, PixelFormat);
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