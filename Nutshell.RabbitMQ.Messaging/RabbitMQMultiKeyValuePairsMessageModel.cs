﻿// ***********************************************************************
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
using Nutshell.Messaging.Models;

namespace Nutshell.RabbitMQ.Messaging.Models
{
        /// <summary>
        ///         自动装包开始消息数据模型
        /// </summary>
        
        public class RabbitMQMultiKeyValuePairsMessage<TK,TV> : RabbitMQMultiValueMessage<KeyValuePairModel<TK, TV>>
        {
                public void Add(TK k, TV v)
                {
                        Add(new KeyValuePairModel<TK, TV>(k, v));
                }
        }
}