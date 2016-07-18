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
using Nutshell.Data.Models;
using Nutshell.Drawing.Shapes.Models;

namespace Nutshell.Drawing.Shapes
{
        /// <summary>
        /// 直线
        /// </summary>
        public class Line : StorableObject
        {

                /// <summary>
                /// 初始化<see cref="Line" />的新实例.
                /// </summary>
                /// <param name="parent">上级对象</param>
                /// <param name="id">标识</param>
                public Line(IdentityObject parent, string id = "")
                        : base(parent, id)
                {
                }

                /// <summary>
                /// 端点1X轴坐标
                /// </summary>
                public int X1 { get; set; }

                /// <summary>
                /// 端点1Y轴坐标
                /// </summary>
                public int Y1 { get; set; }

                /// <summary>
                /// 端点2X轴坐标
                /// </summary>
                public int X2 { get; set; }

                /// <summary>
                /// 端点2Y轴坐标
                /// </summary>
                public int Y2 { get; set; }

                /// <summary>
                /// 从数据模型加载数据
                /// </summary>
                /// <param name="model">数据模型</param>
                public override void Load(IStorableModel model)
                {
                        var lineModel = model as LineModel;
                        lineModel.MustNotNull();

                        base.Load(model);

                        X1 = lineModel.X1;
                        Y1 = lineModel.Y1;

                        X2 = lineModel.X2;
                        Y2 = lineModel.Y2;
                }

                /// <summary>
                /// 保存数据到数据模型
                /// </summary>
                /// <param name="model">数据模型</param>
                /// <returns>成功返回True, 否则返回False</returns>
                public override void Save(IStorableModel model)
                {
                        var lineModel = model as LineModel;
                        lineModel.MustNotNull();

                        base.Save(model);

                        lineModel.X1 = X1;
                        lineModel.Y1 = Y1;

                        lineModel.X2 = X2;
                        lineModel.Y2 = Y2;
                }
        }
}