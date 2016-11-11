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

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data;
using Nutshell.Data.Models;
using Nutshell.Drawing.Models;
using PostSharp.Patterns.Model;

namespace Nutshell.Drawing
{
        /// <summary>
        ///         Class NSBitmap.
        /// </summary>
        [NotifyPropertyChanged]        
        public class Resolution : StorableObject
        {
                /// <summary>
                ///         初始化<see cref="Resolution" />的新实例.
                /// </summary>
                /// <param name="parent">The parent.</param>
                /// <param name="id">The identifier.</param>
                /// <param name="horizontal">The horizontal.</param>
                /// <param name="vertical">The vertical.</param>
                public Resolution(IdentityObject parent,
                        string id,
                        [NSGreaterThan(0)] int horizontal,
                        [NSGreaterThan(0)] int vertical)
                        : base(parent, id)
                {
                        Horizontal = horizontal;
                        Vertical = vertical;
                }

                /// <summary>
                ///         Gets the width.
                /// </summary>
                [NSGreaterThan(0)]
                public int Horizontal { get; private set; }

                /// <summary>
                ///         Gets the height.
                /// </summary>
                /// <value>The height.</value>
                [NSGreaterThan(0)]
                public int Vertical { get; private set; }

                /// <summary>
                ///         从数据模型加载数据
                /// </summary>
                /// <param name="model">数据模型</param>
                public override void Load([AssignableFrom(typeof(IResolutionModel))]IDataModel model)
                {
                        base.Load(model);

                        var resolutionModel = model as IResolutionModel;

                        Horizontal = resolutionModel.Width;
                        Vertical = resolutionModel.Height;
                }

                /// <summary>
                ///         保存数据到数据模型
                /// </summary>
                /// <param name="model">数据模型</param>
                public override void Save([AssignableFrom(typeof(IResolutionModel))]IDataModel model)
                {
                        base.Save(model);

                        var resolutionModel = model as IResolutionModel;

                        resolutionModel.Width = Horizontal;
                        resolutionModel.Height = Vertical;
                }

                /// <summary>
                ///         返回表示当前对象的字符串。
                /// </summary>
                /// <returns>
                ///         表示当前对象的字符串。
                /// </returns>
                public override string ToString()
                {
                        return $"{GlobalId}：水平{Horizontal} 垂直{Vertical}";
                }
        }
}
