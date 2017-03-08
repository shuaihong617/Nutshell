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

using Nutshell.Aspects.Locations.Contracts;
using Nutshell.Data.Aspects.Locations.Contracts;
using Nutshell.MessageQueue.RabbitMQ.Models;
using Nutshell.RabbitMQ.Models;

namespace Nutshell.RabbitMQ.Xml
{
	/// <summary>
	///         RabbitMQ认证数据模型接口
	/// </summary>
	public class RabbitMQAuthenticationModel : IRabbitMQAuthenticationModel
	{
		[MustNotEqualNullOrEmpty]
		public string HostName { get; set; }

		[MustNotEqualNullOrEmpty]
		public string Port { get; set; }

		[MustNotEqualNullOrEmpty]
		public string UserName { get; set; }

		[MustNotEqualNullOrEmpty]
		public string Password { get; set; }
	}
}