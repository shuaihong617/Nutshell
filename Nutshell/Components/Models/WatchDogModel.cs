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

namespace Nutshell.Components.Models
{
        /// <summary>
        ///         看门狗序列化数据模型
        /// </summary>
        [XmlType]
        public class WatchDogModel : WorkerModel
        {
                /// <summary>
                ///         溢出时间间隔, 单位毫秒
                /// </summary>
                [XmlAttribute]
                public int Interval { get; set; }

                /// <summary>
                ///         扫描循环数据模型
                /// </summary>
                [XmlElement]
                public LooperModel ScanLooperModel { get; set; }

               
        }
}