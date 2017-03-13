// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-04-14
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-04-14
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Data.Xml.Models;
using System.Xml.Serialization;

namespace Nutshell.Mathematics.Models
{
        /// <summary>
        ///         线性参数数据模型
        /// </summary>
        [XmlRoot]
        public class XmlLinearityModel : XmlDataModel
        {
                /// <summary>
                ///         斜率
                /// </summary>
                [XmlAttribute]
                public float Slope { get; set; }

                /// <summary>
                ///         截距
                /// </summary>
                [XmlAttribute]
                public float Intercept { get; set; }
        }
}