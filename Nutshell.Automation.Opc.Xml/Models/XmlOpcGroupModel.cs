﻿// ***********************************************************************
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


using System.Collections.Generic;
using System.Xml.Serialization;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Opc.Models;
using Nutshell.Data.Xml.Models;

namespace Nutshell.Automation.Opc.Xml.Models
{
        /// <summary>
        ///         已定义主键的对象数据模型
        /// </summary>
        [XmlType]
        public class XmlOpcGroupModel : XmlDataModel,IOpcGroupModel
        {
                [XmlAttribute]
		[MustNotEqualNullOrEmpty]
                public string Address { get; set; }

                [XmlArray]
                public List<XmlOpcItemModel> XmlOpcItemModels { get; set; }
        }
}