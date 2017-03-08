// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-10-16
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-10-17
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System;
using System.Xml.Serialization;
using Nutshell.Aspects.Locations.Contracts;

namespace Nutshell.Messaging.Xml
{
        /// <summary>
        ///         日志记录
        /// </summary>
        [XmlType]
        public class XmlValueMessage<T> : XmlMessage
        {
                public XmlValueMessage(string id="", string categroy="", [MustNotEqualNull]T t=default(T)) 
                        : base(id, categroy)
                {
                        Value = t;
                }

                [XmlAttribute]
                [MustNotEqualNull]
                public T Value { get; set; }

                public string ToShortString()
                {
                        return $"{CreateTimeStamp:yyyy年MM月dd日 HH:mm:ss:fff}  {Value}";
                }

                
        }
}