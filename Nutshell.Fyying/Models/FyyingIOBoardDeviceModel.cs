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
using Nutshell.Automation.Models;

namespace Nutshell.Fyying.Models
{
        /// <summary>
        /// 飞扬电子IO板卡设备数据模型
        /// </summary>
        [XmlType]
        public class FyyingIOBoardDeviceModel : DispatchableDeviceModel
        {
                /// <summary>
                /// 获取或设置板卡编号
                /// </summary>
                /// <value>板卡编号</value>
                [XmlAttribute]
                public int BoardId { get; set; } = 0;

                /// <summary>
                /// 获取或设置输入通道总数
                /// </summary>
                /// <value>输入通道总数</value>
                [XmlAttribute]
                public int InputChannelsCount { get; set; } = 4;

                /// <summary>
                /// 获取或设置输出通道总数
                /// </summary>
                /// <value>输出通道总数</value>
                [XmlAttribute]
                public int OutputChannelsCount { get; set; } = 4;

                /// <summary>
                /// 获取或设置扫描间隔
                /// </summary>
                /// <value>扫描间隔</value>
                [XmlAttribute]
                public int ScanningInterval { get; set; } = 500;
        }
}
