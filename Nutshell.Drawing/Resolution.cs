// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2016-08-02
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2016-08-04
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Diagnostics;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data.Models;
using Nutshell.Drawing.Models;
using Nutshell.Storaging;

namespace Nutshell.Drawing
{
        /// <summary>
        ///         Class NSBitmap.
        /// </summary>
        public abstract class Resolution : StorableObject
        {
                /// <summary>
                ///         初始化<see cref="Resolution" />的新实例.
                /// </summary>
                /// <param name="id">The identifier.</param>
                /// <param name="horizontal">The horizontal.</param>
                /// <param name="vertical">The vertical.</param>
                protected Resolution(string id,
                        [MustGreaterThan(0f)] double horizontal,
                        [MustGreaterThan(0f)] double vertical)
                        : base(id)
                {
                        Horizontal = horizontal;
                        Vertical = vertical;
                }

                /// <summary>
                ///         Gets the width.
                /// </summary>
                [MustGreaterThan(0f)]
                public double Horizontal { get; private set; }

                /// <summary>
                ///         Gets the height.
                /// </summary>
                /// <value>The height.</value>
                [MustGreaterThan(0f)]
                public double Vertical { get; private set; }

                public override void Load(IIdentityModel model)
                {
                        base.Load(model);

                        var subModel = model as ResolutionModel;
                        Trace.Assert(subModel != null);

                        Horizontal = subModel.Horizontal;
                        Vertical = subModel.Vertical;
                }

                /// <summary>
                ///         返回表示当前对象的字符串。
                /// </summary>
                /// <returns>
                ///         表示当前对象的字符串。
                /// </returns>
                public override string ToString()
                {
                        return $"{GlobalId}:水平{Horizontal} 垂直{Vertical}";
                }
        }
}