// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-03-11
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-03-12
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Xml.Serialization;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Storaging.Models;

namespace Nutshell.Drawing.Models
{
        /// <summary>
        ///         区域数据模型
        /// </summary>
        [XmlType]
        public class RegionModel : DataModel
        {
                /// <summary>
                ///         水平坐标
                /// </summary>
                [MustGreaterThanOrEqual(0)]
                [MustMultiplesOf(4)]
                [XmlAttribute]
                public int X { get; set; }

                /// <summary>
                ///         垂直坐标
                /// </summary>
                [MustGreaterThanOrEqual(0)]
                [MustMultiplesOf(4)]
                [XmlAttribute]
                public int Y { get; set; }

                /// <summary>
                ///         宽度
                /// </summary>
                [MustGreaterThanOrEqual(0)]
                [MustMultiplesOf(4)]
                [XmlAttribute]
                public int Width { get; set; }

                /// <summary>
                ///         高度
                /// </summary>
                [MustGreaterThanOrEqual(0)]
                [MustMultiplesOf(4)]
                [XmlAttribute]
                public int Height { get; set; }
        }
}