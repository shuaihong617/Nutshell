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

using System.Net;
using System.Xml.Serialization;
using Nutshell.Aspects.Locations.Contracts;

namespace Nutshell.Sockets
{
        /// <summary>
        ///         SerialPort授权数据模型
        /// </summary>
        public class SocketAuthorization :IdentityObject
        {
                /// <summary>
                ///         获取或设置IP地址
                /// </summary>
                /// <value>IP地址</value>
                public IPAddress IPAddress { get; set; }

		/// <summary>
		///         获取或设置端口号
		/// </summary>
		/// <value>端口号</value>
		public int PortNumber { get; set; }
        }
}