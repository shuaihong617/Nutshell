// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-11-19
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-11-19
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************


using System;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Linq;
using Nutshell.Components;
using Nutshell.Data;
using Nutshell.Data.Models;

namespace Nutshell.Drawing.Shapes
{
        /// <summary>
        ///         摄像机比例标尺
        /// </summary>
        public class Ruler : StorableObject, IHitTest
        {
                /// <summary>
                /// Initializes a new instance of the <see cref="Ruler" /> class.
                /// </summary>
                /// <param name="parent">The parent.</param>
                /// <param name="id">主键</param>
                public Ruler(IdentityObject parent, string id, Direction direction)
                        : base(parent,id)

                {
                        

                        Direction.MustIn(Direction.上, Direction.下, Direction.左, Direction.右);
                        Direction = direction;

                        PixelDistance = 50;
                }

                #region 字段

                /// <summary>
                ///         刻度字典
                /// </summary>
                private readonly ConcurrentDictionary<int, Scale> _scales = new ConcurrentDictionary<int, Scale>();

                #endregion

                /// <summary>
                ///         获取比例尺方向
                /// </summary>
                /// <value>比例尺方向</value>
                public Direction Direction { get; private set; }


                /// <summary>
                ///         获取长度单位
                /// </summary>
                /// <value>长度单位</value>
                public string Unit { get; private set; }


                /// <summary>
                ///         获取最大刻度
                /// </summary>
                /// <value>最大刻度</value>
                public Scale MaxScale { get; private set; }

                /// <summary>
                ///         获取最小刻度
                /// </summary>
                /// <value>最小刻度</value>
                public Scale MinScale { get; private set; }

                /// <summary>
                ///         Gets the x.
                /// </summary>
                /// <value>The x.</value>
                public int X
                {
                        get
                        {
                                MaxScale.MustNotNull();
                                //Direction.MustIn(Direction.上, Direction.下);
                                if (Direction != Direction.上 && Direction != Direction.下)
                                {
                                        throw new Exception();
                                }

                                
                                return MaxScale.X;
                        }
                }

                /// <summary>
                ///         Gets the pixel distance.
                /// </summary>
                /// <value>The pixel distance.</value>
                public float PixelDistance { get; private set; }

                /// <summary>
                ///         获取刻度只读集合
                /// </summary>
                /// <value>刻度只读集合</value>
                public ReadOnlyCollection<Scale> Scales { get; private set; }

                public override void Load(IStorableModel model)
                {
                        base.Load(model);


                }

                public override void Save(IStorableModel model)
                {
                        base.Save(model);
                }

                /// <summary>
                ///         命中测试
                /// </summary>
                /// <param name="x">横坐标</param>
                /// <param name="y">纵坐标</param>
                /// <param name="threshold">对点、线等非连通图形测试时阈值</param>
                /// <returns>如果命中返回<c>true</c>, 否则返回<c>false</c></returns>
                public bool HitTest(float x, float y, float threshold = 32)
                {
                        if (Direction == Direction.上 || Direction == Direction.下)
                        {
                                int rulerX = X;
                                if (x.IsBetween(rulerX + threshold, rulerX - threshold)
                                    && (y.IsBetween(MaxScale.Y, MinScale.Y)))
                                {
                                        return true;
                                }
                        }
                        else
                        {
                                throw new Exception();
                        }

                        return false;
                }


                /// <summary>
                ///         Adds the scale.
                /// </summary>
                /// <param name="scale">The scale.</param>
                /// <returns>Scale.</returns>
                public Scale AddScale(Scale scale)
                {
                        _scales.TryAdd(scale.Value, scale);
                        scale.Ruler = this;


                        IOrderedEnumerable<Scale> orderScales = _scales.Values.OrderBy(i => i.Value);
                        Scales = orderScales.ToList().AsReadOnly();

                        MaxScale = Scales.Last();
                        MinScale = Scales.First();
                        float valueDistance = Math.Abs(MaxScale.Value - MinScale.Value);
                        int xDistance = Math.Abs(MaxScale.X - MinScale.X);
                        int yDistance = Math.Abs(MaxScale.Y - MinScale.Y);

                        if (Scales.Count > 1)
                        {
                                switch (Direction)
                                {
                                        case Direction.上:
                                                PixelDistance = valueDistance/yDistance;
                                                break;

                                        case Direction.下:
                                                PixelDistance = valueDistance/yDistance;
                                                break;

                                        case Direction.左:
                                                PixelDistance = valueDistance/xDistance;
                                                break;

                                        case Direction.右:
                                                PixelDistance = valueDistance/xDistance;
                                                break;
                                }
                        }


                        return scale;
                }
        }
}