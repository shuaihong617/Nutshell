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

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Models.Xml;

namespace Nutshell.Automation.Opc.Models
{
        /// <summary>
        ///         Opc服务器数据模型
        /// </summary>
        [XmlType]
        public class OpcServerModel : DispatchableDeviceModel
        {
                /// <summary>
                ///         名称
                /// </summary>
                [XmlAttribute]
                [MustNotEqualNullOrEmpty]
                public String Name { get; set; }

                /// <summary>
                ///         名称
                /// </summary>
                [XmlAttribute]
                [MustNotEqualNullOrEmpty]
                public String Address { get; set; }

                [XmlArray]
                public List<OpcGroupModel> XmlOpcGroupModels { get; set; }
        }
}