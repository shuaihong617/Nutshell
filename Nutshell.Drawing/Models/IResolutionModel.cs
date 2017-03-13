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

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data.Models;

namespace Nutshell.Drawing.Models
{
        /// <summary>
        ///         分辨率数据模型接口
        /// </summary>
        public interface IResolutionModel : IDataModel
        {
                /// <summary>
                ///         水平分辨率
                /// </summary>
                [MustGreaterThan(0f)]
                double Horizontal { get; set; }

                /// <summary>
                ///         垂直分辨率
                /// </summary>
                [MustGreaterThan(0f)]
                double Vertical { get; set; }
        }
}