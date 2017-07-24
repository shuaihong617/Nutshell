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

namespace Nutshell.Hikvision.DigitalVideo.Models
{
        /// <summary>
        ///         数字视频设备数据模型
        /// </summary>
        [XmlType]
        public class DigitalVideoDeviceModel : NetworkMediaCaptureDeviceModel
        {
                [MustNotEqualNull]
                [XmlElement]
                public DigitalVideoAuthorizationModel DigitalVideoAuthorizationModel { get; set; }
        }
}