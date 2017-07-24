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
using Nutshell.Automation.Models;
using Nutshell.Components.Models;

namespace Nutshell.Automation.IOBoard.Devices.Models
{
        /// <summary>
        /// IO板卡设备数据模型
        /// </summary>
        [XmlType]
        public class IOBoardDeviceModel : DispatchableDeviceModel
        {
                /// <summary>
                /// 获取或设置标准输入通道总数
                /// </summary>
                /// <value>标准输入通道总数</value>
                [XmlAttribute]
                [MustGreaterThan(0)]
                public int StandardInputChannelsCount { get; set; } = 4;

                /// <summary>
                /// 获取或设置实际使用输入通道总数
                /// </summary>
                /// <value>实际使用输入通道总数</value>
                [XmlAttribute]
                [MustGreaterThanOrEqual(0)]
                public int PracticeInputChannelsCount { get; set; } = 4;

                /// <summary>
                /// 获取或设置输出通道总数
                /// </summary>
                /// <value>输出通道总数</value>
                [XmlAttribute]
                [MustGreaterThan(0)]
                public int StandardOutputChannelsCount { get; set; } = 4;

                /// <summary>
                /// 获取或设置实际使用输出通道总数
                /// </summary>
                /// <value>实际使用输出通道总数</value>
                [XmlAttribute]
                [MustGreaterThanOrEqual(0)]
                public int PracticeOutputChannelsCount { get; set; } = 4;

                /// <summary>
                /// 获取或设置读取循环工作者
                /// </summary>
                /// <value>读取循环工作者</value>
                [XmlElement]
                [MustNotEqualNull]
                public LooperModel ReadLooperModel { get; set; }
        }
}
