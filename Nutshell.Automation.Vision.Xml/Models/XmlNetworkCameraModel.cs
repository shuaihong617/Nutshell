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
using Nutshell.Automation.Vision.Models;

namespace NutshellAutomation.Vision.Xml.Models
{
        /// <summary>
        ///         网络摄像机数据模型
        /// </summary>
        [XmlType]
        public class XmlNetworkCameraModel : XmlCameraModel,INetworkCameraModel
        {
                /// <summary>
                ///         IP地址
                /// </summary>
                [XmlAttribute]
                public string IPAddress { get; set; }
        }
}