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

namespace Nutshell.Sockets.Models
{
        /// <summary>
        ///         SerialPort授权数据模型
        /// </summary>
        public class SocketAuthorizationModel :IdentityModel
        {
                /// <summary>
                ///         获取或设置IP地址
                /// </summary>
                /// <value>IP地址</value>
                [MustNotEqualNullOrEmpty]
                [XmlAttribute]
                public string IPAddress { get; set; }

		/// <summary>
		///         获取或设置端口号
		/// </summary>
		/// <value>端口号</value>
		[XmlAttribute]
		public int PortNumber { get; set; }
        }
}