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

using System.IO.Ports;
using System.Xml.Serialization;
using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data.Models;

namespace Nutshell.Hikvision.DigitalVideo.Models
{
        /// <summary>
        ///         数字视频设备授权数据模型
        /// </summary>
        [XmlType]
        public class DigitalVideoAuthorizationModel : IdentityModel
        {
                /// <summary>
                ///         获取或设置端口
                /// </summary>
                /// <value>端口</value>
                [MustGreaterThan(0)]
                [XmlAttribute]
                public int PortNumber { get; set; } = 8000;

                /// <summary>
                ///         获取或设置用户
                /// </summary>
                /// <value>用户</value>
                [MustNotEqualNullOrEmpty]
                [XmlAttribute]
                public string UserName { get; set; } = "admin";

                /// <summary>
                ///         获取或设置密码
                /// </summary>
                /// <value>密码</value>
                [MustNotEqualNullOrEmpty]
                [XmlAttribute]
                public string Password { get; set; } = "JDKD123456";
        }

        
}