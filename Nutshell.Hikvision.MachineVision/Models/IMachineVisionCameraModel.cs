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

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Vision.Models;
using Nutshell.Hikvision.MachineVision.SDK;
using System.Xml.Serialization;

namespace Nutshell.Hikvision.MachineVision.Models
{
        /// <summary>
        ///         海康威视机器视觉摄像机数据模型
        /// </summary>
        [XmlType]
        public interface IMachineVisionCameraModel : INetworkCameraModel
        {
                /// <summary>
                /// 获取或设置用户
                /// </summary>
                /// <value>用户</value>
                [MustNotEqual(UserSet.Default)]
                UserSet UserSet { get; set; }

                /// <summary>
                /// 获取或设置图像传输数据包大小
                /// </summary>
                /// <value>图像传输数据包大小</value>
                [MustBetween(OfficialApi.MinStreamChannelPacketSize, OfficialApi.MaxStreamChannelPacketSize)]
                int StreamChannelPacketSize { get; set; }
        }
}