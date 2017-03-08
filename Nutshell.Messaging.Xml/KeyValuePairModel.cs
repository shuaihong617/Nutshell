// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2014-11-08
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2014-11-08
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************


using System.Xml.Serialization;
using Nutshell.Data.Xml.Models;

namespace Nutshell.Messaging.Xml
{
        /// <summary>
        ///         键-值数据模型
        /// </summary>
        [XmlType]
        public class KeyValuePairModel<TK, TV>
        {
                public KeyValuePairModel()
                {
                        
                }

                public KeyValuePairModel(TK k, TV v)
                {
                        Key = k;
                        Value = v;
                }

                [XmlAttribute]
                public TK Key { get; set; }

                [XmlAttribute]
                public TV Value { get; set; }
        }
}