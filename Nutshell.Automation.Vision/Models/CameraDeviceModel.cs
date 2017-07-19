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
using Nutshell.Automation.Models;
using Nutshell.Drawing.Imaging;
using Nutshell.Drawing.Models;

namespace Nutshell.Automation.Vision.Models
{
        /// <summary>
        ///         摄像机数据模型
        /// </summary>
        [XmlType]
        public class CameraDeviceModel : CapturableDeviceModel
        {
                /// <summary>
                ///         宽度, 单位为像素
                /// </summary>
                /// <value>The width.</value>
                [XmlAttribute]
                public int Width { get; set; }

                /// <summary>
                ///         高度, 单位为像素
                /// </summary>
                [XmlAttribute]
                public int Height { get; set; }

                /// <summary>
                ///         像素格式
                /// </summary>
                [XmlAttribute]
                public PixelFormat PixelFormat { get; set; }

                /// <summary>
                ///         摄像机图像有效区域
                /// </summary>
                [XmlElement]
                public RegionModel RegionModel { get; set; }
        }
}