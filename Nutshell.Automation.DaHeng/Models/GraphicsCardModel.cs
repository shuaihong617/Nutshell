// ***********************************************************************
// 作者           : 阿尔卑斯 shuaihong617@qq.com
// 创建           : 2015-04-14
//
// 编辑           : 阿尔卑斯 shuaihong617@qq.com
// 日期           : 2015-04-14
// 内容           : 创建文件
// ***********************************************************************
// Copyright (c) 果壳机动----有金属的地方就有果壳. All rights reserved.
// <summary>
// </summary>
// ***********************************************************************

using System.Xml.Serialization;
using Nutshell.Components;
using Nutshell.Data.Models;

namespace Nutshell.Automation.DaHeng.Models
{
        /// <summary>
        ///         图像卡数据模型
        /// </summary>
        [XmlType]
        public class GraphicsCardModel : IdentityModel
        {
                /// <summary>
                /// 获取或设置是否启用
                /// </summary>
                /// <value>是否启用</value>
                [XmlAttribute]
                public int Index { get; set; }
        }
}