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

using Nutshell.Data;
using Nutshell.Drawing.Shapes.Models;
using System;
using System.Diagnostics;
using Nutshell.Components.Models;
using Nutshell.Data.Models;
using Nutshell.Storaging;

namespace Nutshell.Drawing.Shapes
{
        /// <summary>
        /// 线段
        /// </summary>
        public class Segment : StorableObject
        {
                /// <summary>
                /// 初始化<see cref="Segment" />的新实例.
                /// </summary>
                /// <param name="id">标识</param>
                public Segment(string id = "")
                        : base(id)
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


                public override void Load(IIdentityModel model)
                {
                        base.Load(model);

                        var subModel = model as SegmentModel;
                        Trace.Assert(subModel != null);

                        X1 = subModel.X1;
                        Y1 = subModel.Y1;
                        X2 = subModel.X2;
                        Y2 = subModel.Y2;
                }
                
                /// <summary>
                /// 保存数据到数据模型
                /// </summary>
                /// <param name="model">数据模型</param>
                /// <returns>成功返回True, 否则返回False</returns>
                public void Save(SegmentModel model)
                {
                        base.Save(model);

                        model.X1 = X1;
                        model.Y1 = Y1;
                        model.X2 = X2;
                        model.Y2 = Y2;
                }
        }
}