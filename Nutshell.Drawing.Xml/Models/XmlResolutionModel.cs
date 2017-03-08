// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-03-11
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-03-12
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************


using System.Xml.Serialization;
using Nutshell.Data.Xml.Models;
using Nutshell.Drawing.Models;

namespace Nutshell.Drawing.Xml.Models
{
        /// <summary>
        ///         分辨率数据模型
        /// </summary>
        [XmlType]
        public class XmlResolutionModel : XmlDataModel,IResolutionModel
        {
		/// <summary>
		///         水平分辨率
		/// </summary>
		[XmlAttribute]
		public double Horizontal { get; set; }

		/// <summary>
		///         垂直分辨率
		/// </summary>
		[XmlAttribute]
		public double Vertical { get; set; }
        }
}