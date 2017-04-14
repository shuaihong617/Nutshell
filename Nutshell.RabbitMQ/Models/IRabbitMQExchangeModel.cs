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
using Nutshell.Data.Models;
using Nutshell.RabbitMQ.SDK;
using Nutshell.Storaging.Models;

namespace Nutshell.RabbitMQ.Models
{
	/// <summary>
	///         RabbitMQ交换机数据模型接口
	/// </summary>
	public interface IRabbitMQExchangeModel : IDataModel
	{
		/// <summary>
		///         获取或设置名称
		/// </summary>
		/// <value>名称</value>
		[MustNotEqualNullOrEmpty]
		string Name { get; set; }

		/// <summary>
		///         获取或设置交换类型
		/// </summary>
		/// <value>交换类型</value>
		ExchangeType ExchangeType { get; set; }

		/// <summary>
		///         获取或设置是否持久化
		/// </summary>
		/// <value>是否持久化</value>
		bool IsDurable { get; set; }

		/// <summary>
		///         获取或设置是否自动删除
		/// </summary>
		/// <value>是否自动删除</value>
		bool IsAutoDelete { get; set; }
	}
}