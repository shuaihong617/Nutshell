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

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Opc.Models;
using Nutshell.Data.Xml.Models;
using System;
using System.Xml.Serialization;
using Nutshell.Storaging.Xml.Models;

namespace Nutshell.Automation.Opc.Xml.Models
{
        /// <summary>
        ///         已定义主键的对象数据模型
        /// </summary>
        [XmlType]
        public class XmlOpcItemModel : XmlDataModel, IOpcItemModel
        {
                public XmlOpcItemModel()
                {
                        TypeCode = TypeCode.Int32;
                        ReadWriteMode = ReadWriteMode.ReadWrite;
                }

                /// <summary>
                ///   地址
                /// </summary>
                [XmlAttribute]
                [MustNotEqualNullOrEmpty]
                public string Address { get; set; }

                /// <summary>
                ///   数据类型
                /// </summary>
                [XmlAttribute]
                public TypeCode TypeCode { get; set; }

                /// <summary>
                ///   读写模式
                /// </summary>
                [XmlAttribute]
                public ReadWriteMode ReadWriteMode { get; set; }
        }
}