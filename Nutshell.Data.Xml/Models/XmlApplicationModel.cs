﻿// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-01-05
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-01-05
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data.Models;
using System.Xml.Serialization;

namespace Nutshell.Data.Xml.Models
{
        /// <summary>
        ///         Xml应用程序数据模型
        /// </summary>
        [XmlRoot]
        public class XmlApplicationModel : XmlDataModel, IApplicationModel
        {
                /// <summary>
                /// 获取或设置应用程序名称
                /// </summary>
                /// <value>应用程序名称</value>
                [XmlAttribute]
                [MustNotEqualNullOrEmpty]
                public string Name { get; set; }

                /// <summary>
                /// 获取或设置版本
                /// </summary>
                /// <value>版本</value>
                [XmlAttribute]
                [MustNotEqualNullOrEmpty]
                public string Version { get; set; }

                /// <summary>
                /// 获取或设置应用程序标题
                /// </summary>
                /// <value>应用程序标题</value>
                [XmlAttribute]
                [MustNotEqualNullOrEmpty]
                public string Title { get; set; }

                /// <summary>
                /// 获取或设置公司
                /// </summary>
                /// <value>公司</value>
                [XmlAttribute]
                [MustNotEqualNullOrEmpty]
                public string Company { get; set; }

                /// <summary>
                /// 获取或设置版权信息
                /// </summary>
                /// <value>版权信息</value>
                [XmlAttribute]
                [MustNotEqualNullOrEmpty]
                public string CopyRight { get; set; }
        }
}