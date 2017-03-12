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
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Automation.Vision.Models;
using Nutshell.Hikvision.MachineVision.SDK;

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
                UserSet UserSet { get; set; }

                /// <summary>
                /// 获取或设置图像数据包大小
                /// </summary>
                /// <value>图像数据包大小</value>
                [MustGreaterThanOrEqual(8000)]
                [MustLessThanOrEqualAttribute(10000)]
                int SCPSPacketSize { get; set; }
        }
}