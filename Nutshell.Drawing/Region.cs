// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-11-06
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-11-06
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Drawing;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Components;
using Nutshell.Data;
using Nutshell.Data.Models;
using Nutshell.Drawing.Models;

namespace Nutshell.Drawing
{
        /// <summary>
        ///         区域
        /// </summary>
        public class Region : StorableObject, IHitTest
        {
                private int _x;
                private int _y;

                /// <summary>
                /// 初始化<see cref="Region" />的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">The key.</param>
                /// <param name="x">The x.</param>
                /// <param name="y">The y.</param>
                /// <param name="width">The width.</param>
                /// <param name="height">The height.</param>
                /// <param name="containerWidth">Width of the container.</param>
                /// <param name="containerHeight">Height of the container.</param>
                public Region(string id = null, int x = 0, int y = 0, int width = 0, int height = 0,
                        int containerWidth = 0, int containerHeight = 0)
                        : base( id)
                {
                        ContainerWidth = containerWidth;
                        ContainerHeight = containerHeight;

                        Width = width;
                        Height = height;

                        X = x;
                        Y = y;
                        
                       
                }

                /// <summary>
                ///         目标图像在源图像中水平起始坐标
                /// </summary>
                public int X
                {
                        get { return _x; }
                        set
                        {
                                if (value < 0)
                                {
                                        value = 0;
                                }

                                if (value + Width > ContainerWidth)
                                {
                                        value = ContainerWidth - Width;
                                }

                                _x = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                ///         目标图像在源图像中垂直起始坐标
                /// </summary>
                /// <value>The y.</value>
                public int Y
                {
                        get { return _y; }
                        set
                        {
                                if (value < 0)
                                {
                                        value = 0;
                                }

                                if (value + Height > ContainerHeight)
                                {
                                        value = ContainerHeight - Height;
                                }

                                _y = value;
                                OnPropertyChanged();
                        }
                }

                /// <summary>
                ///         宽度
                /// </summary>
                public int Width { get; private set; }

                /// <summary>
                ///         高度
                /// </summary>
                public int Height { get; private set; }

                /// <summary>
                ///         容器宽度
                /// </summary>
                /// <value>The width.</value>
                public int ContainerWidth { get;  set; }

                /// <summary>
                ///         容器高度
                /// </summary>
                /// <value>The height.</value>
                public int ContainerHeight { get; set; }

                /// <summary>
                ///         目标图像水平起始坐标
                /// </summary>
                /// <value>The left.</value>
                public int Left
                {
                        get { return X; }
                        set { X = value; }
                }

                /// <summary>
                ///         水平结束坐标
                /// </summary>
                /// <value>The right.</value>
                public int Right
                {
                        get { return Left + Width; }
                }


                /// <summary>
                ///         目标图像垂直起始坐标
                /// </summary>
                /// <value>The top.</value>
                public int Top
                {
                        get { return Y; }
                        set { Y = value; }
                }

                /// <summary>
                ///         垂直结束坐标
                /// </summary>
                /// <value>The bottom.</value>
                public int Bottom
                {
                        get { return Top + Height; }
                }

                /// <summary>
                ///         水平中间坐标
                /// </summary>
                /// <value>The horizontal center.</value>
                public int HorizontalCenter
                {
                        get { return (Left + Right)/2; }
                }


                /// <summary>
                ///         垂直中间坐标
                /// </summary>
                /// <value>The vertical center.</value>
                public int VerticalCenter
                {
                        get { return (Top + Bottom)/2; }
                }

                public Size OffsetSize
                {
                        get { return new Size(X, Y); }
                }

                public SizeF OffsetSizeF
                {
                        get { return new SizeF(X, Y); }
                }

                public Point LeftTop
                {
                        get { return new Point(Left, Top); }
                }

                public Point LeftBottom
                {
                        get { return new Point(Left, Bottom); }
                }

                public Point RightTop
                {
                        get { return new Point(Right, Top); }
                }

                public Point RightBottom
                {
                        get { return new Point(Right, Bottom); }
                }

                public Size Size
                {
                        get { return new Size(Width, Height); }
                }

                public Rectangle Rect
                {
                        get { return new Rectangle(X, Y, Width, Height); }
                }

                #region 方法

                /// <summary>
                ///         命中测试
                /// </summary>
                /// <param name="x">横坐标</param>
                /// <param name="y">纵坐标</param>
                /// <param name="threshold">对点、线等非连通图形测试时阈值</param>
                /// <returns>如果命中返回<c>true</c>, 否则返回<c>false</c></returns>
                public bool HitTest(float x, float y, float threshold = 16)
                {
                        if (x > Left && x < Right && y > Top && y < Bottom)
                        {
                                return true;
                        }
                        return false;
                }

                /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">数据模型</param>
                public override void Load([MustAssignableFrom(typeof(IRegionModel))]IDataModel model)
                {
                        base.Load(model);

                        var regionModel = model as IRegionModel;

                        X = regionModel.X;
                        Y = regionModel.Y;
                        Width = regionModel.Width;
                        Height = regionModel.Height;
                }

                /// <summary>
                ///         保存数据到数据模型
                /// </summary>
                /// <param name="model">数据模型</param>
                public override void Save([MustAssignableFrom(typeof(IRegionModel))]IDataModel model)
                {
                        base.Save(model);

                        var regionModel = model as IRegionModel;
                        

                        regionModel.X = X;
                        regionModel.Y = Y;
                        regionModel.Width = Width;
                        regionModel.Height = Height;
                }

                #endregion
        }
}