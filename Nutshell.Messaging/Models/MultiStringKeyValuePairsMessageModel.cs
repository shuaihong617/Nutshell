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


using System;
using System.Xml.Serialization;

namespace Nutshell.Messaging.Models
{
        /// <summary>
        ///         自动装包开始消息数据模型
        /// </summary>
        [XmlType]
        public class MultiStringKeyValuePairsMessageModel : MultiKeyValuePairsMessageModel<string,string>
        {
                public MultiStringKeyValuePairsMessageModel()
                {
                        Id = Guid.NewGuid().ToString();
                }

                public MultiStringKeyValuePairsMessageModel(string category)
                {
                        Category = category;
                }
                public void Add(object k, object v)
                {
                        base.Add(k.ToString(), v.ToString());
                }
        }
}