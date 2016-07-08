// ***********************************************************************
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
using Nutshell.Components.Models;

namespace Nutshell.Distributing.Models
{
        /// <summary>
        ///         设备数据模型
        /// </summary>
        [XmlType]
        public class ReceiverModel : WorkerModel
        {
                public ReceiverModel()
                {
                        IsSubscribeMode = false;
                }

                /// <summary>
                ///         订阅模式
                /// </summary>
                [XmlAttribute]
                public bool IsSubscribeMode { get; set; }

                /// <summary>
                ///         水位
                /// </summary>
                [XmlElement]
                public LooperModel ReceiveLooperModel { get; set; }
        }
}