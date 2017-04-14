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
using Nutshell.Communication;
using Nutshell.Data.Models;
using Nutshell.Data.Xml.Models;
using Nutshell.RabbitMQ.Models;
using Nutshell.Storaging.Xml.Models;

namespace Nutshell.RabbitMQ.Xml.Models
{
	/// <summary>
	///         RabbitMQ授权数据模型接口
	/// </summary>
	public class XmlRabbitMQAuthorizationModel :XmlDataModel, IRabbitMQAuthorizationModel
	{
		/// <summary>
		///         获取或设置主机名称
		/// </summary>
		/// <value>主机名称</value>
		[MustNotEqualNullOrEmpty]
		[XmlAttribute]
		public string HostName { get; set; }

		/// <summary>
		///         获取或设置端口号
		/// </summary>
		/// <value>端口号</value>
		[MustBetweenOrEqual(EthernetPortNumberExtensions.MinimumRecommendPortNumber,
			EthernetPortNumberExtensions.MaximumAvailablePortNumber)]
		[XmlAttribute]
		public int PortNumber { get; set; }

		/// <summary>
		///         获取或设置用户名称
		/// </summary>
		/// <value>用户名称</value>
		[MustNotEqualNullOrEmpty]
		[XmlAttribute]
		public string UserName { get; set; }

		/// <summary>
		///         获取或设置用户密码
		/// </summary>
		/// <value>用户密码</value>
		[MustNotEqualNullOrEmpty]
		[XmlAttribute]
		public string Password { get; set; }
	}
}