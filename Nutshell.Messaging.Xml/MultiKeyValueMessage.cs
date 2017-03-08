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


using System.Collections.Generic;
using System.Xml.Serialization;

namespace Nutshell.Messaging.Xml
{
        /// <summary>
        ///         自动装包开始消息数据模型
        /// </summary>
        [XmlType]
        public class MultiKeyValueMessage<TK,TV> : XmlMessage
        {
                public MultiKeyValueMessage(string id="", string categroy=null, List<KeyValuePairModel<TK, TV>> pairs = null) 
                        : base(id, categroy)
                {
                        Pairs = pairs ?? new List<KeyValuePairModel<TK, TV>>();
                }

                [XmlArray]
                public List<KeyValuePairModel<TK, TV>> Pairs { get; set; }

                
        }
}