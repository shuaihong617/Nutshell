// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2017-07-18
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2017-07-18
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Xml.Serialization;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.IOBoard.Models;
using Nutshell.Automation.Models;

namespace Nutshell.Fyying.Models
{
        /// <summary>
        /// 飞扬电子IO板卡设备数据模型
        /// </summary>
        [XmlType]
        public class FyyingIOBoardDeviceModel : IOBoardDeviceModel
        {
                /// <summary>
                /// 获取或设置板卡编号
                /// </summary>
                /// <value>板卡编号</value>
                [XmlAttribute]
                [MustGreaterThanOrEqual(0)]
                public int BoardId { get; set; }
        }
}
