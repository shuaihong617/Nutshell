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
using System.Xml.Serialization;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data.Models;

namespace Nutshell.Automation.Opc.Models
{
        /// <summary>
        ///         OPC项数据模型
        /// </summary>
        
        public class OpcItemModel :IdentityModel
        {
                /// <summary>
                ///   地址
                /// </summary>
                
                [MustNotEqualNullOrEmpty]
                public string Address { get; set; }

                /// <summary>
                ///   数据类型
                /// </summary>
                
                public TypeCode TypeCode { get; set; } = System.TypeCode.Int32;

                /// <summary>
                ///   读写模式
                /// </summary>
                
                public ReadWriteMode ReadWriteMode { get; set; } = ReadWriteMode.ReadWrite;
        }
}