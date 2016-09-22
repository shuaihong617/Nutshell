// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-07-18
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-07-18
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using Nutshell.Data;
using Nutshell.Data.Models;
using Nutshell.Drawing.Shapes.Models;

namespace Nutshell.Drawing.Shapes
{
        /// <summary>
        /// 线段
        /// </summary>
        public class NSSegment : StorableObject
        {

                /// <summary>
                /// 初始化<see cref="NSSegment" />的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">标识</param>
                public NSSegment(IdentityObject parent, string id = "")
                        : base(parent, id)
                {
                }

                /// <summary>
                /// 端点1水平坐标
                /// </summary>
                public int X1 { get; set; }

                /// <summary>
                /// 端点1垂直坐标
                /// </summary>
                public int Y1 { get; set; }

                /// <summary>
                /// 端点2水平坐标
                /// </summary>
                public int X2 { get; set; }

                /// <summary>
                /// 端点2垂直坐标
                /// </summary>
                public int Y2 { get; set; }

                /// <summary>
                /// 从数据模型加载数据
                /// </summary>
                /// <param name="model">数据模型</param>
                public override void Load(IStorableModel model)
                {
                        base.Load(model);

                        var segmentModel = model as NSSegmentModel;
                        if (segmentModel == null)
                        {
                                throw new ArgumentException(model.Id + "加载失败：无法转换为SegmentModel");
                        }

                        X1 = segmentModel.X1;
                        Y1 = segmentModel.Y1;

                        X2 = segmentModel.X2;
                        Y2 = segmentModel.Y2;
                }

                /// <summary>
                /// 保存数据到数据模型
                /// </summary>
                /// <param name="model">数据模型</param>
                /// <returns>成功返回True, 否则返回False</returns>
                public override void Save(IStorableModel model)
                {
                        base.Save(model);

                        var segmentModel = model as NSSegmentModel;
                        if (segmentModel == null)
                        {
                                throw new ArgumentException(model.Id + "加载失败：无法转换为SegmentModel");
                        }

                        segmentModel.X1 = X1;
                        segmentModel.Y1 = Y1;

                        segmentModel.X2 = X2;
                        segmentModel.Y2 = Y2;
                }
        }
}