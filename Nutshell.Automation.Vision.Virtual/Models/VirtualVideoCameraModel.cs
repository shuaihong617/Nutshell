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

namespace Nutshell.Automation.Vision.Virtual.Models
{
        /// <summary>
        ///         虚拟摄像机数据模型
        /// </summary>
        
        public class VirtualVideoCameraDeviceModel : MediaCaptureDeviceModel
        {
                /// <summary>
                ///         文件名称
                /// </summary>
                
                public string FileName { get; set; }
        }
}