// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-04-21
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-04-21
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳.. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Xml.Serialization;

namespace Nutshell.Components.Models
{
        /// <summary>
        ///         限位数据模型
        /// </summary>
        [XmlType]
        public class LimiterModel : DistanceModel
        {
                /// <summary>
                ///         获取或设置限位模式
                /// </summary>
                /// <value>限位模式</value>
                [XmlAttribute]
                public LimitMode Mode { get; set; }
        }
}
