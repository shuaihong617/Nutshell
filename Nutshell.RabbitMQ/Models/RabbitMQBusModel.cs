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

using System.Xml.Serialization;
using Nutshell.Communication.Models;

namespace Nutshell.RabbitMQ.Models
{
        /// <summary>
        ///         Xml RabbitMQ总线数据模型
        /// </summary>
        [XmlType]
        public class RabbitMQBusModel : BusModel
	{
                [XmlElement]
		public RabbitMQAuthorizationModel RabbitMQAuthorizationModel { get; set; }
	}
}